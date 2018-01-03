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
            ExportTable(pathSaveFile, pathConnection, "N005", true);            // Haber = 7
            ExportTable(pathSaveFile, pathConnection, "N010", false);           // Debe  = 6
            ExportTable(pathSaveFile, pathConnection, "N015", false);
            ExportTable(pathSaveFile, pathConnection, "N099", true);
            ExportTable(pathSaveFile, pathConnection, "N103", true);
            ExportTable(pathSaveFile, pathConnection, "N105", true);
            ExportTable(pathSaveFile, pathConnection, "N110", true);
            ExportTable(pathSaveFile, pathConnection, "N205", false);
            ExportTable(pathSaveFile, pathConnection, "N210", false);
            ExportTable(pathSaveFile, pathConnection, "N215", false);
            ExportTable(pathSaveFile, pathConnection, "N220", false);
            ExportTable(pathSaveFile, pathConnection, "N225", false);
            ExportTable(pathSaveFile, pathConnection, "N230", false);
            ExportTable(pathSaveFile, pathConnection, "N235", false);
            ExportTable(pathSaveFile, pathConnection, "N305", true);
            ExportTable(pathSaveFile, pathConnection, "N310", false);
            ExportTable(pathSaveFile, pathConnection, "N315", false);
            ExportTable(pathSaveFile, pathConnection, "N405", true);
            ExportTable(pathSaveFile, pathConnection, "N410", true);
            ExportTable(pathSaveFile, pathConnection, "N415", true);
            ExportTable(pathSaveFile, pathConnection, "N420", false);
            ExportTable(pathSaveFile, pathConnection, "N425", false);
            ExportTable(pathSaveFile, pathConnection, "N430", false);
            ExportTable(pathSaveFile, pathConnection, "N505", true);
            ExportTable(pathSaveFile, pathConnection, "N510", false);
            ExportTable(pathSaveFile, pathConnection, "N515", true);
            ExportTable(pathSaveFile, pathConnection, "N520");                  // Tiene las clases: 6 y 7
            ExportTable(pathSaveFile, pathConnection, "N525", false);
            ExportTable(pathSaveFile, pathConnection, "N805", false);
            ExportTable(pathSaveFile, pathConnection, "N810", false);

            ExportTable(pathSaveFile, pathConnection, "F005", "CCOD_BAL", true);// Filtro distinto
            ExportTable(pathSaveFile, pathConnection, "F105", false);
            ExportTable(pathSaveFile, pathConnection, "F206", false);
            ExportTable(pathSaveFile, pathConnection, "F211", false);
            ExportTable(pathSaveFile, pathConnection, "F212", true);
            ExportTable(pathSaveFile, pathConnection, "F213", true);
            ExportTable(pathSaveFile, pathConnection, "F214", false);
            ExportTable(pathSaveFile, pathConnection, "F215", true);
            
            ExportTable(pathSaveFile, pathConnection, "F320", true);
            ExportTable(pathSaveFile, pathConnection, "F350", false);
            ExportTable(pathSaveFile, pathConnection, "F380", true);
            ExportTable(pathSaveFile, pathConnection, "F403", true);
            ExportTable(pathSaveFile, pathConnection, "F405", true);
            ExportTable(pathSaveFile, pathConnection, "F415");
            ExportTable(pathSaveFile, pathConnection, "F710", false);
            ExportTable(pathSaveFile, pathConnection, "F805", false);
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
        public void ExportTable(string pathSaveFile, string pathConnection, string idRubro, string filter, bool tipoOperacion)
        {
            DataSet dataSet = new DataSet();
            DataTable table = new DataTable();
            for (Int16 i = 0; i <= 12; i++)
            {
                table = consb.TableForEstadoResultado(@pathConnection, idRubro, i, filter, tipoOperacion);
                dataSet.Tables.Add(table);
                dataSet.Tables[i].TableName = i.ToString();
            }
            using (StreamWriter jsonFile = new StreamWriter(pathSaveFile + idRubro + ".json", false))
                jsonFile.WriteLine(JsonConvert.SerializeObject(dataSet, Formatting.None).ToString().Replace("  ", ""));
            dataSet.Clear();
        }
    }
}
