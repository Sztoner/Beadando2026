using Kliens.Shared;
using Kliens.UserControls.Raktarvezeto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kliens.UserControls
{
    public partial class RaktarvezetoMain : UserControl
    {
        public List<Alkatresz> parts = new List<Alkatresz>();
        public Alkatresz selectedPart;

        #region Elerheto alkatresz lista frissitese
        //PartBox frissitese ha megnyilik a usercontrol
        private async void RaktarvezetoMain_Load(object sender, EventArgs e)
        {
            await UpdatePartBox();
        }

        public async Task UpdatePartBox()
        {
            try
            {
                parts = await ApiKliens.Client.GetFromJsonAsync<List<Alkatresz>>("api/Alkatresz");
                partBox.DataSource = parts;
                partBox.DisplayMember = "Nev";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        //uj alkatresz hozzaadasa
        private void ShowAddPartDialog(object sender, EventArgs e)
        {
            AlkatreszLetrehozas alkatreszLetrehozas = new AlkatreszLetrehozas();
            alkatreszLetrehozas.OnPartAdded = async () => await UpdatePartBox();
            alkatreszLetrehozas.ShowDialog();
        }

        //Kiválásztott alkatrész adatainak betöltése
        private void SelectPart(object sender, EventArgs e)
        {
            selectedPart = partBox.SelectedItem as Alkatresz;

            if (selectedPart != null)
            {
                //alkatresz adatainak beallitasa
                partNameLabel.Text = selectedPart.Nev;
                partIdLabel.Text = "ID: " + selectedPart.Id.ToString();
                priceBox.Value = selectedPart.Ar;
                maxdbBox.Value = selectedPart.MaxDb;
                //maximum elhelyezheto dbszam beallitasa
                dbBox.Maximum = selectedPart.MaxDb;
            }
        }

        //alkatresz frissitese a Mentes gomb megnyomasa utan
        public async void UpdatePart(object sender, EventArgs e)
        {
            if (selectedPart != null)
            {
                if (priceBox.Value > 0 && maxdbBox.Value > 0)
                {
                    Alkatresz partToSend = new Alkatresz
                    {
                        Id = selectedPart.Id,
                        Nev = selectedPart.Nev,
                        Ar = (int)priceBox.Value,
                        MaxDb = (int)maxdbBox.Value
                    };

                    try
                    {
                        ((Button)sender).Enabled = false;
                        var response = await ApiKliens.Client.PutAsJsonAsync($"api/Alkatresz/{partToSend.Id}", partToSend);

                        if (!response.IsSuccessStatusCode)
                        {
                            string hiba = await response.Content.ReadAsStringAsync();
                            MessageBox.Show(hiba, response.StatusCode.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        selectedPart.Ar = partToSend.Ar;
                        selectedPart.MaxDb = partToSend.MaxDb;
                        dbBox.Maximum = selectedPart.MaxDb;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally { ((Button)sender).Enabled = true; }
                }
                else MessageBox.Show("Kérem érvényes adatokat adjon meg!", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else MessageBox.Show("Kérem válasszon ki egy alkatrészt!", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        //alkatresz elhelyezese a raktarban
        public async void PlacePart(object sender, EventArgs e)
        {
            if (selectedPart != null)
            {
                //alkatresz adatainak beallitasa
                string rekeszID = $"{rowBox.Value.ToString()},{colBox.Value.ToString()},{compBox.Value.ToString()}";
                Raktar partToPlace = new Raktar();
                partToPlace.AlkatreszId = selectedPart.Id;
                partToPlace.RekeszId = rekeszID;
                partToPlace.Darabszam = (int)dbBox.Value;

                //alkatresz elhelyezese
                try
                {
                    ((Button)sender).Enabled = false;
                    var response = await ApiKliens.Client.PostAsJsonAsync("api/Raktar", partToPlace);

                    if (!response.IsSuccessStatusCode)
                    {
                        string hiba = await response.Content.ReadAsStringAsync();
                        MessageBox.Show(hiba, response.StatusCode.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    await UpdateWarehouseBox();
                    if (filterBox.SelectedIndex == 1)
                        await LoadProjectParts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally { ((Button)sender).Enabled = true; }
            }
            else MessageBox.Show("Kérem válasszon ki egy alkatrészt!", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #region Alkatresz Filterezes
        //Az alkatrészek kilistázása kiválasztott filtertol függöen
        private async Task UpdateWarehouseBox()
        {
            int selectedFilter = filterBox.SelectedIndex;
            switch (selectedFilter)
            {
                //Osszes raktarban levo alkatresz listazasa
                case 0:
                    projectsBox.Enabled = false;
                    warehouseBox.DataSource = null;
                    try
                    {
                        List<Raktar> raktar = await ApiKliens.Client.GetFromJsonAsync<List<Raktar>>("/api/Raktar");

                        if (raktar != null)
                        {
                            warehouseBox.DataSource = raktar
                                .OrderBy(x => x.RekeszId)
                                .Select(x => new
                                {
                                    x.RekeszId,
                                    x.AlkatreszNev,
                                    x.Darabszam
                                }).ToList();
                            warehouseBox.Columns["RekeszId"].HeaderText = "Pozíció";
                            warehouseBox.Columns["AlkatreszNev"].HeaderText = "Név";
                            warehouseBox.Columns["Darabszam"].HeaderText = "Darabszám";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                //Projektek alkatreszeinek listazasa
                case 1:
                    warehouseBox.DataSource = null;
                    await UpdateProjectsBox(projectsBox.SelectedIndex);
                    break;
                //Hianyzo alkatreszek kilistazasa
                case 2:
                    projectsBox.Enabled = false;
                    warehouseBox.DataSource = null;
                    try
                    {
                        List<Alkatresz> hianyzoAlkatreszek = await ApiKliens.Client.GetFromJsonAsync<List<Alkatresz>>("/api/Alkatresz/hianyzok");

                        if (hianyzoAlkatreszek != null)
                        {
                            warehouseBox.DataSource = hianyzoAlkatreszek
                                .OrderBy(x => x.MaxDb)
                                .Select(x => new
                                {
                                    x.Id,
                                    x.Nev,
                                    x.MaxDb
                                }).ToList();

                            warehouseBox.Columns["Id"].HeaderText = "Azonosító";
                            warehouseBox.Columns["Nev"].HeaderText = "Név";
                            warehouseBox.Columns["MaxDb"].HeaderText = "Hiányzó darabszám";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
        }

        //Elerheto projektek betoltese ha a megfelelo filter van kivalasztva
        private async Task UpdateProjectsBox(int index)
        {
            try
            {
                projectsBox.DataSource = null;
                List<Projekt> projects = await ApiKliens.Client.GetFromJsonAsync<List<Projekt>>("/api/Projekt");

                if (projects != null && projects.Count > 0)
                {
                    projectsBox.DataSource = projects.OrderBy(x => x.Id).ToList();
                    projectsBox.DisplayMember = "Nev";
                    projectsBox.Enabled = true;

                    if (index >= 0 && index < projects.Count)
                        projectsBox.SelectedIndex = index;
                }
                else projectsBox.Enabled = false;
            }
            catch(Exception ex)
            {
                projectsBox.Enabled = false;
                MessageBox.Show(ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Kivalasztott projekthez tartozo alkatreszek betoltese
        private async Task LoadProjectParts()
        {
            if (filterBox.SelectedIndex == 1 && projectsBox.DataSource != null)
            {
                if (projectsBox.SelectedItem is not Projekt selectedProjekt)
                    return;

                int pId = selectedProjekt.Id;
                try
                {
                    List<ProjektAlkatreszGet> projectParts = await ApiKliens.Client.GetFromJsonAsync<List<ProjektAlkatreszGet>>($"/api/Projekt/{pId}/alkatresz");

                    if (projectParts != null)
                    {
                        warehouseBox.DataSource = projectParts
                                .OrderBy(x => x.Darabszam)
                                .Select(x => new
                                {
                                    x.AlkatreszNev,
                                    x.Darabszam,
                                    x.HianyDb
                                }).ToList();
                        warehouseBox.Columns["AlkatreszNev"].HeaderText = "Név";
                        warehouseBox.Columns["Darabszam"].HeaderText = "Foglalt Darabszám";
                        warehouseBox.Columns["HianyDb"].HeaderText = "Kivitelezéshez hiányzó";
                    }
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        //WarehouseBox frissitese ha valtozik a kivalasztott filter
        private async void filterBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            await UpdateWarehouseBox();
        }

        //ProjectsBox frissitese ha valtozik a kivalasztott projekt
        private async void projectsBox_SelectedValueChanged(object sender, EventArgs e)
        {
            await LoadProjectParts();
        }
        #endregion

        public RaktarvezetoMain()
        {
            InitializeComponent();
            filterBox.SelectedIndex = 0;
        }
    }
}
