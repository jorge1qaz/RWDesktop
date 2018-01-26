using System.Data;
using System.IO;
using Newtonsoft.Json;

namespace BusinessLayer
{
    public class R_FlujoCajaDetallado
    {
        AccesoDatos dat = new AccesoDatos();
        Paths paths = new Paths();
        Consultas cons = new Consultas();
        Consultasb consb = new Consultasb();
        Transferencia trans = new Transferencia();
        Directorios dirs = new Directorios();
        //Jorge Luis|19/01/2018|RW-93
        /*Método para generar  listas de las diversas consultas*/
        public void StartModule()
        {
            DataTable listDB = new DataTable();
            listDB = cons.CheckDataBaseConta();
            foreach (DataRow item in listDB.Rows)
            {
                if (File.Exists(item[4].ToString() + "/DIARIO.DBF"))
                {
                    dirs.CreateDirectory(paths.PathFCD + "/" + item[0].ToString().Trim() + "/" + item[2].ToString().Trim());
                    CreateBigQueryEachOne(paths.PathPrincipalDirectory + paths.PathFCD + "/" + item[0].ToString().Trim() + "/" + item[2].ToString().Trim() + "/", item[4].ToString().Trim());
                }
            }
        }
        //Jorge Luis|19/01/2018|RW-93
        /*Método para generar  listas de las diversas consultas*/
        public void CreateBigQueryEachOne(string pathSaveFile, string pathConnection)
        {
            GetListDescription(pathSaveFile, pathConnection);
            GetListData(pathSaveFile, pathConnection);
        }
        //Jorge Luis|19/01/2018|RW-93
        /*Método para*/
        public void GetListDescription(string pathSaveFile, string pathConnection)
        {
            DataSet dataSet = new DataSet();
            DataTable dataTableListSaldoInicialDescripcion = new DataTable();
            dataTableListSaldoInicialDescripcion = consb.ListSaldoInicialDescripcion(@pathConnection);
            DataTable dataTableListIngresosDescripcion = new DataTable();
            dataTableListIngresosDescripcion = consb.ListIngresosDescripcion(@pathConnection);
            DataTable dataTableListEgresosDescripcion = new DataTable();
            dataTableListEgresosDescripcion = consb.ListEgresosDescripcion(@pathConnection);
            DataTable dataTableListCustumers = new DataTable();
            dataTableListCustumers = consb.ListCustumers(@pathConnection);
            dataSet.Tables.Add(dataTableListSaldoInicialDescripcion);
            dataSet.Tables.Add(dataTableListIngresosDescripcion);
            dataSet.Tables.Add(dataTableListEgresosDescripcion);
            dataSet.Tables.Add(dataTableListCustumers);
            dataSet.Tables[0].TableName = "dataTableListSaldoInicialDescripcion";
            dataSet.Tables[1].TableName = "dataTableListIngresosDescripcion";
            dataSet.Tables[2].TableName = "dataTableListEgresosDescripcion";
            dataSet.Tables[3].TableName = "dataTableListCustumers";
            using (StreamWriter jsonFile = new StreamWriter(pathSaveFile + "ListsDescription.json", false))
                jsonFile.WriteLine(JsonConvert.SerializeObject(dataSet, Formatting.None).ToString().Replace("  ", ""));
            dataSet.Clear();
        }
        //Jorge Luis|19/01/2018|RW-93
        /*Método para*/
        public void GetListData(string pathSaveFile, string pathConnection)
        {
            DataSet dataSet = new DataSet();
            DataTable dataTableListSaldoInicialDatos = new DataTable();
            dataTableListSaldoInicialDatos = consb.ListSaldoInicialDatos(@pathConnection);
            DataTable dataTableListIngresosDatos = new DataTable();
            dataTableListIngresosDatos = consb.ListIngresosDatos(@pathConnection);
            DataTable dataTableListListEgresosDatos = new DataTable();
            dataTableListListEgresosDatos = consb.ListEgresosDatos(@pathConnection);
            dataSet.Tables.Add(dataTableListSaldoInicialDatos);
            dataSet.Tables.Add(dataTableListIngresosDatos);
            dataSet.Tables.Add(dataTableListListEgresosDatos);
            dataSet.Tables[0].TableName = "dataTableListSaldoInicialDatos";
            dataSet.Tables[1].TableName = "dataTableListIngresosDatos";
            dataSet.Tables[2].TableName = "dataTableListListEgresosDatos";
            using (StreamWriter jsonFile = new StreamWriter(pathSaveFile + "ListDatos.json", false))
                jsonFile.WriteLine(JsonConvert.SerializeObject(dataSet, Formatting.None).ToString().Replace("  ", ""));
            dataSet.Clear();
        }
    }
}
