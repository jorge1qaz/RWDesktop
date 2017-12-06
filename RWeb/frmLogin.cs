using BusinessLayer;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RWeb
{
    public partial class frmLogin : MetroFramework.Forms.MetroForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        AccesoDatos dat = new AccesoDatos();
        Paths paths = new Paths();
        frmRWeb frm = new frmRWeb();
        ComprobarTablas ct = new ComprobarTablas();
        Captcha captcha = new Captcha();
        Transferencia trans = new Transferencia();
        string numeroTemporal;
        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            tlpCaptcha.Visible = false;
            this.Size = new Size(526, 280);
            if (vf.getPrevInstance())
            {
                this.WindowState = FormWindowState.Maximized;
                this.Close();
            }
        }
        VerificarInstancia vf = new VerificarInstancia();
        private void btnOlvidoPassword_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.google.com");
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Process.Start("http://licenciacontasis.net/reportweb/Perfiles/frmRegistroUsuario");
        }

        Int16 intentos = 0;
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            if (trans.ComprobarAccesoInternet())
            {
                Cliente cliente = new Cliente()
                {
                    IdCliente = txtEmail.Text.ToString(),
                    Contrasenia = txtPassword.Text.ToString()
                };
                if (cliente.AuthenticateUser("RW_Security_authenticate_User"))
                {
                    if (ct.ComprobarExistenciaTablas(paths.PathUser))
                    {
                        File.Delete(paths.PathUser);
                        using (StreamWriter user = new StreamWriter(paths.PathUser, false))
                        {
                            user.WriteLine(txtEmail.Text.ToString());
                        }
                        frm.Show();
                        this.Hide();
                    }
                    else
                    {
                        using (StreamWriter user = new StreamWriter(paths.PathUser, false))
                        {
                            user.WriteLine(txtEmail.Text.ToString());
                        }
                        frm.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("El usuario o contraseña es incorrecto. ", "Falla de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intentos++;
                    if (intentos > 3)
                    {
                        this.Size = new Size(526, 324);
                        tlpCaptcha.Visible = true;
                        btnIniciarSesion.Enabled = false;
                        numeroTemporal = captcha.CargarCaptcha(picCaptcha).ToString();
                    }
                }
            }
            else
            {
                MessageBox.Show("No cuentas con acceso a internet, vuelve a intentarlo más tarde.", "Falla de red", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
             
        }
        private void btnVerificarCaptcha_Click(object sender, EventArgs e)
        {
            if (txtCaptcha.Text == numeroTemporal)
            {
                tlpCaptcha.Visible = false;
                btnIniciarSesion.Enabled = true;
                this.Size = new Size(526, 280);
                intentos = 0;
            }
        }
    }
}
