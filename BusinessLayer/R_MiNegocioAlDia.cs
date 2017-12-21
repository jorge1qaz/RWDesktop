using System;
using System.Data;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class R_MiNegocioAlDia
    {
        AccesoDatos dat = new AccesoDatos();
        Paths paths = new Paths();
        Consultas cons = new Consultas();
        Consultasb consb = new Consultasb();
        Transferencia trans = new Transferencia();
        Directorios dirs = new Directorios();

        double totalVentas;
        double totalCajaBancosHaber;
        double totalCajaBancosDebe;
        decimal totalCajaBancos;
        double totalCobrarHaber;
        double totalCobrarDebe;
        decimal totalCobrar;

        //Jorge Luis|18/12/2017|RW-*
        /*Método para generar  listas de las diversas consultas*/
        public void StartModule()
        {
            DataTable listDB = new DataTable();
            listDB = cons.CheckDataBaseConta();
            foreach (DataRow item in listDB.Rows)
            {
                if (File.Exists(item[4].ToString() + "/DIARIO.DBF"))
                {
                    dirs.CreateDirectory(paths.PathMND + "/" + item[0].ToString().Trim());
                    dirs.CreateDirectory(paths.PathMND + "/" + item[0].ToString().Trim() + "/" + item[2].ToString().Trim());
                    CreateBigQueryEachOne(paths.PathPrincipalDirectory + paths.PathMND + "/" + item[0].ToString().Trim() + "/" + item[2].ToString().Trim() + "/", item[4].ToString().Trim());
                }
            }
        }

        public void CreateBigQueryEachOne(string pathSaveFile, string pathConnection)
        {
            //GenerateListCajaBancos(pathSaveFile, pathConnection);
            //GenerateListVentas(pathSaveFile, pathConnection);
            ExportTable(pathSaveFile, pathConnection, "A105");
            ExportTable(pathSaveFile, pathConnection, "N015");
            ExportTable(pathSaveFile, pathConnection, "N210");
            ExportTable(pathSaveFile, pathConnection, "N220");
            ExportTable(pathSaveFile, pathConnection, "N230");

            ExportTable(pathSaveFile, pathConnection, "N005", true);  // Haber 7
            ExportTable(pathSaveFile, pathConnection, "N010", false); // Debe  6 
            ExportTable(pathSaveFile, pathConnection, "N103", true);

            ExportTable(pathSaveFile, pathConnection, "N110", true);
            ExportTable(pathSaveFile, pathConnection, "N205", false);
            ExportTable(pathSaveFile, pathConnection, "N215", false);
            ExportTable(pathSaveFile, pathConnection, "N225", false);
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
            //ExportTable(pathSaveFile, pathConnection, "N520");
            ExportTable(pathSaveFile, pathConnection, "N525", false);
        }
        //Jorge Luis|14/12/2017|RW-*
        /*Método ...*/
        public DataTable GetTotalByRubro(string pathConnection, string idRubro, bool tipoOperacion)
        {
            DataSet datasetCuentas = new DataSet();
            DataTable tableCuentas = new DataTable();
            tableCuentas = consb.FilterRubro(pathConnection, idRubro);

            DataTable tableTotals = new DataTable();
            DataColumn column;
            #region DeclaracionColumnas
            column = new DataColumn();
            column.DataType = Type.GetType("System.Int16");
            column.ColumnName = "a";
            tableTotals.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "b";
            tableTotals.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Double");
            column.ColumnName = "c";
            tableTotals.Columns.Add(column);
            #endregion
            foreach (DataRow item in tableCuentas.Rows)
                GetTotal(pathConnection, item[0].ToString(), tableTotals, tipoOperacion);
            return tableTotals;
        }
        //Jorge Luis|14/12/2017|RW-*
        /*Método ...*/
        public DataTable GetTotal(string pathConnection, string idCuenta, DataTable tableTotals, bool tipoOperacion)
        {
            DataRow row;
            DataSet datasetData = new DataSet();
            DataTable tableData = new DataTable();
            DataRow foundRow;
            for (Int16 j = 1; j <= 12; j++)
            {
                if (tipoOperacion) //True SumNhaberDiario (HABER)
                    tableData = consb.SumNhaberDiario(pathConnection, j, idCuenta);
                else               //False SumNdebeDiario  (DEBE)
                    tableData =  consb.SumNdebeDiario(pathConnection, j, idCuenta);
                row = tableTotals.NewRow();
                try
                {
                    foundRow = tableData.Rows[0];
                    row["a"] = j;
                    row["b"] = idCuenta;
                    row["c"] = foundRow[0].ToString();
                    tableTotals.Rows.Add(row);
                }
                catch (Exception)
                {
                    row["a"] = j;
                    row["b"] = idCuenta;
                    row["c"] = 0;
                    tableTotals.Rows.Add(row);
                }
            }
            return tableTotals;
        }
        
        //Jorge Luis|18/12/2017|RW-*
        /*Método ...*/
        public void GenerateListCajaBancos(string pathSaveFile, string pathConnection)
        {
            List<decimal> listCajaBancos = new List<decimal>();
            DataTable tableDataA105Haber = new DataTable();
            using (StreamWriter jsonFile = new StreamWriter(pathSaveFile + "CajaBancos.json", false))
            {
                for (int i = 1; i <= 12; i++)
                {
                    tableDataA105Haber = GetTotalByRubro(@pathConnection, "A105", true);
                    try
                    { totalCajaBancosHaber = tableDataA105Haber.AsEnumerable().Where(x => x.Field<Int16>("a") == i).Select(x => x.Field<double>("c")).Sum(); }
                    catch (Exception)
                    { totalCajaBancosHaber = 0; }
                    listCajaBancos.Add(Convert.ToDecimal(totalVentas));
                }
                jsonFile.WriteLine(JsonConvert.SerializeObject(listCajaBancos, Formatting.None).ToString());
                listCajaBancos.Clear();
            }
        }
        
        //Jorge Luis|18/12/2017|RW-*
        /*Método ...*/
        public void GenerateListVentas(string pathSaveFile, string pathConnection)
        {
            List<decimal> listVentas = new List<decimal>();
            DataTable tableDataN005 = new DataTable();
            using (StreamWriter jsonFile = new StreamWriter(pathSaveFile + "Ventas.json", false))
            {
                for (int i = 1; i <= 12; i++)
                {
                    tableDataN005 = GetTotalByRubro(@pathConnection, "N005", true);
                    try
                    { totalVentas = tableDataN005.AsEnumerable().Where(x => x.Field<Int16>("a") == i).Select(x => x.Field<double>("c")).Sum(); }
                    catch (Exception)
                    { totalVentas = 0; }
                    listVentas.Add(Convert.ToDecimal(totalVentas));
                }
                jsonFile.WriteLine(JsonConvert.SerializeObject(listVentas, Formatting.Indented).ToString().Replace("  ", ""));
                listVentas.Clear();
            }
        }
        //Jorge Luis|18/12/2017|RW-*
        /*Método ...*/
        public void ExportTable(string pathSaveFile, string pathConnection, string idRubro, bool tipoOperacion)
        {
            DataSet dataSet = new DataSet();
            DataTable table = new DataTable();
            for (Int16 i = 0; i <= 12; i++)
            {
                table = consb.TablaDiario(@pathConnection, idRubro, i, tipoOperacion);
                dataSet.Tables.Add(table);
                dataSet.Tables[i].TableName = i.ToString();
            }
            using (StreamWriter jsonFile = new StreamWriter(pathSaveFile + idRubro + ".json", false))
                jsonFile.WriteLine(JsonConvert.SerializeObject(dataSet, Formatting.None).ToString().Replace("  ", ""));
            dataSet.Clear();
        }
        //Jorge Luis|18/12/2017|RW-*
        /*Método ...*/
        public void ExportTable(string pathSaveFile, string pathConnection, string idRubro)
        {
            DataSet dataSet = new DataSet();
            DataTable table = new DataTable();
            for (Int16 i = 0; i <= 12; i++)
            {
                table = consb.TablaDiario(@pathConnection, idRubro, i);
                dataSet.Tables.Add(table);
                dataSet.Tables[i].TableName = i.ToString();
            }
            using (StreamWriter jsonFile = new StreamWriter(pathSaveFile + idRubro + ".json", false))
                jsonFile.WriteLine(JsonConvert.SerializeObject(dataSet, Formatting.None).ToString().Replace("  ", ""));
            dataSet.Clear();
        }
    }
}
