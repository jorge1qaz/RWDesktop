using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Ionic.Zip;
using System.Windows.Forms;
using System.Text;
using System.Security.Cryptography;
using System.Net;
using Newtonsoft.Json;
using System.Linq;
using System.Threading;

namespace RWeb
{
    public partial class pruebas : MetroFramework.Forms.MetroForm
    {
        public pruebas()
        {
            InitializeComponent();
        }
        decimal totalUnidades;
        decimal totalPuVentas;
        decimal totalPuCosto;
        decimal PuVentas;
        decimal PuCosto;
        decimal muUnitario;
        decimal mu;
        decimal montoVentas;
        decimal montoCosto;
        decimal margenUtil;
        private void pruebas_Load(object sender, EventArgs e)
        {
            margenUtilidad.StartModule();
        }
        AccesoDatos dat = new AccesoDatos();
        Consultas cons = new Consultas();
        Transferencia trans = new Transferencia();
        R_MargenUtilidad margenUtilidad = new R_MargenUtilidad();
        Paths paths = new Paths();
        Directorios dirs = new Directorios();

        //Jorge Luis|14/11/2017|RW-*
        /*Método para **/
        public void GenerarReportesSoles(string pathSaveFile, string pathConnection)
        {
            DataTable tablaReporte = new DataTable();
            DataColumn column;
            #region DeclaracionColumnas
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "C";
            tablaReporte.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "D";
            tablaReporte.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "M";
            tablaReporte.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "U";
            tablaReporte.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "PV";
            tablaReporte.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "PC";
            tablaReporte.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "MUU";
            tablaReporte.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "PM";
            tablaReporte.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "MV";
            tablaReporte.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "MC";
            tablaReporte.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "MU";
            tablaReporte.Columns.Add(column);
            #endregion
                DataTable datos = new DataTable();
                DataSet dsReporte = new DataSet();
                dsReporte.Tables.Add(tablaReporte);
                dsReporte.Tables[0].TableName = "data";
            for (Int16 i = 0; i <= 12; i++)
            {
                datos = cons.ListProducts(i, pathConnection);
                DataRow[] currentRows = datos.Select(null, null, DataViewRowState.CurrentRows);
                foreach (DataRow row in currentRows)
                {
                    GenerarConsulta(tablaReporte, row[0].ToString(), i, pathConnection);
                    using (StreamWriter jsonReporte = new StreamWriter(pathSaveFile + "ReporteSoles" + i + ".json", false))
                    {
                        jsonReporte.WriteLine(JsonConvert.SerializeObject(dsReporte, Formatting.Indented).ToString());
                    }
                }
                tablaReporte.Clear();
            }
        }
        //Jorge Luis|14/11/2017|RW-*
        /*Método para **/
        public void GenerarReportesDolares(string pathSaveFile, string pathConnection)
        {
            DataTable tablaReporte = new DataTable();
            DataColumn column;
            #region DeclaracionColumnas
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "C";
            tablaReporte.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "D";
            tablaReporte.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "M";
            tablaReporte.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "U";
            tablaReporte.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "PV";
            tablaReporte.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "PC";
            tablaReporte.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "MUU";
            tablaReporte.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "PM";
            tablaReporte.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "MV";
            tablaReporte.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "MC";
            tablaReporte.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "MU";
            tablaReporte.Columns.Add(column);
            #endregion
            DataTable datos = new DataTable();
            DataSet dsReporte = new DataSet();
            dsReporte.Tables.Add(tablaReporte);
            dsReporte.Tables[0].TableName = "data";
            for (Int16 i = 0; i <= 12; i++)
            {
                datos = cons.ListProducts(i, pathConnection);
                DataRow[] currentRows = datos.Select(null, null, DataViewRowState.CurrentRows);
                foreach (DataRow row in currentRows)
                {
                    GenerarConsultaDolares(tablaReporte, row[0].ToString(), i, pathConnection);
                    using (StreamWriter jsonReporte = new StreamWriter(pathSaveFile + "ReporteDolares" + i + ".json", false))
                    {
                        jsonReporte.WriteLine(JsonConvert.SerializeObject(dsReporte, Formatting.Indented).ToString());
                    }
                }
            }
        }
        //Jorge Luis|15/11/2017|RW-*
        /*Método para **/
        public void GenerarConsulta(DataTable tablaReporte, string idProduct, Int16 mesProcesoCalculado, string pathConection)
        {
            DataTable datos = new DataTable();
            DataRow row;
            datos = cons.GetFullProduct(mesProcesoCalculado, idProduct, pathConection);
            try
            {
                totalUnidades = decimal.Parse(datos.Rows[0][3].ToString());
            }
            catch (Exception)
            {
                totalUnidades = 0;
            }
            try
            {
                totalPuVentas = decimal.Parse(datos.Rows[0][4].ToString());
            }
            catch (Exception)
            {
                totalPuVentas = 0;
            }
            try
            {
                totalPuCosto = decimal.Parse(datos.Rows[0][5].ToString());
            }
            catch (Exception)
            {
                totalPuCosto = 0;
            }

            if (totalUnidades != 0) {
                PuVentas = totalPuVentas / totalUnidades;
                PuCosto = totalPuCosto / totalUnidades;
            }
            else {
                PuVentas = 0;
                PuCosto = 0;
            }
            muUnitario = PuVentas - PuCosto;
            if (PuCosto != 0)
                mu = (muUnitario / PuCosto) * 100;
            else
                mu = 0;
            montoVentas = PuVentas * totalUnidades;
            montoCosto = PuCosto * totalUnidades;
            margenUtil = montoVentas - montoCosto;
            row = tablaReporte.NewRow();
            //Mes = "Me"; CID = "CI"; Codigo = "C"; Descripcion = "D"; Medida = "M"; Unidades = "U"; PrecioVenta = "PV"; PrecioCosto = "PC"; MargenUtilidadUnitario = "MUU"; PorcentajeMargenUtilidad = "PM"; MontoVentas = "MV"; MontoCosto = "MC"; MargenUtil = "MU 
            try
            {
                row["C"] = datos.Rows[0][0].ToString().Trim();
            }
            catch (Exception)
            {
                row["C"] = "";
            }
            try
            {
                row["D"] = datos.Rows[0][1].ToString().Trim();
            }
            catch (Exception)
            {
                row["D"] = "";
            }
            try
            {
                row["M"] = datos.Rows[0][2].ToString().Trim();
            }
            catch (Exception)
            {
                row["M"] = "";
            }
            row["U"] = Math.Round(totalUnidades, 1);
            row["PV"] = Math.Round(PuVentas, 4);
            row["PC"] = Math.Round(PuCosto, 4);
            row["MUU"] = Math.Round(muUnitario, 4);
            row["PM"] = Math.Round(mu, 4);
            row["MV"] = Math.Round(montoVentas, 4);
            row["MC"] = Math.Round(montoCosto, 4);
            row["MU"] = Math.Round(margenUtil, 4);
            tablaReporte.Rows.Add(row);
        }
        //Jorge Luis|16/11/2017|RW-*
        /*Método para **/
        public void GenerarConsultaDolares(DataTable tablaReporte, string idProduct, Int16 mesProcesoCalculado, string pathConection)
        {
            DataTable datos = new DataTable();
            DataRow row;
            datos = cons.GetFullProductDolars(mesProcesoCalculado, idProduct, pathConection);
            try
            {
                totalUnidades = decimal.Parse(datos.Rows[0][3].ToString());
            }
            catch (Exception)
            {
                totalUnidades = 0;
            }
            try
            {
                totalPuVentas = decimal.Parse(datos.Rows[0][4].ToString());
            }
            catch (Exception)
            {
                totalPuVentas = 0;
            }
            try
            {
                totalPuCosto = decimal.Parse(datos.Rows[0][5].ToString());
            }
            catch (Exception)
            {
                totalPuCosto = 0;
            }

            if (totalUnidades != 0)
            {
                PuVentas = totalPuVentas / totalUnidades;
                PuCosto = totalPuCosto / totalUnidades;
            }
            else
            {
                PuVentas = 0;
                PuCosto = 0;
            }
            muUnitario = PuVentas - PuCosto;
            if (PuCosto != 0)
                mu = (muUnitario / PuCosto) * 100;
            else
                mu = 0;
            montoVentas = PuVentas * totalUnidades;
            montoCosto = PuCosto * totalUnidades;
            margenUtil = montoVentas - montoCosto;
            row = tablaReporte.NewRow();
            //Mes = "Me"; CID = "CI"; Codigo = "C"; Descripcion = "D"; Medida = "M"; Unidades = "U"; PrecioVenta = "PV"; PrecioCosto = "PC"; MargenUtilidadUnitario = "MUU"; PorcentajeMargenUtilidad = "PM"; MontoVentas = "MV"; MontoCosto = "MC"; MargenUtil = "MU 
            try
            {
                row["C"] = datos.Rows[0][0].ToString().Trim();
            }
            catch (Exception)
            {
                row["C"] = "";
            }
            try
            {
                row["D"] = datos.Rows[0][1].ToString().Trim();
            }
            catch (Exception)
            {
                row["D"] = "";
            }
            try
            {
                row["M"] = datos.Rows[0][2].ToString().Trim();
            }
            catch (Exception)
            {
                row["M"] = "";
            }
            row["U"] = Math.Round(totalUnidades, 1);
            row["PV"] = Math.Round(PuVentas, 4);
            row["PC"] = Math.Round(PuCosto, 4);
            row["MUU"] = Math.Round(muUnitario, 4);
            row["PM"] = Math.Round(mu, 4);
            row["MV"] = Math.Round(montoVentas, 4);
            row["MC"] = Math.Round(montoCosto, 4);
            row["MU"] = Math.Round(margenUtil, 4);
            tablaReporte.Rows.Add(row);
        }
        //Jorge Luis|15/11/2017|RW-*
        /*Método para **/
        public void CreateListProductsByMonth(string pathSaveFile, string pathConnection) {
            for (Int16 i = 0; i <= 12; i++)
            {
                DataSet dsListProducts = new DataSet();
                DataTable datos = new DataTable();
                datos = cons.ListProducts(i, pathConnection);
                dsListProducts.Tables.Add(datos);
                dsListProducts.Tables[0].TableName = "data";
                /*Recorre y crea  archivos json de acuerdo a los productos que existen en la base de datos*/
                using (StreamWriter jsonListaCuentas = new StreamWriter(pathSaveFile + "products" + i +".json", false))
                {
                    jsonListaCuentas.WriteLine(JsonConvert.SerializeObject(dsListProducts, Formatting.None).ToString());
                }
            }
        }
        //Jorge Luis|15/11/2017|RW-*
        /*Método para **/
        public void GenerateQueryByMonth(string pathSaveFile, string pathConnection)
        {
            for (Int16 i = 0; i <= 12; i++)
            {
                //GenerarConsultaPrimary(i, pathSaveFile, pathConnection);
                //DataTable datos = new DataTable();
                //datos = cons.ListProducts(i, pathConnection);
                //DataRow[] currentRows = datos.Select(null, null, DataViewRowState.CurrentRows);
                //foreach (DataRow row in currentRows)
                //    GenerarConsultaPrimary(i, row[0].ToString(), pathSaveFile, pathConnection);

            }
        }
        //Jorge Luis|15/11/2017|RW-*
        /*Método para generar  listas de las diversas consultas*/
        public void GenerateQuerys(string pathSaveFile, string pathConnection)
        {
            for (Int16 j = 1; j <= 12; j++)
            {
                DataSet dsListQuerys = new DataSet();
                DataTable almacenes = new DataTable();
                almacenes = cons.ListAlmacen(pathConnection, j); //Correcto

                DataTable listCOSTO1 = new DataTable();
                listCOSTO1 = cons.ListCOSTO1(pathConnection, j);
                DataTable listCOSTO2 = new DataTable();
                listCOSTO2 = cons.ListCOSTO2(pathConnection, j);
                DataTable listVendedor = new DataTable();
                listVendedor = cons.ListVendedor(pathConnection, j);
                DataTable listTipoStock = new DataTable();
                listTipoStock = cons.ListTipoStock(pathConnection);
                DataTable listAlcance = new DataTable();
                listAlcance = cons.ListAlcance(pathConnection);

                dsListQuerys.Tables.Add(almacenes);
                dsListQuerys.Tables.Add(listCOSTO1);
                dsListQuerys.Tables.Add(listCOSTO2);
                dsListQuerys.Tables.Add(listVendedor);
                dsListQuerys.Tables.Add(listTipoStock);
                dsListQuerys.Tables.Add(listAlcance);

                for (int i = 0; i < dsListQuerys.Tables.Count; i++)
                {
                    dsListQuerys.Tables[i].TableName = "data" + i;
                }
                /*Recorre y crea  archivos json de acuerdo a los productos que existen en la base de datos*/
                using (StreamWriter jsonListaCuentas = new StreamWriter(pathSaveFile + "Querys" + j + ".json", false))
                {
                    jsonListaCuentas.WriteLine(JsonConvert.SerializeObject(dsListQuerys, Formatting.None).ToString().Trim());
                }
            }
        }
    }
}
