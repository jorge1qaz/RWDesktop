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
                CreateBigQueryEachOne();
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
        public void CreateBigQueryEachOne() {

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
                    jsonListaCuentas.WriteLine(JsonConvert.SerializeObject(dsReporte, Formatting.None).ToString().Replace("  ", ""));
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
                    jsonListaCuentas.WriteLine(JsonConvert.SerializeObject(dsReporte, Formatting.None).ToString().Replace("  ", ""));
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
                jsonListaCuentas.WriteLine(JsonConvert.SerializeObject(dsListaCuentas, Formatting.None).ToString().Replace("  ", ""));
        }
    }
}