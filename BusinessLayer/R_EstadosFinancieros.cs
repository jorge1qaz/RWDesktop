using Newtonsoft.Json;
using System;
using System.Data;
using System.IO;

namespace BusinessLayer
{
    public class R_EstadosFinancieros
    {
        AccesoDatos dat = new AccesoDatos();
        Paths paths = new Paths();
        Consultas cons = new Consultas();
        Consultasb consb = new Consultasb();
        Transferencia trans = new Transferencia();
        Directorios dirs = new Directorios();
        //Jorge Luis|09/01/2018|RW-109
        /*Método para generar  listas de las diversas consultas*/
        public void StartModule()
        {
            DataTable listDB = new DataTable();
            listDB = cons.CheckDataBaseConta();
            foreach (DataRow item in listDB.Rows)
            {
                if (File.Exists(item[4].ToString() + "/DIARIO.DBF"))
                {
                    dirs.CreateDirectory(paths.PathREF + "/" + item[0].ToString().Trim() + "/" + item[2].ToString().Trim());
                    CreateBigQueryEachOne(paths.PathPrincipalDirectory + paths.PathREF + "/" + item[0].ToString().Trim() + "/" + item[2].ToString().Trim() + "/", item[4].ToString().Trim());
                }
            }
        }
        //Jorge Luis|09/01/2018|RW-109
        /*Método para generar  listas de las diversas consultas*/
        public void CreateBigQueryEachOne(string pathSaveFile, string pathConnection)
        {
            ExportTable(pathSaveFile, pathConnection, "A105", "CCOD_BAL2", "A105", "CCOD_BALN2", true); ExportTable(pathSaveFile, pathConnection, "A110", "CCOD_BAL2", "A110", "CCOD_BALN2", true);
            ExportTable(pathSaveFile, pathConnection, "A115", "CCOD_BAL2", "A115", "CCOD_BALN2", true); ExportTable(pathSaveFile, pathConnection, "A120", "CCOD_BAL2", "A120", "CCOD_BALN2", true);
            ExportTable(pathSaveFile, pathConnection, "A125", "CCOD_BAL2", "A125", "CCOD_BALN2", true); ExportTable(pathSaveFile, pathConnection, "A128", "CCOD_BAL2", "A128", "CCOD_BALN2", true);
            ExportTable(pathSaveFile, pathConnection, "A130", "CCOD_BAL2", "A130", "CCOD_BALN2", true); ExportTable(pathSaveFile, pathConnection, "A131", "CCOD_BAL2", "A131", "CCOD_BALN2", true);
            ExportTable(pathSaveFile, pathConnection, "A133", "CCOD_BAL2", "A133", "CCOD_BALN2", true); ExportTable(pathSaveFile, pathConnection, "A140", "CCOD_BAL2", "A140", "CCOD_BALN2", true);
            ExportTable(pathSaveFile, pathConnection, "A210", "CCOD_BAL2", "A210", "CCOD_BALN2", true); ExportTable(pathSaveFile, pathConnection, "A220", "CCOD_BAL2", "A220", "CCOD_BALN2", true);
            ExportTable(pathSaveFile, pathConnection, "A510", "CCOD_BAL2", "A510", "CCOD_BALN2", true); ExportTable(pathSaveFile, pathConnection, "A513", "CCOD_BAL2", "A513", "CCOD_BALN2", true);
            ExportTable(pathSaveFile, pathConnection, "A515", "CCOD_BAL2", "A515", "CCOD_BALN2", true); ExportTable(pathSaveFile, pathConnection, "A517", "CCOD_BAL2", "A517", "CCOD_BALN2", true);
            ExportTable(pathSaveFile, pathConnection, "A520", "CCOD_BAL2", "A520", "CCOD_BALN2", true); ExportTable(pathSaveFile, pathConnection, "A525", "CCOD_BAL2", "A525", "CCOD_BALN2", true);
            ExportTable(pathSaveFile, pathConnection, "A530", "CCOD_BAL2", "A530", "CCOD_BALN2", true); ExportTable(pathSaveFile, pathConnection, "A540", "CCOD_BAL2", "A540", "CCOD_BALN2", true);
            ExportTable(pathSaveFile, pathConnection, "A550", "CCOD_BAL2", "A550", "CCOD_BALN2", true); ExportTable(pathSaveFile, pathConnection, "A560", "CCOD_BAL2", "A560", "CCOD_BALN2", true);
            ExportTable(pathSaveFile, pathConnection, "A570", "CCOD_BAL2", "A570", "CCOD_BALN2", true); ExportTable(pathSaveFile, pathConnection, "A575", "CCOD_BAL2", "A575", "CCOD_BALN2", true);
            ExportTable(pathSaveFile, pathConnection, "A580", "CCOD_BAL2", "A580", "CCOD_BALN2", true); ExportTable(pathSaveFile, pathConnection, "A610", "CCOD_BAL2", "A610", "CCOD_BALN2", true);
            ExportTable(pathSaveFile, pathConnection, "A630", "CCOD_BAL2", "A630", "CCOD_BALN2", true);

            ExportTable(pathSaveFile, pathConnection, "A105", "CCOD_BAL2", true);


        }
        //Jorge Luis|09/01/2018|RW-109
        /*Método ...*/
        public void ExportTable(string pathSaveFile, string pathConnection, string idRubro, string filter, bool tipoOperacion)
        {
            DataSet dataSet = new DataSet();
            DataTable table = new DataTable();
            table = consb.GetTotalMonthByRubro(@pathConnection, idRubro, filter, tipoOperacion);
            dataSet.Tables.Add(table);
            dataSet.Tables[0].TableName = "data";
            using (StreamWriter jsonFile = new StreamWriter(pathSaveFile + idRubro + ".json", false))
                jsonFile.WriteLine(JsonConvert.SerializeObject(dataSet, Formatting.None).ToString().Replace("  ", ""));
            dataSet.Clear();
        }
        //Jorge Luis|10/01/2018|RW-109
        /*Método ...*/
        public void ExportTable(string pathSaveFile, string pathConnection, string idRubro1, string filter1, string idRubro2, string filter2, bool tipoOperacion)
        {
            DataSet dataSet = new DataSet();
            DataTable table = new DataTable();
            table = consb.GetTotalMonthByRubro(@pathConnection, idRubro1, filter1, idRubro2, filter2, tipoOperacion);
            dataSet.Tables.Add(table);
            dataSet.Tables[0].TableName = "data";
            using (StreamWriter jsonFile = new StreamWriter(pathSaveFile + idRubro1 + ".json", false))
                jsonFile.WriteLine(JsonConvert.SerializeObject(dataSet, Formatting.None).ToString().Replace("  ", ""));
            dataSet.Clear();
        }
    }
}
