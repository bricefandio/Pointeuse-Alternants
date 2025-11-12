using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Pointeuse.DesktopGestion.Models;
using Pointeuse.DesktopGestion.Services;

namespace Pointeuse.DesktopGestion
{
    public partial class FormGestionEtudiants : Form
    {
        private readonly ApiClient _api;
        private BindingSource _bsEtudiants = new BindingSource();
        private List<GroupeDto> _groupes = new List<GroupeDto>();
        private List<PromotionDto> _promotions = new List<PromotionDto>();


        public FormGestionEtudiants()
        {
            InitializeComponent();
            // 🔗 URL de ton API (adapte selon ton backend)
            _api = new ApiClient("https://localhost:7124/");

            // Configuration du DataGridView
            dgvEtudiants.AutoGenerateColumns = false;
            dgvEtudiants.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEtudiants.MultiSelect = false;
            dgvEtudiants.ReadOnly = true;
            dgvEtudiants.AllowUserToAddRows = false;

            // Colonnes si absentes
            if (dgvEtudiants.Columns.Count == 0)
            {
                dgvEtudiants.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Id", DataPropertyName = "Id", Visible = false });
                dgvEtudiants.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nom", DataPropertyName = "Nom" });
                dgvEtudiants.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Prénom", DataPropertyName = "Prenom" });
                dgvEtudiants.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Groupe", DataPropertyName = "GroupeLibelle" });
                dgvEtudiants.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Promotion", DataPropertyName = "PromotionLibelle" });
                dgvEtudiants.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "QR Code", DataPropertyName = "QrCodeHash" });
            }

