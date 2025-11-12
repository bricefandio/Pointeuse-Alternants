namespace Pointeuse.DesktopGestion
{
    partial class FormLogin
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblUsername;
        private Label lblPassword;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnConnexion;
        private Button btnQuitter;

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
            lblUsername = new Label();
            lblPassword = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnConnexion = new Button();
            btnQuitter = new Button();
            SuspendLayout();

            // lblUsername
            lblUsername.AutoSize = true;
            lblUsername.Text = "Nom d’utilisateur :";
            lblUsername.Location = new Point(30, 30);

            // txtUsername
            txtUsername.Location = new Point(150, 27);
            txtUsername.Size = new Size(200, 23);

            // lblPassword
            lblPassword.AutoSize = true;
            lblPassword.Text = "Mot de passe :";
            lblPassword.Location = new Point(30, 70);

            // txtPassword
            txtPassword.Location = new Point(150, 67);
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(200, 23);

            // btnConnexion
            btnConnexion.Text = "Connexion";
            btnConnexion.Location = new Point(150, 110);
            btnConnexion.Click += btnConnexion_Click;

            // btnQuitter
            btnQuitter.Text = "Quitter";
            btnQuitter.Location = new Point(250, 110);
            btnQuitter.Click += btnQuitter_Click;

            // FormLogin
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 170);
            Controls.Add(lblUsername);
            Controls.Add(txtUsername);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(btnConnexion);
            Controls.Add(btnQuitter);
            Name = "FormLogin";
            Text = "Authentification";
            Load += FormLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
    }
}
