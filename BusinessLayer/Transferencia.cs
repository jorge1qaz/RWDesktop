using Ionic.Zip;
using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Security;
using System.Security.Permissions;
using System.Windows.Forms;

namespace BusinessLayer
{
    public class Transferencia
    {
        Paths paths = new Paths();
        //Jorge Luis|30/10/2017|RW-19
        /*Método general para la realización de la tranferencia de los datos compresos*/
        public void StartTransfer(BackgroundWorker backgroundWorker) {
            paths.WriteLastUpdate();
            if (ComprimirDirectorioCliente())
            {
                try
                {
                    if (Directory.Exists(paths.PathPrincipalDirectory + paths.PathRCP))
                        Directory.Delete(paths.PathPrincipalDirectory + paths.PathRCP, true);
                    if(Directory.Exists(paths.PathPrincipalDirectory + paths.PathMU))
                        Directory.Delete(paths.PathPrincipalDirectory + paths.PathMU, true);
                    SendZip(backgroundWorker);
                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudo enviar");
                }
            }
        }
        //Jorge Luis|30/10/2017|RW-19
        /*Método para eliminar los datos compresos*/
        public void DeleteZip()
        {
            File.Delete(paths.PathPrincipalDirectory + "/" + paths.readFile(paths.PathUser) + ".zip");
        }
        //Jorge Luis|30/10/2017|RW-19
        /*Método para comprimir, asignar contraseña y encriptar datos*/
        public bool ComprimirDirectorioCliente() {
            bool status = false;
            try
            {
                PermissionSet perms = new PermissionSet(null);
                perms.AddPermission(new UIPermission(PermissionState.Unrestricted));
                perms.AddPermission(new RegistryPermission(PermissionState.Unrestricted));
                /*empaqueta y encripta todos los archivos json generados*/            
                ZipFile zip = new ZipFile();
                FileInfo fileInfo = new FileInfo(paths.PathPrincipalDirectory);
                zip.Password = "reportesweb";
                zip.Encryption = EncryptionAlgorithm.WinZipAes256;
                zip.AddDirectory(paths.PathPrincipalDirectory);
                DirectoryInfo directoryInfo = new DirectoryInfo(paths.PathPrincipalDirectory);
                zip.Save(string.Format("{0}{1}.zip", paths.PathPrincipalDirectory, paths.readFile(paths.PathUser), FileMode.OpenOrCreate, FileAccess.ReadWrite));
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        //Jorge Luis|30/10/2017|RW-19
        /*Método para realizar la tranferencia por ftp*/
        public void DoWork(object sender, DoWorkEventArgs e, BackgroundWorker backgroundWorker)
        {            
            //string fileName = ((FtpSetting)e.Argument).FileName;
            string fullname = ((FtpSetting)e.Argument).FullName + ".zip";
            string fileName = paths.readFile(paths.PathUser) + ".zip";
            string userName = ((FtpSetting)e.Argument).UserName;
            string password = ((FtpSetting)e.Argument).Password;
            string server = ((FtpSetting)e.Argument).Server;
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(string.Format("{0}/{1}", server, fileName)));
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(userName, password);
            Stream ftpStream = request.GetRequestStream();
            FileStream fs = File.OpenRead(fullname);
            byte[] buffer = new byte[1024];
            double total = (double)fs.Length;
            int byteRead = 0;
            double read = 0;
            /*Mientras aun no se haya cancelado la transferencia, continua comprimiendo los archivos ademas de hacer un cálculo
             *matemático respecto a cuanto es su porcentaje de avance*/
            do
            {
                /*Ejecuta mientras no se cancele la transferecia*/
                if (!backgroundWorker.CancellationPending)
                {
                    byteRead = fs.Read(buffer, 0, 1024);
                    ftpStream.Write(buffer, 0, byteRead);
                    read += (double)byteRead;
                    double percentage = read / total * 100;
                    backgroundWorker.ReportProgress((int)percentage);
                }
            } while (byteRead != 0);
            fs.Close();
            ftpStream.Close();
        }
        //Jorge Luis|30/10/2017|RW-19
        /*Método para actualizar es estado de progreso de la transferencia*/
        public void ProgressChanged(object sender, ProgressChangedEventArgs e, Label lblEstadoProcesamiento, ProgressBar progressBar)
        {
            lblEstadoProcesamiento.Text = $"Procesando {e.ProgressPercentage} %";
            progressBar.Value = e.ProgressPercentage;
            progressBar.Update();
        }
        //Jorge Luis|30/10/2017|RW-19
        /*Método para comprobar el acceso a internet*/
        public bool ComprobarAccesoInternet()
        {
            try
            {
                IPHostEntry host = Dns.GetHostEntry("www.google.com");
                return  true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Jorge Luis|30/10/2017|RW-19
        /*Método para comprobar el acceso al servidor*/
        public bool ComprobarAccesoServidor(string URLServidor)
        {
            bool resultado = false;
            try
            {
                IPHostEntry host = Dns.GetHostEntry(URLServidor);
                resultado = true;
            }
            catch (Exception)
            {
                resultado = false;
            }
            return resultado;
        }
        FtpSetting _inputParameter = new FtpSetting();
        //Jorge Luis|30/10/2017|RW-19
        /*Método para instanciar los datos concernientes al ftp y lanzar el evento de transferencia*/
        public void SendZip(BackgroundWorker backgroundWorker)
        {
            _inputParameter.UserName = "jorge";
            _inputParameter.Password = "X@cH7k+t^aC[";
            _inputParameter.Server = "ftp://70.38.70.172/Datos/";
            _inputParameter.FileName = paths.readFile(paths.PathUser);
            _inputParameter.FullName = paths.PathPrincipalDirectory + "/" + paths.readFile(paths.PathUser);
            backgroundWorker.RunWorkerAsync(_inputParameter);
        }
    }
}