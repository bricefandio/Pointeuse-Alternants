using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pointeuse.DesktopGestion.Models;
using Pointeuse.DesktopGestion.Services;
using System.IO;



namespace Pointeuse.DesktopGestion
{
    public partial class FormGestionPromotions : Form
    {
        private readonly ApiClient _api;
        private BindingSource _bsPromotions = new BindingSource();

        public FormGestionPromotions()
        {
            InitializeComponent();
            _api = new ApiClient("https://localhost:7124/");

            dgvPromotions.AutoGenerateColumns = false;
            dgvPromotions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPromotions.MultiSelect = false;
            dgvPromotions.ReadOnly = true;

            if (dgvPromotions.Columns.Count == 0)
            {
                dgvPromotions.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Id", DataPropertyName = "Id", Visible = false });
                dgvPromotions.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Année", DataPropertyName = "Annee" });
            }

            dgvPromotions.DataSource = _bsPromotions;
        }


        private async void FormGestionPromotions_Load(object sender, EventArgs e)
        {
            await LoadPromotionsAsync();
        }


        private async Task LoadPromotionsAsync()
        {
            try
            {
                var list = await _api.GetPromotionsAsync();
                _bsPromotions.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur chargement promotions : " + ex.Message);
            }
        }



        private PromotionDto GetSelectedPromotion() => _bsPromotions.Current as PromotionDto;

        private void ClearForm() => txtAnnee.Text = "";



        private async void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                var p = new PromotionDto { Annee = txtAnnee.Text.Trim() };
                await _api.CreatePromotionAsync(p);
                await LoadPromotionsAsync();
                ClearForm();
                MessageBox.Show("Promotion ajoutée !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur ajout : " + ex.Message);
            }
        }

        private async void btnModifier_Click(object sender, EventArgs e)
        {
            var sel = GetSelectedPromotion();
            if (sel == null)
            {
                MessageBox.Show("Sélectionnez une promotion");
                return;
            }

            try
            {
                sel.Annee = txtAnnee.Text.Trim();
                await _api.UpdatePromotionAsync(sel.Id, sel);
                await LoadPromotionsAsync();
                MessageBox.Show("Promotion modifiée !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur modification : " + ex.Message);
            }
        }

        private async void btnSupprimer_Click(object sender, EventArgs e)
        {
            var sel = GetSelectedPromotion();
            if (sel == null) { MessageBox.Show("Sélectionnez une promotion"); return; }

            if (MessageBox.Show($"Supprimer la promotion {sel.Annee} ?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            try
            {
                await _api.DeletePromotionAsync(sel.Id);
                await LoadPromotionsAsync();
                MessageBox.Show("Promotion supprimée !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur suppression : " + ex.Message);
            }
        }

        private void btnExporter_Click(object sender, EventArgs e)
        {
            try
            {
                var list = (List<PromotionDto>)_bsPromotions.DataSource;
                if (list == null || !list.Any())
                {
                    MessageBox.Show("Rien à exporter");
                    return;
                }

                using var sfd = new SaveFileDialog { Filter = "Fichier CSV|*.csv", FileName = "Promotions.csv" };
                if (sfd.ShowDialog() != DialogResult.OK) return;

                using var writer = new StreamWriter(sfd.FileName);
                writer.WriteLine("Id;Annee");
                foreach (var p in list)
                    writer.WriteLine($"{p.Id};{p.Annee}");

                MessageBox.Show("Export CSV terminé !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur export : " + ex.Message);
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadPromotionsAsync();
        }

        private void btnRetour_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvPromotions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbAnnee_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblAnnee_Click(object sender, EventArgs e)
        {

        }

        private void dgvPromotions_SelectionChanged(object sender, EventArgs e)
        {
            var sel = GetSelectedPromotion();
            if (sel == null) return;
            txtAnnee.Text = sel.Annee;
        }
    }
}
