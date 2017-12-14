using System;
using System.Data;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;

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
        //Jorge Luis|14/12/2017|RW-*
        /*Método ...*/
        public DataTable FilterN005(string pathSaveFile, string pathConnection)
        {
            DataSet datasetCuentas = new DataSet();
            DataTable tableCuentas = new DataTable();
            tableCuentas = consb.FilterRubro(pathConnection, "N005");
            DataRow[] currentRows = tableCuentas.Select(null, null, DataViewRowState.CurrentRows);

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
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "c";
            tableTotals.Columns.Add(column);
            #endregion
            

            foreach (DataRow item in currentRows)
                Ventas(pathSaveFile, pathConnection, item[0].ToString(), tableTotals);
            return tableTotals;
        }
        //Jorge Luis|14/12/2017|RW-*
        /*Método ...*/
        public DataTable Ventas(string pathSaveFile, string pathConnection, string idCuenta, DataTable tableTotals)
        {
            DataRow row;

            DataSet datasetData = new DataSet();
            DataTable tableData = new DataTable();
            DataRow foundRow;
            for (Int16 j = 1; j <= 12; j++)
            {
                tableData = consb.SumNhaberDiario(pathConnection, j, idCuenta);
                try
                {
                    foundRow = tableData.Rows[0];
                    row = tableTotals.NewRow();
                    row["a"] = j;
                    row["b"] = idCuenta;
                    row["c"] = foundRow[0].ToString();
                    tableTotals.Rows.Add(row);
                }
                catch (Exception)
                {
                    row = tableTotals.NewRow();
                    row["a"] = j;
                    row["b"] = idCuenta;
                    row["c"] = "0";
                    tableTotals.Rows.Add(row);
                }
                
                
            }
                return tableTotals;
        }
    }
}
