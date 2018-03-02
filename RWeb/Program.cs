using BusinessLayer;
using System;
using System.Windows.Forms;

namespace RWeb
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Paths paths = new Paths();
            Directorios directorios = new Directorios();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new pruebas());
            try
            {
                directorios.CreateDirectoryForRCP();
                //Comprueba si existe el path de la instancia de contasis
                if (paths.ComprobarExistenciaPathFile())
                {
                    // Comprueba si el usuario se ha logeado, por medio del txt con el correo del usuario
                    if (paths.ComprobarExistenciaPathFile(paths.PathUser))
                    {
                        if (paths.ComprobarExistenciaPathFile(paths.PathRUC))
                            Application.Run(new frmRWeb());
                        // Sí existen estos dos archivos, se procede a enviar al formulario principal
                        else
                            Application.Run(new frmEleccionEmpresa());
                    }
                    else
                        Application.Run(new frmLogin());
                }
                else
                {
                    if (paths.createPathFile())
                    {
                        //Existencia de user
                        if (paths.ComprobarExistenciaPathFile(paths.PathUser))
                        {
                            //Existe RUC
                            if (paths.ComprobarExistenciaPathFile(paths.PathRUC))
                                Application.Run(new frmRWeb());
                            //NO existe RUC
                            else
                                Application.Run(new frmEleccionEmpresa());
                        }
                        //NO existe user
                        else
                            Application.Run(new frmLogin());
                    }
                    else
                        Application.Exit();
                }
            }
            catch (Exception)
            {
                if (MessageBox.Show("Estimado usuario, hemos detectado que no tienes instalado el driver (Visual FoxPro ODBC Driver), pulsa el botón “Aceptar” para descargarlo, ejecútalo y vuelve a iniciar. En caso de que no se abra la ventana de descarga, descárguelo de forma manual en el siguiente enlace. \r" + paths.nameDomain + "/updates/vfpodbc.msi", "Error de driver", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    System.Diagnostics.Process.Start(paths.nameDomain + "/updates/vfpodbc.msi");
                    Application.Exit();
                    Application.ExitThread();
                }
                else
                {
                    Application.Exit();
                    Application.ExitThread();
                }
            }
        }
    }
}
