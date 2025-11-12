namespace Pointeuse.DesktopGestion
{
    partial class FormGestionPromotions
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            // --- Création des contrôles ---
            lblAnnee = new Label();
            txtAnnee = new TextBox(); // ✅ remplacement du ComboBox par un TextBox
            dgvPromotions = new DataGridView();
            btnAjouter = new Button();
            btnModifier = new Button();
            btnSupprimer = new Button();
            btnExporter = new Button();
            btnRefresh = new Button();
            btnRetour = new Button();

            ((System.ComponentModel.ISupportInitialize)dgvPromotions).BeginInit();
            SuspendLayout();

            // --- Label Année ---
            lblAnnee.AutoSize = true;
            lblAnnee.Location = new Point(25, 40);
            lblAnnee.Name = "lblAnnee";
            lblAnnee.Size = new Size(42, 15);
            lblAnnee.Text = "Année";

            // --- TextBox Année ---
            txtAnnee.Location = new Point(80, 37);
            txtAnnee.Name = "txtAnnee";
            txtAnnee.Size = new Size(150, 23);

            // --- DataGridView ---
            dgvPromotions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPromotions.Location = new Point(260, 37);
            dgvPromotions.Name = "dgvPromotions";
            dgvPromotions.Size = new Size(520, 300);
            dgvPromotions.SelectionChanged += dgvPromotions_SelectionChanged;

            // --- Boutons CRUD + autres ---
            btnAjouter.Location = new Point(30, 360);
            btnAjouter.Text = "Ajouter";
            btnAjouter.Click += btnAjouter_Click;

            btnModifier.Location = new Point(120, 360);
            btnModifier.Text = "Modifier";
            btnModifier.Click += btnModifier_Click;

            btnSupprimer.Location = new Point(210, 360);
            btnSupprimer.Text = "Supprimer";
            btnSupprimer.Click += btnSupprimer_Click;



            btnExporter.Location = new Point(310, 360);
            btnExporter.Text = "Exporter";
            btnExporter.Click += btnExporter_Click;

            btnRefresh.Location = new Point(410, 360);
            btnRefresh.Text = "Refresh";
            btnRefresh.Click += btnRefresh_Click;

            btnRetour.Location = new Point(510, 360);
            btnRetour.Text = "Retour";
            btnRetour.Click += btnRetour_Click;

            // --- Configuration du formulaire ---
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblAnnee);
            Controls.Add(txtAnnee);      // ✅ ajoute le TextBox au formulaire
            Controls.Add(dgvPromotions);
            Controls.Add(btnAjouter);
            Controls.Add(btnModifier);
            Controls.Add(btnSupprimer);
            Controls.Add(btnExporter);
            Controls.Add(btnRefresh);
            Controls.Add(btnRetour);
            Name = "FormGestionPromotions";
            Text = "Gestion des Promotions";
            Load += FormGestionPromotions_Load;

            ((System.ComponentModel.ISupportInitialize)dgvPromotions).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // --- Déclarations des contrôles ---
        private Label lblAnnee;
        private TextBox txtAnnee;        // ✅ à la place du ComboBox
        private DataGridView dgvPromotions;
        private Button btnAjouter;
        private Button btnModifier;
        private Button btnSupprimer;
        private Button btnExporter;
        private Button btnRefresh;
        private Button btnRetour;
    }
}
