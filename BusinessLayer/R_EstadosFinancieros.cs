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
            ExportTable(pathSaveFile, pathConnection, "A630", "CCOD_BAL2", "A630", "CCOD_BALN2", true); ExportTable(pathSaveFile, pathConnection, "P105", "CCOD_BAL2", "P105", "CCOD_BALN2", false);
            ExportTable(pathSaveFile, pathConnection, "P110", "CCOD_BAL2", "P110", "CCOD_BALN2", false); ExportTable(pathSaveFile, pathConnection, "P120", "CCOD_BAL2", "P120", "CCOD_BALN2", false);
            ExportTable(pathSaveFile, pathConnection, "P121", "CCOD_BAL2", "P121", "CCOD_BALN2", false); ExportTable(pathSaveFile, pathConnection, "P123", "CCOD_BAL2", "P123", "CCOD_BALN2", false);
            ExportTable(pathSaveFile, pathConnection, "P125", "CCOD_BAL2", "P125", "CCOD_BALN2", false); ExportTable(pathSaveFile, pathConnection, "P130", "CCOD_BAL2", "P130", "CCOD_BALN2", false);
            ExportTable(pathSaveFile, pathConnection, "P135", "CCOD_BAL2", "P135", "CCOD_BALN2", false); ExportTable(pathSaveFile, pathConnection, "P137", "CCOD_BAL2", "P137", "CCOD_BALN2", false);
            ExportTable(pathSaveFile, pathConnection, "P210", "CCOD_BAL2", "P210", "CCOD_BALN2", false); ExportTable(pathSaveFile, pathConnection, "P410", "CCOD_BAL2", "P410", "CCOD_BALN2", false);
            ExportTable(pathSaveFile, pathConnection, "P415", "CCOD_BAL2", "P415", "CCOD_BALN2", false); ExportTable(pathSaveFile, pathConnection, "P420", "CCOD_BAL2", "P420", "CCOD_BALN2", false);
            ExportTable(pathSaveFile, pathConnection, "P425", "CCOD_BAL2", "P425", "CCOD_BALN2", false); ExportTable(pathSaveFile, pathConnection, "P430", "CCOD_BAL2", "P430", "CCOD_BALN2", false);
            ExportTable(pathSaveFile, pathConnection, "P435", "CCOD_BAL2", "P435", "CCOD_BALN2", false); ExportTable(pathSaveFile, pathConnection, "P440", "CCOD_BAL2", "P440", "CCOD_BALN2", false);
            ExportTable(pathSaveFile, pathConnection, "P445", "CCOD_BAL2", "P445", "CCOD_BALN2", false); ExportTable(pathSaveFile, pathConnection, "P450", "CCOD_BAL2", "P450", "CCOD_BALN2", false);
            ExportTable(pathSaveFile, pathConnection, "P805", "CCOD_BAL2", "P805", "CCOD_BALN2", false); ExportTable(pathSaveFile, pathConnection, "P810", "CCOD_BAL2", "P810", "CCOD_BALN2", false);
            ExportTable(pathSaveFile, pathConnection, "P815", "CCOD_BAL2", "P815", "CCOD_BALN2", false); ExportTable(pathSaveFile, pathConnection, "P820", "CCOD_BAL2", "P820", "CCOD_BALN2", false);
            ExportTable(pathSaveFile, pathConnection, "P830", "CCOD_BAL2", "P830", "CCOD_BALN2", false); ExportTable(pathSaveFile, pathConnection, "P835", "CCOD_BAL2", "P835", "CCOD_BALN2", false);
            ExportTable(pathSaveFile, pathConnection, "P840", "CCOD_BAL2", "P840", "CCOD_BALN2", false);

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
