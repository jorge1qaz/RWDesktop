using Newtonsoft.Json;
using System;
using System.Data;
using System.IO;

namespace BusinessLayer
{
    public class R_EstadoDeResultadoPMS
    {
        AccesoDatos dat = new AccesoDatos();
        Paths paths = new Paths();
        Consultas cons = new Consultas();
        Consultasb consb = new Consultasb();
        Transferencia trans = new Transferencia();
        Directorios dirs = new Directorios();

        //Jorge Luis|02/01/2018|RW-103
        /*Método para generar  listas de las diversas consultas*/
        public void StartModule()
        {
            DataTable listDB = new DataTable();
            listDB = cons.CheckDataBaseConta();
            foreach (DataRow item in listDB.Rows)
            {
                if (File.Exists(item[4].ToString() + "/DIARIO.DBF"))
                {
                    dirs.CreateDirectory(paths.PathEDRPMS + "/" + item[0].ToString().Trim() + "/" + item[2].ToString().Trim());
                    CreateBigQueryEachOne(paths.PathPrincipalDirectory + paths.PathEDRPMS + "/" + item[0].ToString().Trim() + "/" + item[2].ToString().Trim() + "/", item[4].ToString().Trim());
                }
            }
        }
        //Jorge Luis|02/01/2018|RW-103
        /*Método para generar  listas de las diversas consultas*/
        public void CreateBigQueryEachOne(string pathSaveFile, string pathConnection)
        {
            ExportTable(pathSaveFile, pathConnection, "N005", "CCOD_BAL2", "CCOD_BAL2");   // Haber = 7
            ExportTable(pathSaveFile, pathConnection, "N010", "CCOD_BAL2", "CCOD_BAL2");  // Debe  = 6
            ExportTable(pathSaveFile, pathConnection, "N015", "CCOD_BAL2", "CCOD_BAL2");  //invierte
            ExportTable(pathSaveFile, pathConnection, "N099", "CCOD_BAL2", "CCOD_BAL2");
            ExportTable(pathSaveFile, pathConnection, "N103", "CCOD_BAL2", "CCOD_BAL2");
            ExportTable(pathSaveFile, pathConnection, "N105", "CCOD_BAL2", "CCOD_BAL2");
            ExportTable(pathSaveFile, pathConnection, "N110", "CCOD_BAL2", "CCOD_BAL2");
            ExportTable(pathSaveFile, pathConnection, "N205", "CCOD_BAL2", "CCOD_BAL2");
            ExportTable(pathSaveFile, pathConnection, "N210", "CCOD_BAL2", "CCOD_BAL2");
            ExportTable(pathSaveFile, pathConnection, "N215", "CCOD_BAL2", "CCOD_BAL2");
            ExportTable(pathSaveFile, pathConnection, "N220", "CCOD_BAL2", "CCOD_BAL2");
            ExportTable(pathSaveFile, pathConnection, "N225", "CCOD_BAL2", "CCOD_BAL2");
            ExportTable(pathSaveFile, pathConnection, "N230", "CCOD_BAL2", "CCOD_BAL2");
            ExportTable(pathSaveFile, pathConnection, "N235", "CCOD_BAL2", "CCOD_BAL2");
            ExportTable(pathSaveFile, pathConnection, "N305", "CCOD_BAL2", "CCOD_BAL2");
            ExportTable(pathSaveFile, pathConnection, "N310", "CCOD_BAL2", "CCOD_BAL2");
            ExportTable(pathSaveFile, pathConnection, "N315", "CCOD_BAL2", "CCOD_BAL2");
            ExportTable(pathSaveFile, pathConnection, "N405", "CCOD_BAL2", "CCOD_BAL2");
            ExportTable(pathSaveFile, pathConnection, "N410", "CCOD_BAL2", "CCOD_BAL2");
            ExportTable(pathSaveFile, pathConnection, "N415", "CCOD_BAL2", "CCOD_BAL2");
            ExportTable(pathSaveFile, pathConnection, "N420", "CCOD_BAL2", "CCOD_BAL2");
            ExportTable(pathSaveFile, pathConnection, "N425", "CCOD_BAL2", "CCOD_BAL2");
            ExportTable(pathSaveFile, pathConnection, "N430", "CCOD_BAL2", "CCOD_BAL2");
            ExportTable(pathSaveFile, pathConnection, "N505", "CCOD_BAL2", "CCOD_BAL2");
            ExportTable(pathSaveFile, pathConnection, "N510", "CCOD_BAL2", "CCOD_BAL2");
            ExportTable(pathSaveFile, pathConnection, "N515", "CCOD_BAL2", "CCOD_BAL2");
            ExportTable(pathSaveFile, pathConnection, "N520", "CCOD_BAL2", "CCOD_BAL2");   // Tiene las clases: 6 y 7
            ExportTable(pathSaveFile, pathConnection, "N525", "CCOD_BAL2", "CCOD_BAL2");
            ExportTable(pathSaveFile, pathConnection, "N805", "CCOD_BAL2", "CCOD_BAL2");
            ExportTable(pathSaveFile, pathConnection, "N810", "CCOD_BAL2", "CCOD_BAL2");

            ExportTable(pathSaveFile, pathConnection, "F005", "CCOD_BAL", "CCOD_BAL");    // Filtro distinto
            ExportTable(pathSaveFile, pathConnection, "F105", "CCOD_BAL2", "CCOD_BAL2");
            ExportTable(pathSaveFile, pathConnection, "F206", "CCOD_BAL2", "CCOD_BAL2");
            ExportTable(pathSaveFile, pathConnection, "F211", "CCOD_BAL2", "CCOD_BAL2");
            ExportTable(pathSaveFile, pathConnection, "F212", "CCOD_BAL2", "CCOD_BAL2");
            ExportTable(pathSaveFile, pathConnection, "F213", "CCOD_BAL2", "CCOD_BAL2");
            ExportTable(pathSaveFile, pathConnection, "F214", "CCOD_BAL2", "CCOD_BAL2");
            ExportTable(pathSaveFile, pathConnection, "F215", "CCOD_BAL2", "CCOD_BAL2");

            ExportTable(pathSaveFile, pathConnection, "F320", "CCOD_BAL2", "CCOD_BAL2");
            ExportTable(pathSaveFile, pathConnection, "F350", "CCOD_BAL2", "CCOD_BAL2");
            ExportTable(pathSaveFile, pathConnection, "F380", "CCOD_BAL2", "CCOD_BAL2");
            ExportTable(pathSaveFile, pathConnection, "F403", "CCOD_BAL2", "CCOD_BAL2");
            ExportTable(pathSaveFile, pathConnection, "F405", "CCOD_BAL2", "CCOD_BAL2");
            ExportTable(pathSaveFile, pathConnection, "F415", "CCOD_BAL2", "CCOD_BAL2");
            ExportTable(pathSaveFile, pathConnection, "F710", "CCOD_BAL2", "CCOD_BALR");
            ExportTable(pathSaveFile, pathConnection, "F805", "CCOD_BAL2", "CCOD_BAL2");
        }
        //Jorge Luis|02/01/2018|RW-103
        /*Método ...*/
        public void ExportTable(string pathSaveFile, string pathConnection, string idRubro, bool tipoOperacion)
        {
            DataSet dataSet = new DataSet();
            DataTable table = new DataTable();
            for (Int16 i = 0; i <= 15; i++)
            {
                table = consb.TableForEstadoResultado(@pathConnection, idRubro, i, tipoOperacion);
                dataSet.Tables.Add(table);
                dataSet.Tables[i].TableName = i.ToString();
            }
            using (StreamWriter jsonFile = new StreamWriter(pathSaveFile + idRubro + ".json", false))
                jsonFile.WriteLine(JsonConvert.SerializeObject(dataSet, Formatting.None).ToString().Replace("  ", ""));
            dataSet.Clear();
        }
        //Jorge Luis|18/12/2017|RW-103
        /*Método ...*/
        public void ExportTable(string pathSaveFile, string pathConnection, string idRubro)
        {
            DataSet dataSet = new DataSet();
            DataTable table = new DataTable();
            for (Int16 i = 0; i <= 12; i++)
            {
                table = consb.TableForEstadoResultado(@pathConnection, idRubro, i);
                dataSet.Tables.Add(table);
                dataSet.Tables[i].TableName = i.ToString();
            }
            using (StreamWriter jsonFile = new StreamWriter(pathSaveFile + idRubro + ".json", false))
                jsonFile.WriteLine(JsonConvert.SerializeObject(dataSet, Formatting.None).ToString().Replace("  ", ""));
            dataSet.Clear();
        }
        //Jorge Luis|18/12/2017|RW-103
        /*Método ...*/
        public void ExportTable(string pathSaveFile, string pathConnection, string idRubro, string filter1, string filter2)
        {
            DataSet dataSet = new DataSet();
            DataTable table = new DataTable();
            table = consb.TableForEstadoResultado(@pathConnection, idRubro, filter1, filter2);
            dataSet.Tables.Add(table);
            dataSet.Tables[0].TableName = "data";
            using (StreamWriter jsonFile = new StreamWriter(pathSaveFile + idRubro + ".json", false))
                jsonFile.WriteLine(JsonConvert.SerializeObject(dataSet, Formatting.None).ToString().Replace("  ", ""));
            dataSet.Clear();
        }
    }
}
