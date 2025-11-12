namespace Pointeuse.DesktopGestion
{
    partial class FormGestionGroupes
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
            lblType = new Label();
            txtType = new TextBox(); // ✅ remplacement du ComboBox par un TextBox
            btnAjouter = new Button();
            btnModifier = new Button();
            btnSupprimer = new Button();
            btnExporter = new Button();
            dgvGroupes = new DataGridView();
            btnRefresh = new Button();
            btnRetour = new Button();

            ((System.ComponentModel.ISupportInitialize)dgvGroupes).BeginInit();
            SuspendLayout();

            // --- Label Type ---
            lblType.AutoSize = true;
            lblType.Location = new Point(30, 40);
            lblType.Name = "lblType";
            lblType.Size = new Size(34, 15);
            lblType.Text = "Type";

            // --- TextBox Type ---
            txtType.Location = new Point(80, 37);  // ✅ position du champ
            txtType.Name = "txtType";
            txtType.Size = new Size(150, 23);

            // --- DataGridView ---
            dgvGroupes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGroupes.Location = new Point(260, 37);
            dgvGroupes.Name = "dgvGroupes";
            dgvGroupes.Size = new Size(520, 300);
            dgvGroupes.SelectionChanged += dgvGroupes_SelectionChanged;

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
            Controls.Add(lblType);
            Controls.Add(txtType);       // ✅ ajoute le TextBox au formulaire
            Controls.Add(dgvGroupes);
            Controls.Add(btnAjouter);
            Controls.Add(btnModifier);
            Controls.Add(btnSupprimer);
            Controls.Add(btnExporter);
            Controls.Add(btnRefresh);
            Controls.Add(btnRetour);
            Name = "FormGestionGroupes";
            Text = "Gestion des Groupes";
            Load += FormGestionGroupes_Load;

            ((System.ComponentModel.ISupportInitialize)dgvGroupes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // --- Déclarations des contrôles ---
        private Label lblType;
        private TextBox txtType;        // ✅ à la place du ComboBox
        private DataGridView dgvGroupes;
        private Button btnAjouter;
        private Button btnModifier;
        private Button btnSupprimer;
        private Button btnExporter;
        private Button btnRefresh;
        private Button btnRetour;
    }
}
