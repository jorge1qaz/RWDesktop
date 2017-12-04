using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BusinessLayer
{
    public class VerificarInstancia
    {
        //Jorge Luis|06/11/2017|RW-19
        /*Método para comprobar si la la aplicación ya esta en ejecución*/
        public bool getPrevInstance()
        {
            string currPrsName = Process.GetCurrentProcess().ProcessName;
            bool Running = false;
            /*Obtiene el nombre de todos los procesos con el mismo nombre de este proceso*/
            Process[] allProcessWithThisName = Process.GetProcessesByName(currPrsName);

            /*Si más de un proceso esta corriendo, retorna true. Lo que significa
            que la aplicación ya esta en ejecución*/
            if (allProcessWithThisName.Length > 1)
                Running = true;
            return Running;
        }
        //Jorge Luis|01/12/2017|RW-19
        /*Método para crear una estructura de directorios del cliente*/
        public List<string> getInstanceContasis()
        {
            List<string> listIdCompany = new List<string>();
            try
            {
                string dirPath = @"C:/";
                var dirs = from dir in Directory.EnumerateDirectories(dirPath, "Contasis*") select dir;
                foreach (var dir in dirs)
                    listIdCompany.Add(dir.Substring(dir.LastIndexOf("\\") + 1));
            }
            catch (UnauthorizedAccessException UAEx)
            {
                MessageBox.Show(UAEx.Message.ToString(), "Error en la comprobación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (PathTooLongException PathEx)
            {
                MessageBox.Show(PathEx.Message.ToString(), "Error en la comprobación, ruta demasiado larga.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return listIdCompany;
        }
    }
}
