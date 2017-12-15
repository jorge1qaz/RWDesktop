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
        public DataTable GetTotalByRubro(string pathSaveFile, string pathConnection, string idRubro, bool tipoOperacion)
        {
            DataSet datasetCuentas = new DataSet();
            DataTable tableCuentas = new DataTable();
            tableCuentas = consb.FilterRubro(pathConnection, idRubro);
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
            column.DataType = Type.GetType("System.Double");
            column.ColumnName = "c";
            tableTotals.Columns.Add(column);
            #endregion
            foreach (DataRow item in currentRows)
                GetTotalNhaber(pathSaveFile, pathConnection, item[0].ToString(), tableTotals, tipoOperacion);
            return tableTotals;
        }
        //Jorge Luis|14/12/2017|RW-*
        /*Método ...*/
        public DataTable GetTotalNhaber(string pathSaveFile, string pathConnection, string idCuenta, DataTable tableTotals, bool tipoOperacion)
        {
            DataRow row;
            DataSet datasetData = new DataSet();
            DataTable tableData = new DataTable();
            DataRow foundRow;
            for (Int16 j = 1; j <= 12; j++)
            {
                if (tipoOperacion) //True SumNhaberDiario
                    tableData = consb.SumNhaberDiario(pathConnection, j, idCuenta);
                else               //False SumNdebeDiario
                    tableData =  consb.SumNdebeDiario(pathConnection, j, idCuenta);
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
                    row["c"] = 0;
                    tableTotals.Rows.Add(row);
                }
            }
                return tableTotals;
        }
    }
}
