using System.IO;

namespace BusinessLayer
{
    public class ComprobarTablas
    {
        //Jorge Luis|03/11/2017|RW-19
        /*Método para comprobar la existencia de una tabla DBF, con una ruta única*/
        public bool ComprobarExistenciaTablas(string rutaDirectorio)
        {
            bool resultado = false;
            string Path1 = @"" + rutaDirectorio;
            /*Comprueba el path*/
            if (File.Exists(Path1))
                resultado = true;
            return resultado;
        }
        //Jorge Luis|27/10/2017|RW-19
        /*Método para comprobar la existencia de una tabla DBF*/
        public bool ComprobarExistenciaTablas(string rutaDirectorio, string tabla1)
        {
            bool resultado = false;
            string Path1 = @"" + rutaDirectorio + "/" + tabla1;
            /*Comprueba el path*/
            if (File.Exists(Path1))
                resultado = true;
            return resultado;
        }
        //Jorge Luis|27/10/2017|RW-19
        /*Método para comprobar la existencia de dos tablas DBF*/
        public bool ComprobarExistenciaTablas(string rutaDirectorio, string tabla1, string tabla2)
        {
            bool resultado = false;
            string Path1 = @"" + rutaDirectorio + "/" + tabla1;
            string Path2 = @"" + rutaDirectorio + "/" + tabla1;
            /*Comprueba dos paths*/
            if (File.Exists(Path1) && File.Exists(Path2))
                resultado = true;
            return resultado;
        }
        //Jorge Luis|27/10/2017|RW-19
        /*Método para comprobar la existencia de tres tablas DBF*/
        public bool ComprobarExistenciaTablas(string rutaDirectorio, string tabla1, string tabla2, string tabla3)
        {
            bool resultado = false;
            string Path1 = @"" + rutaDirectorio + "/" + tabla1;
            string Path2 = @"" + rutaDirectorio + "/" + tabla1;
            string Path3 = @"" + rutaDirectorio + "/" + tabla3;
            /*Comprueba tres paths*/
            if (File.Exists(Path1) && File.Exists(Path2) && File.Exists(Path3))
                resultado = true;
            return resultado;
        }
        //Jorge Luis|27/10/2017|RW-19
        /*Método para comprobar la existencia de cuatro tablas DBF*/
        public bool ComprobarExistenciaTablas(string rutaDirectorio, string tabla1, string tabla2, string tabla3, string tabla4)
        {
            bool resultado = false;
            string Path1 = @"" + rutaDirectorio + "/" + tabla1;
            string Path2 = @"" + rutaDirectorio + "/" + tabla1;
            string Path3 = @"" + rutaDirectorio + "/" + tabla3;
            string Path4 = @"" + rutaDirectorio + "/" + tabla4;
            /*Comprueba cuatro paths*/
            if (File.Exists(Path1) && File.Exists(Path2) && File.Exists(Path3) && File.Exists(Path4))
                resultado = true;
            return resultado;
        }
        //Jorge Luis|27/10/2017|RW-19
        /*Método para comprobar la existencia de cinco tablas DBF*/
        public bool ComprobarExistenciaTablas(string rutaDirectorio, string tabla1, string tabla2, string tabla3, string tabla4, string tabla5)
        {
            bool resultado = false;
            string Path1 = @"" + rutaDirectorio + "/" + tabla1;
            string Path2 = @"" + rutaDirectorio + "/" + tabla1;
            string Path3 = @"" + rutaDirectorio + "/" + tabla3;
            string Path4 = @"" + rutaDirectorio + "/" + tabla4;
            string Path5 = @"" + rutaDirectorio + "/" + tabla5;
            /*Comprueba cinco paths*/
            if (File.Exists(Path1) && File.Exists(Path2) && File.Exists(Path3) && File.Exists(Path4) && File.Exists(Path5))
                resultado = true;
            return resultado;
        }
    }
}
