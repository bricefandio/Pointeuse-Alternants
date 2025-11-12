using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Pointeuse.DesktopGestion
{
    public partial class Accueil : Form
    {
        public Accueil()
        {
            InitializeComponent();
        }

        private void btnGroupe_Click(object sender, EventArgs e)
        {
            new FormGestionGroupes().ShowDialog();
        }

        private void btnEtudiants_Click(object sender, EventArgs e)
        {
            new FormGestionEtudiants().ShowDialog();
        }

        private void btnPromotions_Click(object sender, EventArgs e)
        {
            new FormGestionPromotions().ShowDialog();
        }

        private void Accueil_Load(object sender, EventArgs e)
        {

        }
    }
}
