namespace Pointeuse.DesktopGestion
{
    partial class FormGestionEtudiants
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvEtudiants = new DataGridView();
            txtNom = new TextBox();
            txtPrenom = new TextBox();
            cbGroupe = new ComboBox();
            cbPromotion = new ComboBox();
            btnAjouter = new Button();
            btnModifier = new Button();
            btnSupprimer = new Button();
            btnExporter = new Button();
            btnRefresh = new Button();
            lblNom = new Label();
            lblPrenom = new Label();
            lblGroupe = new Label();
            lblPromotion = new Label();
            btnRetour = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEtudiants).BeginInit();
            SuspendLayout();
            // 
            // dgvEtudiants
            // 
            dgvEtudiants.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEtudiants.Location = new Point(217, 9);
            dgvEtudiants.Name = "dgvEtudiants";
            dgvEtudiants.Size = new Size(571, 400);
            dgvEtudiants.TabIndex = 0;
            dgvEtudiants.CellContentClick += dgvEtudiants_CellContentClick;
            dgvEtudiants.SelectionChanged += dgvEtudiants_SelectionChanged;
            // 
            // txtNom
            // 
            txtNom.Location = new Point(90, 12);
            txtNom.Name = "txtNom";
            txtNom.Size = new Size(100, 23);
            txtNom.TabIndex = 1;
            txtNom.TextChanged += txtNom_TextChanged;
            // 
            // txtPrenom
            // 
            txtPrenom.Location = new Point(90, 53);
            txtPrenom.Name = "txtPrenom";
            txtPrenom.Size = new Size(100, 23);
            txtPrenom.TabIndex = 2;
            txtPrenom.TextChanged += txtPrenom_TextChanged;
            // 
            // cbGroupe
            // 
            cbGroupe.FormattingEnabled = true;
            cbGroupe.Location = new Point(90, 99);
            cbGroupe.Name = "cbGroupe";
            cbGroupe.Size = new Size(121, 23);
            cbGroupe.TabIndex = 3;
            cbGroupe.SelectedIndexChanged += cbGroupe_SelectedIndexChanged;
            // 
            // cbPromotion
            // 
            cbPromotion.FormattingEnabled = true;
            cbPromotion.Location = new Point(90, 150);
            cbPromotion.Name = "cbPromotion";
            cbPromotion.Size = new Size(121, 23);
            cbPromotion.TabIndex = 4;
            cbPromotion.SelectedIndexChanged += cbPromotion_SelectedIndexChanged;
            // 
            // btnAjouter
            // 
            btnAjouter.Location = new Point(12, 415);
            btnAjouter.Name = "btnAjouter";
            btnAjouter.Size = new Size(75, 23);
            btnAjouter.TabIndex = 5;
            btnAjouter.Text = "Ajouter";
            btnAjouter.UseVisualStyleBackColor = true;
            btnAjouter.Click += btnAjouter_Click;
            // 
            // btnModifier
            // 
            btnModifier.Location = new Point(116, 415);
            btnModifier.Name = "btnModifier";
            btnModifier.Size = new Size(86, 23);
            btnModifier.TabIndex = 6;
            btnModifier.Text = "Modifier";
            btnModifier.UseVisualStyleBackColor = true;
            btnModifier.Click += btnModifier_Click;
            // 
            // btnSupprimer
            // 
            btnSupprimer.Location = new Point(221, 415);
            btnSupprimer.Name = "btnSupprimer";
            btnSupprimer.Size = new Size(98, 23);
            btnSupprimer.TabIndex = 7;
            btnSupprimer.Text = "Supprimer";
            btnSupprimer.UseVisualStyleBackColor = true;
            btnSupprimer.Click += btnSupprimer_Click;
            // 
            // btnExporter
            // 
            btnExporter.Location = new Point(347, 415);
            btnExporter.Name = "btnExporter";
            btnExporter.Size = new Size(89, 23);
            btnExporter.TabIndex = 8;
            btnExporter.Text = "Exporter";
            btnExporter.UseVisualStyleBackColor = true;
            btnExporter.Click += btnExporter_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(469, 415);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(75, 23);
            btnRefresh.TabIndex = 9;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblNom
            // 
            lblNom.AutoSize = true;
            lblNom.Location = new Point(0, 20);
            lblNom.Name = "lblNom";
            lblNom.Size = new Size(34, 15);
            lblNom.TabIndex = 10;
            lblNom.Text = "Nom";
            lblNom.Click += lblNom_Click;
            // 
            // lblPrenom
            // 
            lblPrenom.AutoSize = true;
            lblPrenom.Location = new Point(0, 61);
            lblPrenom.Name = "lblPrenom";
            lblPrenom.Size = new Size(49, 15);
            lblPrenom.TabIndex = 11;
            lblPrenom.Text = "Prenom";
            lblPrenom.Click += lblPrenom_Click;
            // 
            // lblGroupe
            // 
            lblGroupe.AutoSize = true;
            lblGroupe.Location = new Point(3, 107);
            lblGroupe.Name = "lblGroupe";
            lblGroupe.Size = new Size(46, 15);
            lblGroupe.TabIndex = 12;
            lblGroupe.Text = "Groupe";
            lblGroupe.Click += lblGroupe_Click;
            // 
            // lblPromotion
            // 
            lblPromotion.AutoSize = true;
            lblPromotion.Location = new Point(3, 150);
            lblPromotion.Name = "lblPromotion";
            lblPromotion.Size = new Size(64, 15);
            lblPromotion.TabIndex = 13;
            lblPromotion.Text = "Promotion";
            lblPromotion.Click += lblPromotion_Click;
            // 
            // btnRetour
            // 
            btnRetour.Location = new Point(596, 415);
            btnRetour.Name = "btnRetour";
            btnRetour.Size = new Size(75, 23);
            btnRetour.TabIndex = 14;
            btnRetour.Text = "Retour";
            btnRetour.UseVisualStyleBackColor = true;
            btnRetour.Click += btnRetour_Click_1;
            // 
            // FormGestionEtudiants
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRetour);
            Controls.Add(lblPromotion);
            Controls.Add(lblGroupe);
            Controls.Add(lblPrenom);
            Controls.Add(lblNom);
            Controls.Add(btnRefresh);
            Controls.Add(btnExporter);
            Controls.Add(btnSupprimer);
            Controls.Add(btnModifier);
            Controls.Add(btnAjouter);
            Controls.Add(cbPromotion);
            Controls.Add(cbGroupe);
            Controls.Add(txtPrenom);
            Controls.Add(txtNom);
            Controls.Add(dgvEtudiants);
            Name = "FormGestionEtudiants";
            Text = "FormGestionEtudiants";
            Load += FormGestionEtudiants_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEtudiants).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvEtudiants;
        private TextBox txtNom;
        private TextBox txtPrenom;
        private ComboBox cbGroupe;
        private ComboBox cbPromotion;
        private Button btnAjouter;
        private Button btnModifier;
        private Button btnSupprimer;
        private Button btnExporter;
        private Button btnRefresh;
        private Label lblNom;
        private Label lblPrenom;
        private Label lblGroupe;
        private Label lblPromotion;
        private Button btnRetour;
    }
}