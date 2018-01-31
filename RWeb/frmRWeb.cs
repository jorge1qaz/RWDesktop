using System;
using MetroFramework.Forms;
using BusinessLayer;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Globalization;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace RWeb
{
    public partial class frmRWeb : MetroForm
    {
        Paths paths = new Paths();
        Transferencia trans = new Transferencia();
        R_CuentasPendientes cuentasPendientes = new R_CuentasPendientes();
        Ejecucion ejecucion = new Ejecucion();
        VerificarInstancia verificarInstancia = new VerificarInstancia();
        R_MargenUtilidad margenUtilidad = new R_MargenUtilidad();
        R_MiNegocioAlDia miNegocioAlDia = new R_MiNegocioAlDia();
        R_EstadoDeResultadoPMS estadoDeResultadoPMS = new R_EstadoDeResultadoPMS();
        R_EstadosFinancieros estadosFinancieros = new R_EstadosFinancieros();
        R_FlujoCajaDetallado flujoCajaDetallado = new R_FlujoCajaDetallado();
        int deskHeight = 0;
        int deskWidth = 0;
        public frmRWeb()
        {
            InitializeComponent();
        }
        private void frmRWeb_Load(object sender, EventArgs e)
        {
            this.Size = new Size(331, 102);
            deskHeight = Screen.PrimaryScreen.Bounds.Height;
            deskWidth = Screen.PrimaryScreen.Bounds.Width;
            this.Location = new Point(deskWidth - this.Width, deskHeight - this.Height - 40);
            if (verificarInstancia.getPrevInstance())
            {
                this.WindowState = FormWindowState.Maximized;
                this.Close();
            }
            ejecucion.EventTimer(60, HideForm);
            try
            {
                if (trans.ComprobarAccesoInternet())
                    ejecucion.EventTimer(300, StartMassiveUpdate);
            }
            catch (Exception)
            {
                Application.ExitThread();
                this.Close();
            }
            btnMaximizar.Enabled = false;
        }
        private void HideForm(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;
        public void StartMassiveUpdate()
        {
            margenUtilidad.StartModule();
            cuentasPendientes.StartModule();
            miNegocioAlDia.StartModule();
            estadoDeResultadoPMS.StartModule();
            estadosFinancieros.StartModule();
            flujoCajaDetallado.StartModule();
        }
        public async void StartMassiveUpdate(object sender, EventArgs e)
        {
            btnCerrarSesion.Enabled = false;
            btnUpdateNow.Enabled = false;
            btnEmpresas.Enabled = false;
            Task task = new Task(() =>
            {
                margenUtilidad.StartModule();
                cuentasPendientes.StartModule();
                miNegocioAlDia.StartModule();
                estadoDeResultadoPMS.StartModule();
                estadosFinancieros.StartModule();
                flujoCajaDetallado.StartModule();
            });
            task.Start();
            lblProcessing.Text = "Procesando datos...";
            await task;
            lblProcessing.Text = "¡Procesamiento completado!";
            trans.StartTransfer(backgroundWorker);
        }
        private async void btnUpdateNow_Click(object sender, EventArgs e)
        {
            this.Size = new Size(331, 174);
            this.Location = new Point(deskWidth - this.Width, deskHeight - this.Height - 40);
            btnCerrarSesion.Enabled = false;
            btnUpdateNow.Enabled = false;
            btnEmpresas.Enabled = false;
            btnCerrar.Enabled = false;
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
            try
            {
                btnCerrar.Enabled = false;
            }
            catch (Exception)
            {
            }
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
            btnCerrar.Enabled = true;
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
            Size = new Size(129, 174);
            lblLastUpdate.Text = localDate.ToString(culture);
            lblNombreActualizacion.Text = "Última actualización: ";
            btnCerrar.Enabled = true;
            btnMaximizar.Enabled = true;
            Size = new Size(331, 174);
        }
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(paths.PathUser))
                    File.Delete(paths.PathUser);
                Application.Restart();
            }
            catch (Exception)
            {
                Application.Restart();
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.ExitThread();
        }
        private void btnEmpresas_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(paths.PathRUC))
                    File.Delete(paths.PathRUC);
                Application.Restart();
            }
            catch (Exception)
            {
                Application.Restart();
            }
        }
        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.Size = new Size(331, 174);
            this.Location = new Point(deskWidth - this.Width, deskHeight - this.Height - 40);
        }
        private void btnLinkWeb_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("http://licenciacontasis.net/ReportWeb/Acceso");
            }
            catch (Exception)
            {
                MessageBox.Show("No pudimos acceder al sitio web, intente más tarde o contacte con su administrador.", "Error de red", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}