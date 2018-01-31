namespace RWeb
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.imgLogo = new System.Windows.Forms.PictureBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.btnRegistrarse = new MetroFramework.Controls.MetroButton();
            this.btnIniciarSesion = new MetroFramework.Controls.MetroButton();
            this.txtPassword = new MetroFramework.Controls.MetroTextBox();
            this.txtEmail = new MetroFramework.Controls.MetroTextBox();
            this.btnOlvidoPassword = new MetroFramework.Controls.MetroLink();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tlpCaptcha = new System.Windows.Forms.TableLayoutPanel();
            this.picCaptcha = new System.Windows.Forms.PictureBox();
            this.lblAdvertencia = new MetroFramework.Controls.MetroLabel();
            this.txtCaptcha = new MetroFramework.Controls.MetroTextBox();
            this.btnVerificarCaptcha = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tlpCaptcha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCaptcha)).BeginInit();
            this.SuspendLayout();
            // 
            // imgLogo
            // 
            this.imgLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.imgLogo.Image = global::RWeb.Properties.Resources.logo;
            this.imgLogo.Location = new System.Drawing.Point(20, 60);
            this.imgLogo.Name = "imgLogo";
            this.imgLogo.Size = new System.Drawing.Size(486, 67);
            this.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgLogo.TabIndex = 0;
            this.imgLogo.TabStop = false;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroLabel1.Location = new System.Drawing.Point(3, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(179, 32);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Correo electrónico";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroLabel2.Location = new System.Drawing.Point(3, 32);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(179, 33);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "Contraseña";
            this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnRegistrarse
            // 
            this.btnRegistrarse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrarse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRegistrarse.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnRegistrarse.Location = new System.Drawing.Point(3, 94);
            this.btnRegistrarse.Name = "btnRegistrarse";
            this.btnRegistrarse.Size = new System.Drawing.Size(179, 29);
            this.btnRegistrarse.TabIndex = 4;
            this.btnRegistrarse.Text = "Registrarse";
            this.btnRegistrarse.UseSelectable = true;
            this.btnRegistrarse.Click += new System.EventHandler(this.btnRegistrarse_Click);
            // 
            // btnIniciarSesion
            // 
            this.btnIniciarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIniciarSesion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnIniciarSesion.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnIniciarSesion.Location = new System.Drawing.Point(188, 94);
            this.btnIniciarSesion.Name = "btnIniciarSesion";
            this.btnIniciarSesion.Size = new System.Drawing.Size(295, 29);
            this.btnIniciarSesion.TabIndex = 3;
            this.btnIniciarSesion.Text = "Iniciar sesión";
            this.btnIniciarSesion.UseSelectable = true;
            this.btnIniciarSesion.Click += new System.EventHandler(this.btnIniciarSesion_Click);
            // 
            // txtPassword
            // 
            // 
            // 
            // 
            this.txtPassword.CustomButton.Image = null;
            this.txtPassword.CustomButton.Location = new System.Drawing.Point(269, 1);
            this.txtPassword.CustomButton.Name = "";
            this.txtPassword.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPassword.CustomButton.TabIndex = 1;
            this.txtPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPassword.CustomButton.UseSelectable = true;
            this.txtPassword.CustomButton.Visible = false;
            this.txtPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPassword.Lines = new string[0];
            this.txtPassword.Location = new System.Drawing.Point(188, 35);
            this.txtPassword.MaxLength = 32767;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPassword.SelectedText = "";
            this.txtPassword.SelectionLength = 0;
            this.txtPassword.SelectionStart = 0;
            this.txtPassword.ShortcutsEnabled = true;
            this.txtPassword.Size = new System.Drawing.Size(295, 27);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseSelectable = true;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // txtEmail
            // 
            // 
            // 
            // 
            this.txtEmail.CustomButton.Image = null;
            this.txtEmail.CustomButton.Location = new System.Drawing.Point(271, 2);
            this.txtEmail.CustomButton.Name = "";
            this.txtEmail.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtEmail.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtEmail.CustomButton.TabIndex = 1;
            this.txtEmail.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtEmail.CustomButton.UseSelectable = true;
            this.txtEmail.CustomButton.Visible = false;
            this.txtEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEmail.Lines = new string[0];
            this.txtEmail.Location = new System.Drawing.Point(188, 3);
            this.txtEmail.MaxLength = 32767;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtEmail.SelectedText = "";
            this.txtEmail.SelectionLength = 0;
            this.txtEmail.SelectionStart = 0;
            this.txtEmail.ShortcutsEnabled = true;
            this.txtEmail.Size = new System.Drawing.Size(295, 26);
            this.txtEmail.TabIndex = 1;
            this.txtEmail.UseSelectable = true;
            this.txtEmail.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtEmail.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmail_KeyPress);
            // 
            // btnOlvidoPassword
            // 
            this.btnOlvidoPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOlvidoPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOlvidoPassword.Location = new System.Drawing.Point(188, 68);
            this.btnOlvidoPassword.Name = "btnOlvidoPassword";
            this.btnOlvidoPassword.Size = new System.Drawing.Size(295, 20);
            this.btnOlvidoPassword.TabIndex = 7;
            this.btnOlvidoPassword.Text = "¿Olvidó su contraseña?";
            this.btnOlvidoPassword.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnOlvidoPassword.UseSelectable = true;
            this.btnOlvidoPassword.Click += new System.EventHandler(this.btnOlvidoPassword_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.06585F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.93415F));
            this.tableLayoutPanel1.Controls.Add(this.metroLabel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnIniciarSesion, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnOlvidoPassword, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnRegistrarse, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.metroLabel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtPassword, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtEmail, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 127);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.29578F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.70422F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(486, 126);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // tlpCaptcha
            // 
            this.tlpCaptcha.ColumnCount = 3;
            this.tlpCaptcha.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.46988F));
            this.tlpCaptcha.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.53012F));
            this.tlpCaptcha.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tlpCaptcha.Controls.Add(this.picCaptcha, 0, 1);
            this.tlpCaptcha.Controls.Add(this.lblAdvertencia, 0, 0);
            this.tlpCaptcha.Controls.Add(this.txtCaptcha, 1, 1);
            this.tlpCaptcha.Controls.Add(this.btnVerificarCaptcha, 2, 1);
            this.tlpCaptcha.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpCaptcha.Location = new System.Drawing.Point(20, 253);
            this.tlpCaptcha.Name = "tlpCaptcha";
            this.tlpCaptcha.RowCount = 2;
            this.tlpCaptcha.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.54839F));
            this.tlpCaptcha.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.45161F));
            this.tlpCaptcha.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCaptcha.Size = new System.Drawing.Size(486, 62);
            this.tlpCaptcha.TabIndex = 8;
            // 
            // picCaptcha
            // 
            this.picCaptcha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCaptcha.Location = new System.Drawing.Point(3, 30);
            this.picCaptcha.Name = "picCaptcha";
            this.picCaptcha.Size = new System.Drawing.Size(179, 29);
            this.picCaptcha.TabIndex = 11;
            this.picCaptcha.TabStop = false;
            // 
            // lblAdvertencia
            // 
            this.lblAdvertencia.AutoSize = true;
            this.tlpCaptcha.SetColumnSpan(this.lblAdvertencia, 3);
            this.lblAdvertencia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAdvertencia.ForeColor = System.Drawing.Color.Red;
            this.lblAdvertencia.Location = new System.Drawing.Point(3, 0);
            this.lblAdvertencia.Name = "lblAdvertencia";
            this.lblAdvertencia.Size = new System.Drawing.Size(480, 27);
            this.lblAdvertencia.Style = MetroFramework.MetroColorStyle.Orange;
            this.lblAdvertencia.TabIndex = 14;
            this.lblAdvertencia.Text = "Límite de intentos fallidos, escribe los números de la parte inferior.";
            this.lblAdvertencia.UseCustomBackColor = true;
            this.lblAdvertencia.UseCustomForeColor = true;
            this.lblAdvertencia.UseStyleColors = true;
            // 
            // txtCaptcha
            // 
            // 
            // 
            // 
            this.txtCaptcha.CustomButton.Image = null;
            this.txtCaptcha.CustomButton.Location = new System.Drawing.Point(170, 1);
            this.txtCaptcha.CustomButton.Name = "";
            this.txtCaptcha.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtCaptcha.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCaptcha.CustomButton.TabIndex = 1;
            this.txtCaptcha.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCaptcha.CustomButton.UseSelectable = true;
            this.txtCaptcha.CustomButton.Visible = false;
            this.txtCaptcha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCaptcha.Lines = new string[0];
            this.txtCaptcha.Location = new System.Drawing.Point(188, 30);
            this.txtCaptcha.MaxLength = 32767;
            this.txtCaptcha.Name = "txtCaptcha";
            this.txtCaptcha.PasswordChar = '●';
            this.txtCaptcha.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCaptcha.SelectedText = "";
            this.txtCaptcha.SelectionLength = 0;
            this.txtCaptcha.SelectionStart = 0;
            this.txtCaptcha.ShortcutsEnabled = true;
            this.txtCaptcha.Size = new System.Drawing.Size(198, 29);
            this.txtCaptcha.TabIndex = 12;
            this.txtCaptcha.UseSelectable = true;
            this.txtCaptcha.UseSystemPasswordChar = true;
            this.txtCaptcha.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCaptcha.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtCaptcha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCaptcha_KeyPress);
            // 
            // btnVerificarCaptcha
            // 
            this.btnVerificarCaptcha.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerificarCaptcha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnVerificarCaptcha.Location = new System.Drawing.Point(392, 30);
            this.btnVerificarCaptcha.Name = "btnVerificarCaptcha";
            this.btnVerificarCaptcha.Size = new System.Drawing.Size(91, 29);
            this.btnVerificarCaptcha.TabIndex = 15;
            this.btnVerificarCaptcha.Text = "Verificar";
            this.btnVerificarCaptcha.UseSelectable = true;
            this.btnVerificarCaptcha.Click += new System.EventHandler(this.btnVerificarCaptcha_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 335);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.imgLogo);
            this.Controls.Add(this.tlpCaptcha);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmLogin";
            this.Opacity = 0.88D;
            this.Text = "Bienvenido al sistema de reportes web";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tlpCaptcha.ResumeLayout(false);
            this.tlpCaptcha.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCaptcha)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imgLogo;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton btnRegistrarse;
        private MetroFramework.Controls.MetroButton btnIniciarSesion;
        private MetroFramework.Controls.MetroTextBox txtPassword;
        private MetroFramework.Controls.MetroTextBox txtEmail;
        private MetroFramework.Controls.MetroLink btnOlvidoPassword;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tlpCaptcha;
        private MetroFramework.Controls.MetroTextBox txtCaptcha;
        private System.Windows.Forms.PictureBox picCaptcha;
        private MetroFramework.Controls.MetroLabel lblAdvertencia;
        private MetroFramework.Controls.MetroButton btnVerificarCaptcha;
    }
}