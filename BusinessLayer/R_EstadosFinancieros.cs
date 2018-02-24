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
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A105", true, "1"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A110", true, "1");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A115", true, "1"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A120", true, "1");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A125", true, "1"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A128", true, "1");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A130", true, "1"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A131", true, "1");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A133", true, "1"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A140", true, "1");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A210", true, "1"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A220", true, "1");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A510", true, "1"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A513", true, "1");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A515", true, "1"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A517", true, "1");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A520", true, "1"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A525", true, "1");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A530", true, "1"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A540", true, "1");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A550", true, "1"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A560", true, "1");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A570", true, "1"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A575", true, "1");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A580", true, "1"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A610", true, "1");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A630", true, "1"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P105", false, "1");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P110", false, "1"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P120", false, "1");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P121", false, "1"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P123", false, "1");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P125", false, "1"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P130", false, "1");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P135", false, "1"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P137", false, "1");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P210", false, "1"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P410", false, "1");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P415", false, "1"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P420", false, "1");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P425", false, "1"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P430", false, "1");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P435", false, "1"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P440", false, "1");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P445", false, "1"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P450", false, "1");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P805", false, "1"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P810", false, "1");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P815", false, "1"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P820", false, "1");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P830", false, "1"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P835", false, "1");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P840", false, "1");

            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A105", true, "3"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A106", true, "3");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A110", true, "3"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A111", true, "3");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A115", true, "3"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A120", true, "3");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A121", true, "3"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A122", true, "3");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A123", true, "3"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A124", true, "3");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A125", true, "3"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A130", true, "3");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A135", true, "3"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A140", true, "3");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A142", true, "3"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A145", true, "3");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A151", true, "3"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A152", true, "3");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A153", true, "3"); ExportTable(pathSaveFile, pathConnection, "CCOD_BALN", "CCOD_BALN", "A155", true, "3");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A157", true, "3"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A158", true, "3");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A159", true, "3"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A160", true, "3");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A164", true, "3"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A176", true, "3");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A177", true, "3"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A178", true, "3");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A179", true, "3"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A180", true, "3");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A185", true, "3");

            ExportTable(pathSaveFile, pathConnection, "CCOD_BALN2", "CCOD_BALN2", "P105", false, "3"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "P110", false, "3");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "P115", false, "3"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "P541", false, "3");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "P120", false, "3"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "P121", false, "3");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "P122", false, "3"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "P128", false, "3");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "P129", false, "3"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "P133", false, "3");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "P135", false, "3"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "P141", false, "3");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "P505", false, "3"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "P507", false, "3");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "P510", false, "3"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "P511", false, "3");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "P515", false, "3"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "P520", false, "3");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "P530", false, "3"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "P531", false, "3");

            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "F005", true, "4"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "F010", false, "4");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "F115", false, "4"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "F205", false, "4");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "F210", false, "4"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "F502", false, "4");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "F505", true, "4"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "F510", true, "4");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "F515", true, "4"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "F520", true, "4");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "F525", false, "4"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "F530", false, "4");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "F560", false, "4"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "F605", false, "4");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "F705", false, "4");
        }
        //Jorge Luis|10/01/2018|RW-109
        /*Método ...*/
        public void ExportTable(string pathSaveFile, string pathConnection, string filter1, string filter2, string idRubro, bool tipoOperacion, string nameDistinction)
        {
            DataSet dataSet = new DataSet();
            DataTable table = new DataTable();
            table = consb.GetTotalMonthByRubro(@pathConnection, filter1, filter2, idRubro, tipoOperacion);
            dataSet.Tables.Add(table);
            dataSet.Tables[0].TableName = "data";
            using (StreamWriter jsonFile = new StreamWriter(pathSaveFile + nameDistinction + idRubro + ".json", false))
                jsonFile.WriteLine(JsonConvert.SerializeObject(dataSet, Formatting.None).ToString().Replace("  ", ""));
            dataSet.Clear();
        }
    }
}
