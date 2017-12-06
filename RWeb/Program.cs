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

            directorios.CreateDirectoryForRCP();
            //Comprueba si existe el path de la instancia de contasis
            if (paths.ComprobarExistenciaPathFile())
            {
                // Comprueba si el usuario se ha logeado, por medio del txt con el correo del usuario
                if (paths.ComprobarExistenciaPathFile(paths.PathUser))
                    Application.Run(new frmRWeb());
                // Sí existen estos dos archivos, se procede a enviar al formulario principal
                else
                    Application.Run(new frmLogin());
            }
            else
            {
                if (paths.createPathFile())
                {
                    paths.ListYearsJson();
                    MessageBox.Show("Ruta correcta", "Comprobación de ruta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (paths.ComprobarExistenciaPathFile(paths.PathUser))
                        Application.Run(new frmRWeb());
                    else
                        Application.Run(new frmLogin());
                }
                else
                    Application.Exit();
            }
        }
    }
}
