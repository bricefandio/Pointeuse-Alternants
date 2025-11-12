using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pointeuse.DesktopGestion.Services;

namespace Pointeuse.DesktopGestion
{
    public partial class FormLogin : Form
    {
        private readonly ApiClient _api;
        public FormLogin()
        {
            InitializeComponent();
            _api = new ApiClient("https://localhost:7124/");
        }




        private async void btnConnexion_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Veuillez saisir vos identifiants !");
                return;
            }

            try
            {
                bool ok = await _api.LoginAsync(username, password);
                if (ok)
                {
                    MessageBox.Show("Connexion réussie !");
                    this.Hide();

                    // Ouvrir la fenêtre d'accueil
                    var accueil = new Accueil();
                    accueil.ShowDialog();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Identifiants invalides !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur connexion : " + ex.Message);
            }
        }




        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }








        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
