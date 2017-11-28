using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace BusinessLayer
{
    public class Directorios
    {
        AccesoDatos dat = new AccesoDatos();
        Paths paths = new Paths();
        Consultas cons = new Consultas();
        //Jorge Luis|25/10/2017|RW-19
        /*Método para crear una estructura compleja de directorios*/
        public void CreateDirectoryStructureForRCP()
        {
            DataTable datos = new DataTable();
            datos = cons.ListCompanies();
            int totalCuentas = datos.Rows.Count;
            DataRow[] currentRows = datos.Select(null, null, DataViewRowState.CurrentRows);
            /*Recorre todas las empresas en base a la lista de compañias*/
            foreach (DataRow row in currentRows)
                RecorrerEmpresas(row[0].ToString());
        }
        //Jorge Luis|25/10/2017|RW-19
        /*Método para recorrer las empresas registradas*/
        public void RecorrerEmpresas(string idCompany)
        {
            DataTable datos = new DataTable();
            datos = cons.ListDetailsForCompany(idCompany);
            int totalCuen = datos.Rows.Count;
            DataRow[] currentRows = datos.Select(null, null, DataViewRowState.CurrentRows);
            /*Recorre y crea directorios todas las empresas en base a la lista detallada de compañias*/
            foreach (DataRow row in currentRows)
            {
                CreateDirectoryForRCP(row[1].ToString(), row[0].ToString());
            }
        }
        //Jorge Luis|25/10/2017|RW-19
        /*Método para crear directorios en base a las empresas y años que existen en el sistema contable*/
        public void CreateDirectoryForRCP(string company, string year)
        {
            /*Siempre en cuando NO exista el directorio destinado para los reportes de cuentas pendiente,
             se realiza la creación, conjuntamente se fija las propiedades para ocultar los directorios*/
            if (!Directory.Exists(paths.PathPrincipalDirectory + paths.PathRCP + company + "/" + year))
            {
                Directory.CreateDirectory(paths.PathPrincipalDirectory + paths.PathRCP + company + "/" + year);
                File.SetAttributes(paths.PathPrincipalDirectory + paths.PathRCP + company, FileAttributes.Hidden);
                File.SetAttributes(paths.PathPrincipalDirectory + paths.PathRCP + company + "/" + year, FileAttributes.Hidden);
            }
        }
        //Jorge Luis|25/10/2017|RW-19
        /*Método para crear una estructura simple de directorios*/
        public void CreateDirectoryForRCP()
        {
            /*Siempre en cuando NO exista el directorio general 'C:/rptsGnrl/' se crea este directorio.*/
            if (!Directory.Exists(paths.PathPrincipalDirectory + paths.PathRCP))
            {
                Directory.CreateDirectory(paths.PathPrincipalDirectory + paths.PathRCP);
                File.SetAttributes(paths.PathPrincipalDirectory, FileAttributes.Hidden);
                File.SetAttributes(paths.PathPrincipalDirectory + paths.PathRCP, FileAttributes.Hidden);
            }
        }
        //Jorge Luis|27/11/2017|RW-19
        /*Método para crear una estructura simple de directorios, con un parámetro*/
        public void CreateDirectory(string nameDirectory)
        {
            /*Siempre en cuando NO exista el directorio general 'C:/rptsGnrl/' se crea este directorio.*/
            if (Directory.Exists(paths.PathPrincipalDirectory))
            {
                Directory.CreateDirectory(paths.PathPrincipalDirectory + "/" + nameDirectory);
                File.SetAttributes(paths.PathPrincipalDirectory, FileAttributes.Hidden);
                File.SetAttributes(paths.PathPrincipalDirectory + "/" + nameDirectory, FileAttributes.Hidden);
            }
        }
        //Jorge Luis|27/11/2017|RW-19
        /*Método para crear una lista discriminatoria, con las rutas que tengan datos coherentes para la genereación de consultas*/
        public List<string> CheckDataBaseConta()
        {
            List<string> databases = new List<string>();
            DataTable listDB = new DataTable();
            listDB = cons.ListDataBaseConta();
            DataRow[] currentRows = listDB.Select(null, null, DataViewRowState.CurrentRows);
            foreach (DataRow item in currentRows)
            {
                if (File.Exists(item[0].ToString() + "/DIARIO.DBF"))
                    databases.Add(item[0].ToString());
            }
            return databases;
        }
        //Jorge Luis|27/11/2017|RW-19
        /*Método para crear una lista discriminatoria, con las rutas que tengan datos coherentes para la genereación de consultas*/
        public List<string> CheckDataBaseStock()
        {
            List<string> databases = new List<string>();
            DataTable listDB = new DataTable();
            listDB = cons.ListDataBaseStock();
            DataRow[] currentRows = listDB.Select(null, null, DataViewRowState.CurrentRows);
            foreach (DataRow item in currentRows)
            {
                if (File.Exists(item[0].ToString() + "/VENTASL.DBF"))
                    databases.Add(item[0].ToString());
            }
            return databases;
        }
    }
}
