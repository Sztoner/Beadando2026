using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kliens.Shared;
using Kliens.Shared.Models;

namespace Kliens.UserControls.Szakember
{
    public partial class AlkatreszLefoglalas : Form
    {
        private Projekt selectedProjekt;
        private List<Alkatresz> parts = new List<Alkatresz>();
        private List<Alkatresz> selectedParts = new List<Alkatresz>();

        private void UpdatePartsBox()
        {
            partsBox.Items.Clear();
            foreach (Alkatresz a in parts)
            {
                partsBox.Items.Add($"{a.Nev}\t{a.Ar}Ft");
            }
        }

        private void UpdateProjektPartsBox()
        {
            projektpartsBox.Items.Clear();
            foreach (Alkatresz a in selectedParts)
            {
                projektpartsBox.Items.Add($"{a.Nev}\t{a.MaxDb}db");
            }
        }

        private void MovePart(object sender, EventArgs e)
        {
            if (parts.Count > 0 && partsBox.SelectedIndex < parts.Count && partsBox.SelectedIndex >= 0)
            {
                selectedParts
                .Add(
                    new Alkatresz
                    {
                        Id = parts[partsBox.SelectedIndex].Id,
                        Nev = parts[partsBox.SelectedIndex].Nev,
                        Ar = parts[partsBox.SelectedIndex].Ar,
                        MaxDb = (int)dbBox.Value
                    }
                    );
                parts.RemoveAt(partsBox.SelectedIndex);
                UpdatePartsBox();
                UpdateProjektPartsBox();
            }
        }

        private void MovePartBack(object sender, EventArgs e)
        {
            if (selectedParts.Count > 0 && projektpartsBox.SelectedIndex < selectedParts.Count && projektpartsBox.SelectedIndex >= 0)
            {
                try
                {
                    parts
                        .Add(
                            new Alkatresz
                            {
                                Id = selectedParts[projektpartsBox.SelectedIndex].Id,
                                Nev = selectedParts[projektpartsBox.SelectedIndex].Nev,
                                Ar = selectedParts[projektpartsBox.SelectedIndex].Ar
                            }
                        );
                    selectedParts.RemoveAt(projektpartsBox.SelectedIndex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                UpdatePartsBox();
                UpdateProjektPartsBox();
            }
        }

        private async void GetPartAvaiablity(object sender, EventArgs e)
        {
            if(parts.Count > 0 && partsBox.SelectedIndex < parts.Count && partsBox.SelectedIndex >= 0)
            {
                try
                { 
                    AlkatreszElerhetoseg elerhetoseg  = await ApiKliens.Client.GetFromJsonAsync<AlkatreszElerhetoseg>($"/api/Alkatresz/{parts[partsBox.SelectedIndex].Id}/elerhetoseg");
                    avaLabel.Text = "Elérhetö"+ "\n" + (elerhetoseg.RaktarDb - elerhetoseg.FoglaltDb).ToString()+"db";
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public AlkatreszLefoglalas(Projekt p)
        {
            InitializeComponent();
            selectedProjekt = p;
        }

        private async void AlkatreszLefoglalas_Load(object sender, EventArgs e)
        {
            try
            {
                parts = await ApiKliens.Client.GetFromJsonAsync<List<Alkatresz>>("api/Alkatresz");
                UpdatePartsBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (selectedParts.Count > 0)
            {
                List<ProjektAlkatresz> projektParts = new List<ProjektAlkatresz>();
                foreach(Alkatresz a in selectedParts)
                {
                    projektParts.Add(
                        new ProjektAlkatresz
                        {
                            ProjektId = selectedProjekt.Id,
                            AlkatreszId = a.Id,
                            Darabszam = a.MaxDb,
                            HianyDb = 0
                        }
                    );
                }
            }
            else MessageBox.Show("Válasszon ki alkatrészeket!", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
