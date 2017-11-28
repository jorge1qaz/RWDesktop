using System.Diagnostics;

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
    }
}
