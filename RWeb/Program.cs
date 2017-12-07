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
    }
}