            dgvEtudiants.DataSource = _bsEtudiants;
        }



        // Au chargement du formulaire
        private async void FormGestionEtudiants_Load(object sender, EventArgs e)
        {
            await LoadEtudiantsAsync();
        }

        // Chargement des Groupes et Promotions
        private async Task LoadLookupsAsync()
        {
            try
            {
                _groupes = await _api.GetGroupesAsync();
                cbGroupe.DataSource = _groupes;
                cbGroupe.DisplayMember = "Type";
                cbGroupe.ValueMember = "Id";

                _promotions = await _api.GetPromotionsAsync();
                cbPromotion.DataSource = _promotions;
                cbPromotion.DisplayMember = "Annee";
                cbPromotion.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des listes : " + ex.Message);
            }
        }


        // Chargement des étudiants
        private async Task LoadEtudiantsAsync()
        {
            try
            {
                var list = await _api.GetEtudiantsAsync();

                // Si les lookups ne sont pas encore chargés, on les charge d’abord
                if (_groupes.Count == 0 || _promotions.Count == 0)
                    await LoadLookupsAsync();

                foreach (var etu in list)
                {
                    var g = _groupes.FirstOrDefault(x => x.Id == etu.GroupeId);
                    var p = _promotions.FirstOrDefault(x => x.Id == etu.PromotionId);

                    etu.GroupeLibelle = g != null ? g.Type : etu.GroupeId.ToString();
                    etu.PromotionLibelle = p != null ? p.Annee : etu.PromotionId.ToString();
                }

                _bsEtudiants.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur chargement étudiants : " + ex.Message);
            }
        }

        private EtudiantDto GetSelectedEtudiant()
        {
            return _bsEtudiants.Current as EtudiantDto;
        }

        private void ClearForm()
        {
            txtNom.Text = "";
            txtPrenom.Text = "";
            if (cbGroupe.Items.Count > 0) cbGroupe.SelectedIndex = 0;
            if (cbPromotion.Items.Count > 0) cbPromotion.SelectedIndex = 0;
        }

        private async void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                var etudiantNew = new EtudiantDto
                {
                    Nom = txtNom.Text.Trim(),
                    Prenom = txtPrenom.Text.Trim(),
                    GroupeId = (int)cbGroupe.SelectedValue,
                    PromotionId = (int)cbPromotion.SelectedValue,
                    QrCodeHash = Guid.NewGuid().ToString("N")
                };

                await _api.CreateEtudiantAsync(etudiantNew);
                await LoadEtudiantsAsync();
                ClearForm();
                MessageBox.Show("Étudiant ajouté !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur ajout : " + ex.Message);
            }
        }

        private async void btnModifier_Click(object sender, EventArgs e)
        {
            var sel = GetSelectedEtudiant();
            if (sel == null)
            {
                MessageBox.Show("Sélectionnez un étudiant");
                return;
            }

            try
            {
                sel.Nom = txtNom.Text.Trim();
                sel.Prenom = txtPrenom.Text.Trim();
                sel.GroupeId = (int)cbGroupe.SelectedValue;
                sel.PromotionId = (int)cbPromotion.SelectedValue;

                await _api.UpdateEtudiantAsync(sel.Id, sel);
                await LoadEtudiantsAsync();
                MessageBox.Show("Étudiant modifié !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur modification : " + ex.Message);
            }
        }

        private async void btnSupprimer_Click(object sender, EventArgs e)
        {
            var sel = GetSelectedEtudiant();
            if (sel == null)
            {
                MessageBox.Show("Sélectionnez un étudiant");
                return;
            }

            if (MessageBox.Show($"Supprimer {sel.Nom} {sel.Prenom} ?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            try
            {
                await _api.DeleteEtudiantAsync(sel.Id);
                await LoadEtudiantsAsync();
                MessageBox.Show("Étudiant supprimé !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur suppression : " + ex.Message);
            }
        }

        private void dgvEtudiants_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadLookupsAsync();
            await LoadEtudiantsAsync();
        }

        private void btnExporter_Click(object sender, EventArgs e)
        {
            try
            {
                var list = (List<EtudiantDto>)_bsEtudiants.DataSource;
                if (list == null || !list.Any())
                {
                    MessageBox.Show("Aucune donnée à exporter !");
                    return;
                }

                using var sfd = new SaveFileDialog
                {
                    Filter = "Fichier CSV|*.csv",
                    FileName = "Etudiants.csv"
                };

                if (sfd.ShowDialog() != DialogResult.OK) return;

                using var writer = new StreamWriter(sfd.FileName);
                writer.WriteLine("Id;Nom;Prenom;Groupe;Promotion;QrCodeHash");

                var dictGroupes = _groupes.ToDictionary(g => g.Id, g => g.Type);
                var dictPromos = _promotions.ToDictionary(p => p.Id, p => p.Annee);

                // 💡 CORRECTION APPORTÉE ICI : Remplacement de 'e' par 'etu'
                foreach (var etu in list)
                {
                    var g = dictGroupes.ContainsKey(etu.GroupeId) ? dictGroupes[etu.GroupeId] : etu.GroupeId.ToString();
                    var p = dictPromos.ContainsKey(etu.PromotionId) ? dictPromos[etu.PromotionId] : etu.PromotionId.ToString();
                    writer.WriteLine($"{etu.Id};{etu.Nom};{etu.Prenom};{g};{p};{etu.QrCodeHash}");
                }

                writer.Flush();
                MessageBox.Show("Export CSV terminé !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur export : " + ex.Message);
            }
        }

        private void dgvEtudiants_SelectionChanged(object sender, EventArgs e)
        {
            var sel = _bsEtudiants.Current as EtudiantDto;
            if (sel == null) return;
            txtNom.Text = sel.Nom;
            txtPrenom.Text = sel.Prenom;
            cbGroupe.SelectedValue = sel.GroupeId;
            cbPromotion.SelectedValue = sel.PromotionId;
        }

        private void txtNom_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbPromotion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbGroupe_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtPrenom_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblPromotion_Click(object sender, EventArgs e)
        {

        }

        private void lblGroupe_Click(object sender, EventArgs e)
        {

        }

        private void lblPrenom_Click(object sender, EventArgs e)
        {

        }

        private void lblNom_Click(object sender, EventArgs e)
        {

        }

        private void btnRetour_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
