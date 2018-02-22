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
        AccesoDatos dat                 = new AccesoDatos();
        Paths paths                     = new Paths();
        frmRWeb frm                     = new frmRWeb();
        ComprobarTablas ct              = new ComprobarTablas();
        Captcha captcha                 = new Captcha();
        Transferencia trans             = new Transferencia();
        string numeroTemporal;
        bool captchaStateLocked         = false;
        static bool[] states            = new bool[2];
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
            this.BringToFront();
            txtEmail.Focus();
        }
        VerificarInstancia vf = new VerificarInstancia();
        private void btnOlvidoPassword_Click(object sender, EventArgs e)
        {
            Process.Start("http://licenciacontasis.net/ReportWeb/Perfiles/CambioPassword");
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Process.Start("http://licenciacontasis.net/reportweb/Perfiles/frmRegistroUsuario");
        }

        Int16 intentos = 0;
        private void btnIniciarSesion_Click(object sender, EventArgs e) => IniciarSesion();
        public void IniciarSesion() {
            if (trans.ComprobarAccesoInternet())
            {
                Cliente cliente = new Cliente()
                {
                    IdCliente = txtEmail.Text.ToString(),
                    Contrasenia = txtPassword.Text.ToString()
                };
                states = cliente.AuthenticateUser("RW_Security_authenticate_User");
                if (states[0])
                {
                    if (states[1])
                    {
                        if (ct.ComprobarExistenciaTablas(paths.PathUser))
                        {
                            File.Delete(paths.PathUser);
                            using (StreamWriter user = new StreamWriter(paths.PathUser, false))
                                user.WriteLine(txtEmail.Text.ToString().ToLower());
                            Application.Restart();
                        }
                        else
                        {
                            using (StreamWriter user = new StreamWriter(paths.PathUser, false))
                                user.WriteLine(txtEmail.Text.ToString().ToLower());
                            Application.Restart();
                        }
                    }
                    else
                        MessageBox.Show("Tu cuenta no esta activada, por favor revisa tu correo. ", "Falla de activación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("El usuario o contraseña es incorrecto. ", "Falla de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intentos++;
                    if (intentos >= 3)
                    {
                        this.Size = new Size(526, 324);
                        tlpCaptcha.Visible = true;
                        btnIniciarSesion.Enabled = false;
                        numeroTemporal = captcha.CargarCaptcha(picCaptcha).ToString();
                        captchaStateLocked = true;
                        txtCaptcha.Focus();
                    }
                }
            }
            else
            {
                MessageBox.Show("No cuentas con acceso a internet, vuelve a intentarlo más tarde.", "Falla de red", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnVerificarCaptcha_Click(object sender, EventArgs e) => VerificarCaptcha();
        public void VerificarCaptcha() {
            if (txtCaptcha.Text == numeroTemporal)
            {
                tlpCaptcha.Visible = false;
                btnIniciarSesion.Enabled = true;
                this.Size = new Size(526, 280);
                intentos = 0;
                captchaStateLocked = false;
                txtEmail.Focus();
            }
            else
                MessageBox.Show("El código ingresado no es el correcto. Sí no recuerda su contraseña le recomendamos que haga clic sobre el botón 'olvidé mi contraseña' para restaurarla. ", "Error de captcha", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                txtPassword.Focus(); 
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                if (!captchaStateLocked)
                    IniciarSesion();
        }

        private void txtCaptcha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                VerificarCaptcha();
        }
    }
}
