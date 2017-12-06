using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace BusinessLayer
{
    public class R_CuentasPendientes
    {
        //Jorge Luis|16/10/2017|RW-19
        /*Método general para el procesamiento de datos, calculos, bucles y generación de json*/
        public void StartModule()
        {
            //directorios.CreateDirectoryForRCP();
            directorios.CheckDataBaseContaJson();
            /*Comprueba la existencia del txt con la instancia de Contasis, de encontrarlo procede a generar
             el método principal que realiza todos los bucles. */
            if (paths.ComprobarExistenciaPathFile())
            {
                //paths.ListYearsJson();
                //directorios.CreateDirectoryStructureForRCP();
                CreateBigQueryEachOneAlter();
            }
            else
            {
                /*De no encontrar la ruta procede pide al usuario le proporcione el path*/
                if (paths.createPathFile())
                {
                    //paths.ListYearsJson();
                    directorios.CreateDirectoryStructureForRCP();
                }
                else
                    Application.Exit();
            }
        }
        AccesoDatos dat = new AccesoDatos();
        Paths paths = new Paths();
        Consultas cons = new Consultas();
        Directorios directorios = new Directorios();
        ComprobarTablas comptablas = new ComprobarTablas();
        Transferencia trans = new Transferencia();

        public void CreateBigQueryEachOneAlter() {

            DataTable listDB = new DataTable();
            listDB = cons.CheckDataBaseConta();
            DataRow[] currentRows = listDB.Select(null, null, DataViewRowState.CurrentRows);
            foreach (DataRow item in currentRows)
            {
                if (File.Exists(item[4].ToString() + "/DIARIO.DBF"))
                {
                    directorios.CreateDirectory(paths.PathRCP + "/" + item[0].ToString().Trim());
                    directorios.CreateDirectory(paths.PathRCP + "/" + item[0].ToString().Trim() + "/" + item[2].ToString().Trim());
                    ListaCuentasFiltrada(paths.PathPrincipalDirectory + paths.PathRCP + item[0].ToString().Trim() + "/" + item[2].ToString().Trim() + "/", item[4].ToString().Trim());
                    RecorrerListaCuentasTipo1(paths.PathPrincipalDirectory + paths.PathRCP + item[0].ToString().Trim() + "/" + item[2].ToString().Trim() + "/", item[4].ToString().Trim());
                    RecorrerListaCuentasTipo2(paths.PathPrincipalDirectory + paths.PathRCP + item[0].ToString().Trim() + "/" + item[2].ToString().Trim() + "/", item[4].ToString().Trim());
                }
            }


        }

        //Jorge Luis|13/10/2017|RW-19
        /*Método para generar json recorriendo meses y para las cuentas que sean activos*/
        public void StartUpdateTipo1(string idCuenta, string pathDirectory, string pathConectionSU)
        {
            /*Recorre y crea  archivos json de acuerdo a los 12 meses, para activos*/
            for (Int16 i = 0; i <= 12; i++)
            {
                DataSet dsReporte = new DataSet();
                DataTable datos = new DataTable();
                datos = cons.GetReporteCuentasPendientesByMesTipo1(idCuenta, i, pathConectionSU);
                dsReporte.Tables.Add(datos);
                dsReporte.Tables[0].TableName = "data";
                using (StreamWriter jsonListaCuentas = new StreamWriter(pathDirectory + idCuenta.Trim() + "ReporteCP" + i + ".json", false))
                {
                    jsonListaCuentas.WriteLine(JsonConvert.SerializeObject(dsReporte, Formatting.Indented).ToString().Replace("  ", ""));
                }
            }
        }
        //Jorge Luis|13/10/2017|RW-19
        /*Método para generar json recorriendo meses y para las cuentas que sean pasivos*/
        public void StartUpdateTipo2(string idCuenta, string pathDirectory, string pathConectionSU)
        {
            /*Recorre y crea  archivos json de acuerdo a los 12 meses, para pasivos*/
            for (Int16 i = 0; i <= 12; i++)
            {
                DataSet dsReporte = new DataSet();
                DataTable datos = new DataTable();
                datos = cons.GetReporteCuentasPendientesByMesTipo2(idCuenta, i, pathConectionSU);
                dsReporte.Tables.Add(datos);
                dsReporte.Tables[0].TableName = "data";
                using (StreamWriter jsonListaCuentas = new StreamWriter(pathDirectory + idCuenta.Trim() + "ReporteCP" + i + ".json", false))
                {
                    jsonListaCuentas.WriteLine(JsonConvert.SerializeObject(dsReporte, Formatting.Indented).ToString().Replace("  ", ""));
                }
            }
        }
        //Jorge Luis|12/10/2017|RW-19
        /*Método para generar json recorriendo cuentas y para las cuentas que sean activos*/
        public void RecorrerListaCuentasTipo1(string pathDir, string pathConectionRL)
        {
            DataTable datos = new DataTable();
            datos = cons.ListCuentasTipo1(pathConectionRL);
            int totalCuentas = datos.Rows.Count;
            DataRow[] currentRows = datos.Select(null, null, DataViewRowState.CurrentRows);
            /*Recorre y crea  archivos json de acuerdo a la lista de cuentas encontrada en las bases de datos, para activos*/
            foreach (DataRow row in currentRows)
                StartUpdateTipo1(row[0].ToString(), pathDir, pathConectionRL);
        }
        //Jorge Luis|12/10/2017|RW-19
        /*Método para generar json recorriendo cuentas y para las cuentas que sean pasivos*/
        public void RecorrerListaCuentasTipo2(string pathDir, string pathConectionRL)
        {
            DataTable datos = new DataTable();
            datos = cons.ListCuentasTipo2(pathConectionRL);
            int totalCuentas = datos.Rows.Count;
            DataRow[] currentRows = datos.Select(null, null, DataViewRowState.CurrentRows);
            /*Recorre y crea  archivos json de acuerdo a la lista de cuentas encontrada en las bases de datos, para pasivos*/
            foreach (DataRow row in currentRows)
                StartUpdateTipo2(row[0].ToString(), pathDir, pathConectionRL);
        }
        //Jorge Luis|12/10/2017|RW-19
        /*Método para generar json recorriendo cuentas y para las cuentas que sean activos*/
        public void ListaCuentasFiltrada(string path, string pathDirList)
        {
            DataSet dsListaCuentas = new DataSet();
            DataTable datos = new DataTable();
            datos = cons.ListCuentas(pathDirList);
            dsListaCuentas.Tables.Add(datos);
            dsListaCuentas.Tables[0].TableName = "data";
            /*Recorre y crea  archivos json de acuerdo a las cuentas que existen en la base de datos*/
            using (StreamWriter jsonListaCuentas = new StreamWriter(path + "ListaCuentas.json", false))
            {
                jsonListaCuentas.WriteLine(JsonConvert.SerializeObject(dsListaCuentas, Formatting.Indented).ToString().Replace("  ", ""));
            }
        }
        //Jorge Luis|12/10/2017|RW-19
        /*Método general para realizar los procesamientos de cálculos matemáticos y generación de json, de todas las bases de datos en todas 
         las empresas y para todos los años*/
        public void CreateBigQueryEachOne()
        {
            DataTable datos = new DataTable();
            datos = cons.ListCompanies();
            int totalCuentas = datos.Rows.Count;
            DataRow[] currentRows = datos.Select(null, null, DataViewRowState.CurrentRows);
            /*Recorre y genera todas las consultas en base a la lista de empresas*/
            foreach (DataRow row in currentRows)
                RecorrerEmpresas(row[0].ToString());
        }
        //Jorge Luis|12/10/2017|RW-19
        /*Método recorrer empresas con un parámetro, esto hace que se ejecuten los métodos mas importantes que cumplen con la función de todos los 
         procesamientos: generar json y cálculos matemáticos*/
        public void RecorrerEmpresas(string idCompany)
        {
            List<string> aniosValidos = new List<string>();
            aniosValidos = paths.listAnios();
            /*Recorre todas las consultas en base a los años válidos y les pasa dos parámetros, la ruta de su base de datos, y hacía donde 
             tienen que generar los archivos json*/
            foreach (var item in aniosValidos)
            {
                DataTable datos = new DataTable();
                datos = cons.ListDetailsForCompany(idCompany, item[0].ToString() + item[1].ToString() + item[2].ToString() + item[3].ToString());
                int totalCuen = datos.Rows.Count;
                DataRow[] currentRows = datos.Select(null, null, DataViewRowState.CurrentRows);
                /*pasa los dos parámetros a las 3 principales consultas*/
                foreach (DataRow row in currentRows)
                {
                    ListaCuentasFiltrada(paths.PathPrincipalDirectory + paths.PathRCP + idCompany + "/" + row[0].ToString() + "/", row[2].ToString());
                    RecorrerListaCuentasTipo1(paths.PathPrincipalDirectory + paths.PathRCP + idCompany + "/" + row[0].ToString() + "/", row[2].ToString());
                    RecorrerListaCuentasTipo2(paths.PathPrincipalDirectory + paths.PathRCP + idCompany + "/" + row[0].ToString() + "/", row[2].ToString());
                }
            }
        }
    }
}