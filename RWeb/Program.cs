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
            if (paths.ComprobarExistenciaPathFile())
            {
                if (paths.ComprobarExistenciaPathFile(paths.PathUser))
                    Application.Run(new frmRWeb());
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
