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
    public partial class FormGestionGroupes : Form
    {
        private readonly ApiClient _api;
        private BindingSource _bsGroupes = new BindingSource();
        public FormGestionGroupes()
        {
            InitializeComponent();
            _api = new ApiClient("https://localhost:7124/");

            dgvGroupes.AutoGenerateColumns = false;
            dgvGroupes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGroupes.MultiSelect = false;
            dgvGroupes.ReadOnly = true;

            if (dgvGroupes.Columns.Count == 0)
            {
                dgvGroupes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Id", DataPropertyName = "Id", Visible = false });
                dgvGroupes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Type", DataPropertyName = "Type" });
            }

            dgvGroupes.DataSource = _bsGroupes;
        }
        private async void FormGestionGroupes_Load(object sender, EventArgs e)
        {
            await LoadGroupesAsync();
        }
        private async Task LoadGroupesAsync()
        {
            try
            {
                var list = await _api.GetGroupesAsync();
                _bsGroupes.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur chargement groupes : " + ex.Message);
            }
        }


        private GroupeDto GetSelectedGroupe() => _bsGroupes.Current as GroupeDto;

        private void ClearForm() => txtType.Text = "";

        private async void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                var g = new GroupeDto { Type = txtType.Text.Trim() };
                await _api.CreateGroupeAsync(g);
                await LoadGroupesAsync();
                ClearForm();
                MessageBox.Show("Groupe ajouté !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur ajout : " + ex.Message);
            }
        }

        private async void btnModifier_Click(object sender, EventArgs e)
        {
            var sel = GetSelectedGroupe();
            if (sel == null)
            {
                MessageBox.Show("Sélectionnez un groupe");
                return;
            }

            try
            {
                sel.Type = txtType.Text.Trim();
                await _api.UpdateGroupeAsync(sel.Id, sel);
                await LoadGroupesAsync();
                MessageBox.Show("Groupe modifié !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur modification : " + ex.Message);
            }
        }

        private async void btnSupprimer_Click(object sender, EventArgs e)
        {
            var sel = GetSelectedGroupe();
            if (sel == null)
            {
                MessageBox.Show("Sélectionnez un groupe");
                return;
            }

            if (MessageBox.Show($"Supprimer le groupe {sel.Type} ?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            try
            {
                await _api.DeleteGroupeAsync(sel.Id);
                await LoadGroupesAsync();
                MessageBox.Show("Groupe supprimé !");
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
                var list = (List<GroupeDto>)_bsGroupes.DataSource;
                if (list == null || !list.Any())
                {
                    MessageBox.Show("Rien à exporter");
                    return;
                }

                using var sfd = new SaveFileDialog { Filter = "Fichier CSV|*.csv", FileName = "Groupes.csv" };
                if (sfd.ShowDialog() != DialogResult.OK) return;

                using var writer = new StreamWriter(sfd.FileName);
                writer.WriteLine("Id;Type");
                foreach (var g in list)
                    writer.WriteLine($"{g.Id};{g.Type}");

                MessageBox.Show("Export CSV terminé !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur export : " + ex.Message);
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadGroupesAsync();
        }


        private void dgvGroupes_SelectionChanged(object sender, EventArgs e)
        {
            var sel = GetSelectedGroupe();
            if (sel == null) return;
            txtType.Text = sel.Type;
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblType_Click(object sender, EventArgs e)
        {

        }

        private void dgvGroupes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

       

        private void btnRetour_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
