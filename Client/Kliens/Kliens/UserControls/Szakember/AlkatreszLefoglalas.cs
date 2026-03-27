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
        public Action? OnPartsAdded;


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
                    if(elerhetoseg != null)
                    {
                        int elerhetoDb = elerhetoseg.RaktarDb - elerhetoseg.FoglaltDb;
                        if(elerhetoDb >= 0)
                            avaLabel.Text = "Elérhetö" + "\n" + (elerhetoseg.RaktarDb - elerhetoseg.FoglaltDb).ToString() + "db";
                        else avaLabel.Text = "Hiányzik" + "\n" + (((elerhetoseg.RaktarDb - elerhetoseg.FoglaltDb))*(-1)).ToString() + "db";
                    }
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

        private async void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedParts.Count > 0)
                {
                    bool vanHianyzo = false;
                    List<ProjektAlkatresz> projektParts = new List<ProjektAlkatresz>();
                    foreach (Alkatresz a in selectedParts)
                    {
                        AlkatreszElerhetoseg elerhetoseg = await ApiKliens.Client.GetFromJsonAsync<AlkatreszElerhetoseg>($"/api/Alkatresz/{a.Id}/elerhetoseg");
                        int elerhetodb = 0;
                        if (elerhetoseg != null)
                            elerhetodb = elerhetoseg.RaktarDb - elerhetoseg.FoglaltDb;
                        else
                        {
                            MessageBox.Show("Nem található ilyen alkatrész", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        ProjektAlkatresz partToAdd = new ProjektAlkatresz
                        {
                            ProjektId = selectedProjekt.Id,
                            AlkatreszId = a.Id,
                            Darabszam = a.MaxDb,
                        };

                        if (elerhetodb < partToAdd.Darabszam)
                        {
                            partToAdd.HianyDb = (elerhetodb - partToAdd.Darabszam) * (-1);
                            vanHianyzo = true;
                        }
                        else partToAdd.HianyDb = 0;

                        projektParts.Add(partToAdd);
                    }

                    ((Button)sender).Enabled = false;
                    var response = await ApiKliens.Client.PostAsJsonAsync<List<ProjektAlkatresz>>($"api/Projekt/{selectedProjekt.Id}/alkatresz", projektParts);
                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Nem sikerült az alkatrészek lefoglalása!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    Naplo projektNaplo = new Naplo
                    {
                        ProjektId = selectedProjekt.Id,
                        Datum = DateTime.UtcNow.Date
                    };

                    selectedProjekt.Statusz = "Draft";
                    projektNaplo.Statusz = selectedProjekt.Statusz;
                    response = await ApiKliens.Client.PostAsJsonAsync("api/Projekt/naplo", projektNaplo);

                    if (!response.IsSuccessStatusCode)
                    {
                        string hiba = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Nem sikerült naplót generálni!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (vanHianyzo)
                    {
                        selectedProjekt.Statusz = "Wait";
                        projektNaplo.Statusz = selectedProjekt.Statusz;
                        response = await ApiKliens.Client.PostAsJsonAsync<Naplo>("api/Projekt/naplo", projektNaplo);
                        if (!response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Nem sikerült naplót generálni!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    response = await ApiKliens.Client.PutAsJsonAsync<Projekt>("/api/Projekt", selectedProjekt);
                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Nem sikerült naplót generálni!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("A kiválasztott alkatrészek lefoglalása sikeresen megtörtént!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OnPartsAdded?.Invoke();
                    this.Dispose();
                }
                else MessageBox.Show("Válasszon ki alkatrészeket!", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch(Exception ex)
            {
                MessageBox.Show("A mentés nem sikerült\nFeltehetöleg szerverhiba történt", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            { ((Button)sender).Enabled = true; }
        }
    }
}
