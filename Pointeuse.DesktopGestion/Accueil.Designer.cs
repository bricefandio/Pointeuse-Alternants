namespace Pointeuse.DesktopGestion
{
    partial class Accueil
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
            btnGroupes = new Button();
            btnEtudiants = new Button();
            btnPromotions = new Button();
            SuspendLayout();
            // 
            // btnGroupes
            // 
            btnGroupes.Location = new Point(67, 176);
            btnGroupes.Name = "btnGroupes";
            btnGroupes.Size = new Size(75, 23);
            btnGroupes.TabIndex = 0;
            btnGroupes.Text = "Groupes";
            btnGroupes.UseVisualStyleBackColor = true;
            btnGroupes.Click += btnGroupe_Click;
            // 
            // btnEtudiants
            // 
            btnEtudiants.Location = new Point(350, 176);
            btnEtudiants.Name = "btnEtudiants";
            btnEtudiants.Size = new Size(75, 23);
            btnEtudiants.TabIndex = 1;
            btnEtudiants.Text = "Etudiants";
            btnEtudiants.UseVisualStyleBackColor = true;
            btnEtudiants.Click += btnEtudiants_Click;
            // 
            // btnPromotions
            // 
            btnPromotions.Location = new Point(628, 176);
            btnPromotions.Name = "btnPromotions";
            btnPromotions.Size = new Size(83, 23);
            btnPromotions.TabIndex = 2;
            btnPromotions.Text = "Promotions";
            btnPromotions.UseVisualStyleBackColor = true;
            btnPromotions.Click += btnPromotions_Click;
            // 
            // Accueil
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnPromotions);
            Controls.Add(btnEtudiants);
            Controls.Add(btnGroupes);
            Name = "Accueil";
            Text = "Accueil";
            Load += Accueil_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnGroupes;
        private Button btnEtudiants;
        private Button btnPromotions;
    }
}