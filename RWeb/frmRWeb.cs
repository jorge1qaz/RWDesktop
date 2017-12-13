using System;
using MetroFramework.Forms;
using BusinessLayer;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Globalization;
using System.Threading.Tasks;

namespace RWeb
{
    public partial class frmRWeb : MetroForm
    {
        public frmRWeb()
        {
            InitializeComponent();
        }
        private void frmRWeb_Load(object sender, EventArgs e)
        {
            this.Size = new Size(331, 102);
            int deskHeight = Screen.PrimaryScreen.Bounds.Height;
            int deskWidth = Screen.PrimaryScreen.Bounds.Width;
            this.Location = new Point(deskWidth - this.Width, deskHeight - this.Height - 40);
            if (vf.getPrevInstance())
            {
                this.WindowState = FormWindowState.Maximized;
                this.Close();
            }
            ex.EventTimer(60, HideForm);
            if (trans.ComprobarAccesoInternet())
                ex.EventTimer(300, StartMassiveUpdate);
        }
        private void HideForm(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        Paths paths = new Paths();
        Transferencia trans = new Transferencia();
        R_CuentasPendientes rcp = new R_CuentasPendientes();
        Ejecucion ex = new Ejecucion();
        VerificarInstancia vf = new VerificarInstancia();
        R_MargenUtilidad margenUtilidad = new R_MargenUtilidad();
        public void StartMassiveUpdate()
        {
            this.Size = new Size(331, 154);
            int deskHeight = Screen.PrimaryScreen.Bounds.Height;
            int deskWidth = Screen.PrimaryScreen.Bounds.Width;
            this.Location = new Point(deskWidth - this.Width, deskHeight - this.Height - 40);
            margenUtilidad.StartModule();
            rcp.StartModule();
        }
        public async void StartMassiveUpdate(object sender, EventArgs e)
        {
            this.Size = new Size(331, 154);
            int deskHeight = Screen.PrimaryScreen.Bounds.Height;
            int deskWidth = Screen.PrimaryScreen.Bounds.Width;
            this.Location = new Point(deskWidth - this.Width, deskHeight - this.Height - 40);
            btnCerrarSesion.Enabled = false;
            btnUpdateNow.Enabled = false;
            btnEmpresas.Enabled = false;
            Task task = new Task(() =>
            {
                margenUtilidad.StartModule();
                rcp.StartModule();
            });
            task.Start();
            lblProcessing.Text = "Procesando datos...";
            await task;
            lblProcessing.Text = "¡Procesamiento completado!";
            trans.StartTransfer(backgroundWorker);
        }
        private async void btnUpdateNow_Click(object sender, EventArgs e)
        {
            this.Size = new Size(331, 154);
            int deskHeight = Screen.PrimaryScreen.Bounds.Height;
            int deskWidth = Screen.PrimaryScreen.Bounds.Width;
            this.Location = new Point(deskWidth - this.Width, deskHeight - this.Height - 40);
            btnCerrarSesion.Enabled = false;
            btnUpdateNow.Enabled = false;
            btnEmpresas.Enabled = false;
            Task task = new Task(StartMassiveUpdate);
            task.Start();
            lblProcessing.Text = "Procesando datos...";
            await task;
            lblProcessing.Text = "¡Procesamiento completado!";
            trans.StartTransfer(backgroundWorker);
        }
        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            trans.DoWork(sender, e, backgroundWorker);
        }
        private void backgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            trans.ProgressChanged(sender, e, lblProcessing, progressbar);
        }
        private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            trans.DeleteZip();
            btnCerrarSesion.Enabled = true;
            btnUpdateNow.Enabled = true;
            btnEmpresas.Enabled = true;
            if ((e.Cancelled == true))
                this.lblProcessing.Text = "Cancelado!";
            else if (!(e.Error == null))
                this.lblProcessing.Text = ("Error: " + e.Error.Message);
            else
                this.lblProcessing.Text = "¡Actualización completada! Revise su navegador.";
            DateTime localDate = DateTime.Now;
            String cultureName = "en-GB";
            var culture = new CultureInfo(cultureName);
            localDate.ToString(culture);
            lblLastUpdate.Text = localDate.ToString(culture);
            this.Size = new Size(331, 174);
            int deskHeight = Screen.PrimaryScreen.Bounds.Height;
            int deskWidth = Screen.PrimaryScreen.Bounds.Width;
            this.Location = new Point(deskWidth - this.Width, deskHeight - this.Height - 60);
        }
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            if (File.Exists(paths.PathUser))
                File.Delete(paths.PathUser);
            Application.Restart();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.ExitThread();
        }
        private void btnEmpresas_Click(object sender, EventArgs e)
        {
            if (File.Exists(paths.PathRUC))
                File.Delete(paths.PathRUC);
            Application.Restart();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.Size = new Size(331, 174);
            int deskHeight = Screen.PrimaryScreen.Bounds.Height;
            int deskWidth = Screen.PrimaryScreen.Bounds.Width;
            this.Location = new Point(deskWidth - this.Width, deskHeight - this.Height - 60);
        }
    }
}