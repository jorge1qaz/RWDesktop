using Newtonsoft.Json;
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
            // Se decidió enviar toda la tabla completa de plan en esta clase

        }
        struct AttributesForQuery
        {
            public string _pathSaveFile;
            public string _pathConnection;
            public string _tableDBFFormatoName;
            public string _tableDBFFormatoFilter;

            public DataTable GetListRubrosByFormato()
            {
                DataTable lista = new DataTable();
                Consultasb consultasb = new Consultasb();
                lista = consultasb.GetListRubrosByFormato(_pathConnection, _tableDBFFormatoName, _tableDBFFormatoFilter);
                return lista;
            }
        }
        //Jorge Luis|09/01/2018|RW-109
        /*Método para generar  listas de las diversas consultas*/
        public void CreateBigQueryEachOne(string pathSaveFile, string pathConnection)
        {
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A105", true, "1"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A110", true, "1");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A115", true, "1"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A120", true, "1");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A125", true, "1"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A128", true, "1");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A130", true, "1"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A131", true, "1");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A133", true, "1"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A140", true, "1");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A210", true, "1"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A220", true, "1");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A510", true, "1"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A513", true, "1");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A515", true, "1"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A517", true, "1");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A520", true, "1"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A525", true, "1");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A530", true, "1"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A540", true, "1");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A550", true, "1"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A560", true, "1");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A570", true, "1"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A575", true, "1");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A580", true, "1"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A610", true, "1");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A630", true, "1"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN", "P105", false, "1");

            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P110", false, "1"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P120", false, "1");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P121", false, "1"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P123", false, "1");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P125", false, "1"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P130", false, "1");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P135", false, "1"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P137", false, "1");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P210", false, "1"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P410", false, "1");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P415", false, "1"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P420", false, "1");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P425", false, "1"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P430", false, "1");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P435", false, "1"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P440", false, "1");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P445", false, "1"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P450", false, "1");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P805", false, "1"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P810", false, "1");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P815", false, "1"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P820", false, "1");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P830", false, "1"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "P835", false, "1");

            // Cuentas agregadas
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A135", false, "1");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A204", false, "1");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A550", false, "1");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A230", false, "1");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A235", false, "1");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A236", false, "1");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL2", "CCOD_BALN2", "A240", false, "1");

            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A105", true, "3"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A106", true, "3");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A110", true, "3"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A111", true, "3");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A115", true, "3"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A120", true, "3");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A121", true, "3"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A122", true, "3");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A123", true, "3"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A124", true, "3");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A125", true, "3"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A130", true, "3");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A135", true, "3"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A140", true, "3");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A142", true, "3"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A145", true, "3");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BALN", "A151", true, "3"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A152", true, "3");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A153", true, "3"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BALN", "CCOD_BALN", "A155", true, "3");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A157", true, "3"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A158", true, "3");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A159", true, "3"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A160", true, "3");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A164", true, "3"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A176", true, "3");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A177", true, "3"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A178", true, "3");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A179", true, "3"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A180", true, "3");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "A185", true, "3");

            ExportTable2(pathSaveFile, pathConnection, "CCOD_BALN2", "CCOD_BALN2", "P105", false, "3"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "P110", false, "3");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "P115", false, "3"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "P541", false, "3");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BALN2", "P120", false, "3"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "P121", false, "3");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "P122", false, "3"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "P128", false, "3");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "P129", false, "3"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "P133", false, "3");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "P135", false, "3"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "P141", false, "3");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "P505", false, "3"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "P507", false, "3");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "P510", false, "3"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "P511", false, "3");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "P515", false, "3"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "P520", false, "3");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "P530", false, "3"); ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "P531", false, "3");
            ExportTable2(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "P540", false, "3");

            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "F005", true, "4"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "F010", false, "4");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "F115", false, "4"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "F205", false, "4");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "F210", false, "4"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "F502", false, "4");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "F505", true, "4"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "F510", true, "4");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "F515", true, "4"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "F520", true, "4");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "F525", false, "4"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "F530", false, "4");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "F560", false, "4"); ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "F605", false, "4");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL", "CCOD_BAL", "F705", false, "4");

            ExportListCuentas(pathSaveFile, pathConnection, true);
            ExportListCuentas(pathSaveFile, pathConnection, false);

            // Nuevas modificaciones
            GetDataforReportEstadoSituacionFinanciera(pathSaveFile, pathConnection);
            ExportCompleteTables(pathSaveFile, pathConnection);
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
        public void ExportTable2(string pathSaveFile, string pathConnection, string filter1, string filter2, string idRubro, bool tipoOperacion, string nameDistinction)
        {
            DataSet dataSet = new DataSet();
            DataTable table = new DataTable();
            //table = consb.GetTotalMonthByRubro(@pathConnection, filter1, filter2, idRubro, tipoOperacion);
            table = consb.GetTableByRubro(@pathConnection, filter1, filter2, idRubro, tipoOperacion);
            dataSet.Tables.Add(table);
            dataSet.Tables[0].TableName = "data";
            using (StreamWriter jsonFile = new StreamWriter(pathSaveFile + nameDistinction + idRubro + ".json", false))
                jsonFile.WriteLine(JsonConvert.SerializeObject(dataSet, Formatting.None).ToString().Replace("  ", ""));
            dataSet.Clear();
        }
        /*Se necesita que se obtenga los datos en dos consultas sql odbc, para ello se obtienen en las tablas: table1 y table2, ya que sí 
         se hace con un solo query retorna una excepción  de "SQL expression is too complex" */
        public void ExportListCuentas(string pathSaveFile, string pathConnection, bool tipoLista)
        {
            string nameList = "";
            if (tipoLista)
                nameList = "Activo";
            else
                nameList = "Pasivo";
            DataSet dataSet = new DataSet();
            DataTable table1 = new DataTable();
            DataTable table2 = new DataTable();
            table1 = consb.listCuentasByRubrosGroup1(@pathConnection, tipoLista);
            table2 = consb.listCuentasByRubrosGroup2(@pathConnection, tipoLista);
            table1.Merge(table2);
            dataSet.Tables.Add(table1);
            dataSet.Tables[0].TableName = "data";
            using (StreamWriter jsonFile = new StreamWriter(pathSaveFile + nameList + ".json", false))
                jsonFile.WriteLine(JsonConvert.SerializeObject(dataSet, Formatting.None).ToString().Replace("  ", ""));
            dataSet.Clear();
        }

        public void GetDataforReportEstadoSituacionFinanciera(string pathSaveFile, string pathConnection) {
            DataSet dataSet         = new DataSet();
            AttributesForQuery queryNamesActivo1 = new AttributesForQuery()
            {
                _pathSaveFile = pathSaveFile,
                _pathConnection = pathConnection,
                _tableDBFFormatoName = "FORMATO2",
                _tableDBFFormatoFilter = "A1",
            };
            AttributesForQuery queryNamesActivo2 = new AttributesForQuery()
            {
                _pathSaveFile = pathSaveFile,
                _pathConnection = pathConnection,
                _tableDBFFormatoName = "FORMATO2",
                _tableDBFFormatoFilter = "A2",
            };
            AttributesForQuery queryNamesActivo3 = new AttributesForQuery()
            {
                _pathSaveFile = pathSaveFile,
                _pathConnection = pathConnection,
                _tableDBFFormatoName = "FORMATO2",
                _tableDBFFormatoFilter = "A3",
            };
            AttributesForQuery queryNamesActivo4 = new AttributesForQuery()
            {
                _pathSaveFile = pathSaveFile,
                _pathConnection = pathConnection,
                _tableDBFFormatoName = "FORMATO2",
                _tableDBFFormatoFilter = "A4",
            };
            AttributesForQuery queryNamesActivo5 = new AttributesForQuery()
            {
                _pathSaveFile = pathSaveFile,
                _pathConnection = pathConnection,
                _tableDBFFormatoName = "FORMATO2",
                _tableDBFFormatoFilter = "A5",
            };
            AttributesForQuery queryNamesActivo6 = new AttributesForQuery()
            {
                _pathSaveFile = pathSaveFile,
                _pathConnection = pathConnection,
                _tableDBFFormatoName = "FORMATO2",
                _tableDBFFormatoFilter = "A6",
            };
            AttributesForQuery queryNamesActivo7 = new AttributesForQuery()
            {
                _pathSaveFile = pathSaveFile,
                _pathConnection = pathConnection,
                _tableDBFFormatoName = "FORMATO2",
                _tableDBFFormatoFilter = "A7",
            };
            AttributesForQuery queryNamesActivo8 = new AttributesForQuery()
            {
                _pathSaveFile = pathSaveFile,
                _pathConnection = pathConnection,
                _tableDBFFormatoName = "FORMATO2",
                _tableDBFFormatoFilter = "A8",
            };
            AttributesForQuery queryNamesActivo9 = new AttributesForQuery()
            {
                _pathSaveFile = pathSaveFile,
                _pathConnection = pathConnection,
                _tableDBFFormatoName = "FORMATO2",
                _tableDBFFormatoFilter = "A9",
            };

            AttributesForQuery queryNamesPasivo1 = new AttributesForQuery()
            {
                _pathSaveFile = pathSaveFile,
                _pathConnection = pathConnection,
                _tableDBFFormatoName = "FORMATO2",
                _tableDBFFormatoFilter = "P1",
            };
            AttributesForQuery queryNamesPasivo2 = new AttributesForQuery()
            {
                _pathSaveFile = pathSaveFile,
                _pathConnection = pathConnection,
                _tableDBFFormatoName = "FORMATO2",
                _tableDBFFormatoFilter = "P2",
            };
            AttributesForQuery queryNamesPasivo3 = new AttributesForQuery()
            {
                _pathSaveFile = pathSaveFile,
                _pathConnection = pathConnection,
                _tableDBFFormatoName = "FORMATO2",
                _tableDBFFormatoFilter = "P3",
            };
            AttributesForQuery queryNamesPasivo4 = new AttributesForQuery()
            {
                _pathSaveFile = pathSaveFile,
                _pathConnection = pathConnection,
                _tableDBFFormatoName = "FORMATO2",
                _tableDBFFormatoFilter = "P4",
            };
            AttributesForQuery queryNamesPasivo5 = new AttributesForQuery()
            {
                _pathSaveFile = pathSaveFile,
                _pathConnection = pathConnection,
                _tableDBFFormatoName = "FORMATO2",
                _tableDBFFormatoFilter = "P5",
            };
            AttributesForQuery queryNamesPasivo6 = new AttributesForQuery()
            {
                _pathSaveFile = pathSaveFile,
                _pathConnection = pathConnection,
                _tableDBFFormatoName = "FORMATO2",
                _tableDBFFormatoFilter = "P6",
            };
            AttributesForQuery queryNamesPasivo7 = new AttributesForQuery()
            {
                _pathSaveFile = pathSaveFile,
                _pathConnection = pathConnection,
                _tableDBFFormatoName = "FORMATO2",
                _tableDBFFormatoFilter = "P7",
            };
            AttributesForQuery queryNamesPasivo8 = new AttributesForQuery()
            {
                _pathSaveFile = pathSaveFile,
                _pathConnection = pathConnection,
                _tableDBFFormatoName = "FORMATO2",
                _tableDBFFormatoFilter = "P8",
            };
            AttributesForQuery queryNamesPasivo9 = new AttributesForQuery()
            {
                _pathSaveFile = pathSaveFile,
                _pathConnection = pathConnection,
                _tableDBFFormatoName = "FORMATO2",
                _tableDBFFormatoFilter = "P9",
            };

            DataTable listNamesActivo1 = queryNamesActivo1.GetListRubrosByFormato(); // 1 formato raíz de los rubros que empiezan por 1
            DataTable listNamesActivo2 = queryNamesActivo2.GetListRubrosByFormato();
            DataTable listNamesActivo3 = queryNamesActivo3.GetListRubrosByFormato();
            DataTable listNamesActivo4 = queryNamesActivo4.GetListRubrosByFormato();
            DataTable listNamesActivo5 = queryNamesActivo5.GetListRubrosByFormato();
            DataTable listNamesActivo6 = queryNamesActivo6.GetListRubrosByFormato();
            DataTable listNamesActivo7 = queryNamesActivo7.GetListRubrosByFormato();
            DataTable listNamesActivo8 = queryNamesActivo8.GetListRubrosByFormato();
            DataTable listNamesActivo9 = queryNamesActivo9.GetListRubrosByFormato();

            DataTable listNamesPasivo1 = queryNamesPasivo1.GetListRubrosByFormato(); // 1 formato raíz de los rubros que empiezan por 1
            DataTable listNamesPasivo2 = queryNamesPasivo2.GetListRubrosByFormato();
            DataTable listNamesPasivo3 = queryNamesPasivo3.GetListRubrosByFormato();
            DataTable listNamesPasivo4 = queryNamesPasivo4.GetListRubrosByFormato();
            DataTable listNamesPasivo5 = queryNamesPasivo5.GetListRubrosByFormato();
            DataTable listNamesPasivo6 = queryNamesPasivo6.GetListRubrosByFormato();
            DataTable listNamesPasivo7 = queryNamesPasivo7.GetListRubrosByFormato();
            DataTable listNamesPasivo8 = queryNamesPasivo8.GetListRubrosByFormato();
            DataTable listNamesPasivo9 = queryNamesPasivo9.GetListRubrosByFormato();

            listNamesActivo1.TableName = "listNamesActivo1";
            listNamesActivo2.TableName = "listNamesActivo2";
            listNamesActivo3.TableName = "listNamesActivo3";
            listNamesActivo4.TableName = "listNamesActivo4";
            listNamesActivo5.TableName = "listNamesActivo5";
            listNamesActivo6.TableName = "listNamesActivo6";
            listNamesActivo7.TableName = "listNamesActivo7";
            listNamesActivo8.TableName = "listNamesActivo8";
            listNamesActivo9.TableName = "listNamesActivo9";

            listNamesPasivo1.TableName = "listNamesPasivo1";
            listNamesPasivo2.TableName = "listNamesPasivo2";
            listNamesPasivo3.TableName = "listNamesPasivo3";
            listNamesPasivo4.TableName = "listNamesPasivo4";
            listNamesPasivo5.TableName = "listNamesPasivo5";
            listNamesPasivo6.TableName = "listNamesPasivo6";
            listNamesPasivo7.TableName = "listNamesPasivo7";
            listNamesPasivo8.TableName = "listNamesPasivo8";
            listNamesPasivo9.TableName = "listNamesPasivo9";

            dataSet.Tables.Add(listNamesActivo1);
            dataSet.Tables.Add(listNamesActivo2);
            dataSet.Tables.Add(listNamesActivo3);
            dataSet.Tables.Add(listNamesActivo4);
            dataSet.Tables.Add(listNamesActivo5);
            dataSet.Tables.Add(listNamesActivo6);
            dataSet.Tables.Add(listNamesActivo7);
            dataSet.Tables.Add(listNamesActivo8);
            dataSet.Tables.Add(listNamesActivo9);

            dataSet.Tables.Add(listNamesPasivo1);
            dataSet.Tables.Add(listNamesPasivo2);
            dataSet.Tables.Add(listNamesPasivo3);
            dataSet.Tables.Add(listNamesPasivo4);
            dataSet.Tables.Add(listNamesPasivo5);
            dataSet.Tables.Add(listNamesPasivo6);
            dataSet.Tables.Add(listNamesPasivo7);
            dataSet.Tables.Add(listNamesPasivo8);
            dataSet.Tables.Add(listNamesPasivo9);

            GenerateFileJson(pathSaveFile, dataSet, "listNamesRubros");
        }
        public void GenerateFileJson(string pathSaveFile, DataSet dataSet, string nameFile) {
            using (StreamWriter jsonFile = new StreamWriter(pathSaveFile + nameFile + ".json", false))
                jsonFile.WriteLine(JsonConvert.SerializeObject(dataSet, Formatting.None).ToString().Replace("  ", ""));
            dataSet.Clear();
        }
        public void ExportCompleteTables(string pathSaveFile, string pathConnection) {
            DataSet dataSet         = new DataSet();
            DataTable dataTablePlan = new DataTable();
            dataTablePlan           = consb.GetCompleteTablePlan(pathConnection);
            dataTablePlan.TableName = "plan";
            dataSet.Tables.Add(dataTablePlan);
            GenerateFileJson(pathSaveFile, dataSet, "DataBaseConta");
        }
    }
}
