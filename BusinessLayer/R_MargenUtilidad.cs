using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessLayer
{
    public class R_MargenUtilidad
    {
        AccesoDatos dat = new AccesoDatos();
        Paths paths = new Paths();
        Consultas cons = new Consultas();
        Transferencia trans = new Transferencia();
        Directorios dirs = new Directorios();
        //Jorge Luis|15/11/2017|RW-*
        /*Método para generar  listas de las diversas consultas*/
        public void StartModule()
        {
            DataTable listDB = new DataTable();
            listDB = cons.CheckDataBaseStock();
            DataRow[] currentRows = listDB.Select(null, null, DataViewRowState.CurrentRows);
            foreach (DataRow item in currentRows)
            {
                if (File.Exists(item[4].ToString() + "/VENTASL.DBF"))
                {
                    dirs.CreateDirectory(paths.PathMU + "/" + item[0].ToString().Trim());
                    dirs.CreateDirectory(paths.PathMU + "/" + item[0].ToString().Trim() + "/" + item[2].ToString().Trim());
                    CreateBigQueryEachOne(paths.PathPrincipalDirectory + paths.PathMU + "/" + item[0].ToString().Trim() + "/" + item[2].ToString().Trim() + "/", item[4].ToString().Trim());
                }
            }
            dirs.CheckDataBaseStockJson();
        }
        public void CreateBigQueryEachOne(string save, string path)
        {
            GenerateFulltables(save, path);
            GenerateListProductsByMonth(save, path);
            GenerateListProductsByStore(save, path);
            GenerateListProductsByCOSTO1(save, path);
            GenerateListProductsByCustomer(save, path);
            GenerateListProductsByEmployee(save, path);
            GenerateListProductsByAlcance(save, path);
            GenerateListProductsByStock(save, path);
            GenerateListProductsByCOSTO2(save, path);
            GenerateQuerys(save, path);
        }
        public void GenerateQuerys(string pathSaveFile, string pathConnection)
        {
            for (Int16 j = 1; j <= 12; j++)
            {
                DataSet dsListQuerys = new DataSet();
                DataTable almacenes = new DataTable();
                almacenes = cons.ListAlmacen(pathConnection, j);

                DataTable tableVENTASL = new DataTable(); //Tabla contenedora de COSTO 1
                tableVENTASL = cons.ListCOSTO1(pathConnection, j);
                DataTable tableVENTAS = new DataTable();
                tableVENTAS = cons.ListCOSTO1Nulls(pathConnection, j);

                tableVENTAS.Merge(tableVENTASL);

                DataTable customer = new DataTable();
                customer = cons.ListCustomer(pathConnection, j);

                DataTable listVendedor = new DataTable();
                listVendedor = cons.ListVendedor(pathConnection, j);


                DataTable tableVENTASL2 = new DataTable(); //Tabla contenedora de COSTO 1
                tableVENTASL2 = cons.ListCOSTO2(pathConnection, j);
                DataTable tableVENTAS2 = new DataTable();
                tableVENTAS2 = cons.ListCOSTO2Nulls(pathConnection, j);

                tableVENTAS2.Merge(tableVENTASL2);

                //DataTable listCOSTO2 = new DataTable();
                //listCOSTO2 = cons.ListCOSTO2(pathConnection, j);
                //DataTable listTipoStock = new DataTable();
                //listTipoStock = cons.ListTipoStock(pathConnection);
                //DataTable listAlcance = new DataTable();
                //listAlcance = cons.ListAlcance(pathConnection);

                dsListQuerys.Tables.Add(almacenes);
                dsListQuerys.Tables.Add(tableVENTASL); //costo1
                dsListQuerys.Tables.Add(customer);
                dsListQuerys.Tables.Add(listVendedor);
                dsListQuerys.Tables.Add(tableVENTASL2);
                //dsListQuerys.Tables.Add(listTipoStock);
                //dsListQuerys.Tables.Add(listAlcance);

                dsListQuerys.Tables[0].TableName = "almacenes";
                dsListQuerys.Tables[1].TableName = "costo1";
                dsListQuerys.Tables[2].TableName = "data";
                dsListQuerys.Tables[3].TableName = "vendedor";
                dsListQuerys.Tables[4].TableName = "costo2";
                /*Recorre y crea  archivos json de acuerdo a los productos que existen en la base de datos*/
                using (StreamWriter jsonListaCuentas = new StreamWriter(pathSaveFile + "Querys" + j + ".json", false))
                    jsonListaCuentas.WriteLine(JsonConvert.SerializeObject(dsListQuerys, Formatting.None).ToString().Replace("  ", ""));
            }
        }

        public void GenerateFulltables(string pathSaveFile, string pathConnection)
        {
            Int16 valError = 0;
            for (Int16 i = 1; i <= 12; i++)
            {
                DataSet dsListProducts = new DataSet();
                DataTable datos1 = new DataTable();
                datos1 = cons.GetFullTableC1a(pathConnection, i);
                DataTable datos2 = new DataTable();
                datos2 = cons.GetFullTableC1b(pathConnection, i);
                DataTable datos3 = new DataTable();
                datos3 = cons.GetFullTableC1c(pathConnection, i);

                datos2.Merge(datos3); //Fusiona los datos del los registros que no tengan COSTO1
                datos1.Merge(datos2); //Fusiona los datos del los registros que no tengan COSTO1 en la tabla ventasl, 
                //con esto se tiene todos los datos de la base de datos con sus respectivos códigos de COSTO1

                dsListProducts.Tables.Add(datos1);
                try
                {
                    dsListProducts.Tables[0].TableName = "data";
                }
                catch (Exception)
                {
                    valError++;
                    dsListProducts.Tables[0].TableName = "data" + valError.ToString();
                }
                using (StreamWriter jsonListaCuentas = new StreamWriter(pathSaveFile + "FullTable" + i + ".json", false))
                {
                    jsonListaCuentas.WriteLine(JsonConvert.SerializeObject(dsListProducts, Formatting.None).ToString().Replace("  ", ""));
                }
            }
        }
        //Jorge Luis|15/11/2017|RW-*
        /*Método para **/
        public void GenerateListProductsByMonth(string pathSaveFile, string pathConnection)
        {
            Int16 valError = 0;
            for (Int16 i = 0; i <= 12; i++)
            {
                DataSet dsListProducts = new DataSet();
                DataTable datos = new DataTable();
                datos = cons.ListProducts(i, pathConnection);
                dsListProducts.Tables.Add(datos);
                try
                {
                    dsListProducts.Tables[0].TableName = "data";
                }
                catch (Exception)
                {
                    valError++;
                    dsListProducts.Tables[0].TableName = "data" + valError.ToString();
                }
                /*Recorre y crea  archivos json de acuerdo a los productos que existen en la base de datos*/
                using (StreamWriter jsonListaCuentas = new StreamWriter(pathSaveFile + "Products" + i + ".json", false))
                {
                    jsonListaCuentas.WriteLine(JsonConvert.SerializeObject(dsListProducts, Formatting.None).ToString().Replace("  ", ""));
                }
            }
        }
        //Jorge Luis|15/11/2017|RW-*
        /*Método para generar lista de productos de acuerdo a los almacenes en los 12 meses, almacena los productos de acuerdo a la lista
         de alamacenes que existen en su respectivo mes*/
        public void GenerateListProductsByStore(string pathSaveFile, string pathConnection)
        {
            for (Int16 j = 1; j <= 12; j++)
            {
                DataSet dsListProductsByStore = new DataSet(); //Inicializa el Dataser principal que será convertido a json
                DataTable store = new DataTable(); //Crea una tabla que almacenará la lista de almacenes
                store = cons.ListAlmacen(pathConnection, j); // Obtiene la lista de almacenes 
                DataRow[] currentRows = store.Select(null, null, DataViewRowState.CurrentRows); //Consulta linq
                DataTable almacenesProducts = new DataTable(); // Crea una tabla donde se almacenará lista de productos de acuerdo a los almacenes
                Int32 val = 0;
                foreach (DataRow item in currentRows) //Recorre la lista de almacenes
                {
                    try
                    {
                        almacenesProducts = cons.GetProductsByStore(pathConnection, j, item[0].ToString().Trim()); //Invoca al método que que requiere de 3 parámetros (path de la base de datos, el mes, id del almacén), con esto obtiene la lista de productos de acuerdo al mes y id de almacén.
                        dsListProductsByStore.Tables.Add(almacenesProducts); // Se agrega la tabla al datalist
                        dsListProductsByStore.Tables[val].TableName = item[0].ToString().Trim(); // Se le asigna un nombre a esta tabla
                        val++;
                    }
                    catch (Exception)
                    {
                        almacenesProducts = cons.GetProductsByStore(pathConnection, j, item[0].ToString().Trim()); //Invoca al método que que requiere de 3 parámetros (path de la base de datos, el mes, id del almacén), con esto obtiene la lista de productos de acuerdo al mes y id de almacén.
                        dsListProductsByStore.Tables.Add(almacenesProducts); // Se agrega la tabla al datalist
                        dsListProductsByStore.Tables[val].TableName = item[0].ToString().Trim() + val.ToString(); // Se le asigna un nombre a esta tabla
                        val++;
                    }

                    /*Recorre y crea  archivos json de acuerdo a los productos que existen en la base de datos, con el filtro de código de almacén*/
                    using (StreamWriter json = new StreamWriter(pathSaveFile + "StoreProducts" + j + ".json", false))
                        json.WriteLine(JsonConvert.SerializeObject(dsListProductsByStore, Formatting.None).ToString().Trim().Replace("  ", ""));
                }
            }
        }
        //Jorge Luis|23/11/2017|RW-*
        /*Método para generar lista de productos de acuerdo a los almacenes en los 12 meses*/
        public void GenerateListProductsByEmployee(string pathSaveFile, string pathConnection)
        {
            Int16 valError = 0;
            for (Int16 j = 1; j <= 12; j++)
            {
                DataSet dsListProductsByStore = new DataSet();
                DataTable vendedores = new DataTable();
                vendedores = cons.ListVendedor(pathConnection, j);
                DataRow[] currentRows = vendedores.Select(null, null, DataViewRowState.CurrentRows);
                DataTable Products = new DataTable();
                foreach (DataRow item in currentRows)
                {
                    Products = cons.GetProductsByEmployee(pathConnection, j, item[0].ToString().Trim());
                    dsListProductsByStore.Tables.Add(Products);
                    try
                    {
                        dsListProductsByStore.Tables[0].TableName = item[0].ToString().Trim();
                    }
                    catch (Exception)
                    {
                        dsListProductsByStore.Tables[0].TableName = item[0].ToString().Trim() + valError.ToString();
                    }
                    /*Recorre y crea  archivos json de acuerdo a los productos que existen en la base de datos, con el filtro de código de almacén*/
                    using (StreamWriter json = new StreamWriter(pathSaveFile + "EmployeeProducts" + j + ".json", false))
                        json.WriteLine(JsonConvert.SerializeObject(dsListProductsByStore, Formatting.None).ToString().Trim());
                }
            }
        }
        //Jorge Luis|23/11/2017|RW-*
        /*Método para generar lista de productos de acuerdo a COSTO1 en los 12 meses*/
        public void GenerateListProductsByCOSTO1(string pathSaveFile, string pathConnection)
        {
            for (Int16 j = 1; j <= 12; j++)
            {
                DataSet dsListProductsByCOSTO1 = new DataSet();
                DataTable tableVENTASL = new DataTable();
                tableVENTASL = cons.ListCOSTO1(pathConnection, j);
                DataTable tableVENTAS = new DataTable();
                tableVENTAS = cons.ListCOSTO1Nulls(pathConnection, j);
                tableVENTASL.Merge(tableVENTAS);

                DataRow[] currentRows = tableVENTASL.Select(null, null, DataViewRowState.CurrentRows);
                DataTable ProductsVentas = new DataTable();
                DataTable ProductsVentasL = new DataTable();
                Int32 val = 0;
                foreach (DataRow item in currentRows)
                {
                    ProductsVentas = cons.GetProductsByCOSTO1Ventas(pathConnection, j, item[0].ToString().Trim());
                    ProductsVentasL = cons.GetProductsByCOSTO1VentasL(pathConnection, j, item[0].ToString().Trim());
                    ProductsVentas.Merge(ProductsVentasL);
                    dsListProductsByCOSTO1.Tables.Add(ProductsVentas);
                    try
                    {
                        dsListProductsByCOSTO1.Tables[val].TableName = item[0].ToString().Trim();
                    }
                    catch
                    {
                        dsListProductsByCOSTO1.Tables[val].TableName = item[0].ToString().Trim() + "1";
                    }
                    val++;
                    /*Recorre y crea  archivos json de acuerdo a los productos que existen en la base de datos, con el filtro de código de almacén*/
                    using (StreamWriter json = new StreamWriter(pathSaveFile + "Costo1Products" + j + ".json", false))
                        json.WriteLine(JsonConvert.SerializeObject(dsListProductsByCOSTO1, Formatting.None).ToString().Trim().Replace("  ", ""));
                }
            }
        }
        //Jorge Luis|23/11/2017|RW-*
        /*Método para generar lista de productos de acuerdo a COSTO1 en los 12 meses*/
        public void GenerateListProductsByCOSTO2(string pathSaveFile, string pathConnection)
        {
            for (Int16 j = 1; j <= 12; j++)
            {
                DataSet dsListProductsByCOSTO2 = new DataSet();
                DataTable tableVENTASL = new DataTable();
                tableVENTASL = cons.ListCOSTO2(pathConnection, j);
                DataTable tableVENTAS = new DataTable();
                tableVENTAS = cons.ListCOSTO2Nulls(pathConnection, j);
                tableVENTASL.Merge(tableVENTAS);

                DataRow[] currentRows = tableVENTASL.Select(null, null, DataViewRowState.CurrentRows);
                DataTable ProductsVentas = new DataTable();
                DataTable ProductsVentasL = new DataTable();
                Int32 val = 0;
                foreach (DataRow item in currentRows)
                {
                    ProductsVentas = cons.GetProductsByCOSTO2Ventas(pathConnection, j, item[0].ToString().Trim());
                    ProductsVentasL = cons.GetProductsByCOSTO2VentasL(pathConnection, j, item[0].ToString().Trim());
                    ProductsVentas.Merge(ProductsVentasL);
                    dsListProductsByCOSTO2.Tables.Add(ProductsVentas);
                    try
                    {
                        dsListProductsByCOSTO2.Tables[val].TableName = item[0].ToString().Trim();
                    }
                    catch
                    {
                        dsListProductsByCOSTO2.Tables[val].TableName = item[0].ToString().Trim() + "1";
                    }
                    val++;
                    /*Recorre y crea  archivos json de acuerdo a los productos que existen en la base de datos, con el filtro de código de almacén*/
                    using (StreamWriter json = new StreamWriter(pathSaveFile + "Costo2Products" + j + ".json", false))
                        json.WriteLine(JsonConvert.SerializeObject(dsListProductsByCOSTO2, Formatting.None).ToString().Trim().Replace("  ", ""));
                }
            }
        }
        //Jorge Luis|01/12/2017|RW-*
        /*Método para generar lista de productos de acuerdo a los clientes en los 12 meses, almacena los productos de acuerdo a la lista
         de clientes que existen en su respectivo mes*/
        public void GenerateListProductsByCustomer(string pathSaveFile, string pathConnection)
        {
            for (Int16 j = 1; j <= 12; j++)
            {
                DataSet dsListProductsByCustomer = new DataSet(); //Inicializa el Dataser principal que será convertido a json
                DataTable customer = new DataTable(); //Crea una tabla que almacenará la lista de clientes
                customer = cons.ListCustomer(pathConnection, j); // Obtiene la lista de clientes 
                int totalcustomer = customer.Rows.Count;
                if (totalcustomer != 0)
                {
                    DataRow[] currentRows = customer.Select(null, null, DataViewRowState.CurrentRows); //Consulta linq
                    DataTable customerProducts = new DataTable(); // Crea una tabla donde se almacenará lista de productos de acuerdo a los clientes
                    Int32 val = 0;
                    Int16 valError = 0;
                    foreach (DataRow item in currentRows) //Recorre la lista de clientes
                    {
                        customerProducts = cons.GetProductsByCustomer(pathConnection, j, item[0].ToString().Trim()); //Invoca al método que que requiere de 3 parámetros (path de la base de datos, el mes, id del cliente), con esto obtiene la lista de productos de acuerdo al mes y id de cliente.
                        dsListProductsByCustomer.Tables.Add(customerProducts); // Se agrega la tabla al datalist
                        try
                        {
                            dsListProductsByCustomer.Tables[val].TableName = item[0].ToString().Trim(); // Se le asigna un nombre a esta tabla
                        }
                        catch (Exception)
                        {
                            dsListProductsByCustomer.Tables[val].TableName = item[0].ToString().Trim() + valError.ToString();
                        }
                        val++;
                        /*Recorre y crea  archivos json de acuerdo a los productos que existen en la base de datos, con el filtro de código de cliente*/
                        using (StreamWriter json = new StreamWriter(pathSaveFile + "CustomerProducts" + j + ".json", false))
                            json.WriteLine(JsonConvert.SerializeObject(dsListProductsByCustomer, Formatting.None).ToString().Trim().Replace("  ", ""));
                    }
                }
                else
                    j++;
            }
        }
        //Jorge Luis|01/12/2017|RW-*
        /*Método para generar lista de productos de acuerdo a los clientes en los 12 meses, almacena los productos de acuerdo a la lista
         de alcance que existen en su respectivo mes*/
        public void GenerateListProductsByAlcance(string pathSaveFile, string pathConnection)
        {
            for (Int16 j = 1; j <= 12; j++)
            {
                DataSet dsListProductsByAlcance = new DataSet(); //Inicializa el Dataser principal que será convertido a json
                DataTable trueProducts = new DataTable();
                trueProducts = cons.GetProductsByAlcance(pathConnection, j, ".T."); //Invoca al método que que requiere de 3 parámetros (path de la base de datos, el mes, id del cliente), con esto obtiene la lista de productos de acuerdo al mes y id de estado(true).
                dsListProductsByAlcance.Tables.Add(trueProducts);
                dsListProductsByAlcance.Tables[0].TableName = "true";
                DataTable falseProducts = new DataTable();
                falseProducts = cons.GetProductsByAlcance(pathConnection, j, ".F."); //Invoca al método que que requiere de 3 parámetros (path de la base de datos, el mes, id del cliente), con esto obtiene la lista de productos de acuerdo al mes y id de estado(false).
                dsListProductsByAlcance.Tables.Add(falseProducts);
                dsListProductsByAlcance.Tables[1].TableName = "false";
                /*Recorre y crea  archivos json de acuerdo a los productos que existen en la base de datos, con el filtro de código de cliente*/
                using (StreamWriter json = new StreamWriter(pathSaveFile + "AlcanceProducts" + j + ".json", false))
                    json.WriteLine(JsonConvert.SerializeObject(dsListProductsByAlcance, Formatting.None).ToString().Trim().Replace("  ", ""));
            }
        }
        //Jorge Luis|01/12/2017|RW-*
        /*Método para generar lista de productos de acuerdo a los clientes en los 12 meses, almacena los productos de acuerdo a la lista
         de alcance que existen en su respectivo mes*/
        public void GenerateListProductsByStock(string pathSaveFile, string pathConnection)
        {
            for (Int16 j = 1; j <= 12; j++)
            {
                DataSet dsListProductsByStock = new DataSet(); //Inicializa el Dataser principal que será convertido a json
                DataTable trueProducts = new DataTable();
                trueProducts = cons.GetProductsByStock(pathConnection, j, ".T."); //Invoca al método que que requiere de 3 parámetros (path de la base de datos, el mes, id del cliente), con esto obtiene la lista de productos de acuerdo al mes y id de estado(true).
                dsListProductsByStock.Tables.Add(trueProducts);
                dsListProductsByStock.Tables[0].TableName = "true";
                DataTable falseProducts = new DataTable();
                falseProducts = cons.GetProductsByStock(pathConnection, j, ".F."); //Invoca al método que que requiere de 3 parámetros (path de la base de datos, el mes, id del cliente), con esto obtiene la lista de productos de acuerdo al mes y id de estado(false).
                dsListProductsByStock.Tables.Add(falseProducts);
                dsListProductsByStock.Tables[1].TableName = "false";
                /*Recorre y crea  archivos json de acuerdo a los productos que existen en la base de datos, con el filtro de código de cliente*/
                using (StreamWriter json = new StreamWriter(pathSaveFile + "StockProducts" + j + ".json", false))
                    json.WriteLine(JsonConvert.SerializeObject(dsListProductsByStock, Formatting.None).ToString().Trim().Replace("  ", ""));
            }
        }
    }
}
