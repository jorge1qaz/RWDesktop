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
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "A105");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "N015");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "N210");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "N220");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "N230");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "N520");

            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "N005", true);  // Haber 7
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "N010", false); // Debe  6 
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "N103", true);
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "N105", true);

            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "N110", true);
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "N205", false);
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "N215", false);
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "N225", false);
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "N235", false);
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "N305", true);
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "N310", false);
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "N315", false);
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "N405", true);
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "N410", true);
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "N415", true);
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "N420", false);
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "N425", false);
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "N430", false);
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "N505", true);
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "N510", false);
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "N515", true);
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "N525", false);

            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "N805", false);
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "N810", false);
            //Cuentas por cobrar y pagar
            ExportTable(pathSaveFile, pathConnection, "CCOD_BALN2", "NA120"); //CCOD_BALN2 (NRubro + nombre + .json)
            ExportTable(pathSaveFile, pathConnection, "CCOD_BALN2", "NP120"); //CCOD_BALN2 (NRubro + nombre + .json)
            ExportTable(pathSaveFile, pathConnection, "CCOD_BALN2", "NP105"); //CCOD_BALN2 (NRubro + nombre + .json)
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "A120");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "P105");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BALN2", "NP105");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "A115");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "A125");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "P110");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "P120");
            ExportTable(pathSaveFile, pathConnection, "CCOD_BAL2", "P121");
        }
        //Jorge Luis|18/12/2017|RW-*
        /*Método ...*/
        public void ExportTable(string pathSaveFile, string pathConnection, string rubro, string idRubro, bool tipoOperacion)
        {
            DataSet dataSet = new DataSet();
            DataTable table = new DataTable();
            for (Int16 i = 0; i <= 15; i++)
            {
                table = consb.TablaDiario(@pathConnection, rubro, idRubro, i, tipoOperacion);
                dataSet.Tables.Add(table);
                dataSet.Tables[i].TableName = i.ToString();
            }
            using (StreamWriter jsonFile = new StreamWriter(pathSaveFile + idRubro + ".json", false))
                jsonFile.WriteLine(JsonConvert.SerializeObject(dataSet, Formatting.None).ToString().Replace("  ", ""));
            dataSet.Clear();
        }
        //Jorge Luis|18/12/2017|RW-*
        /*Método ...*/
        public void ExportTable(string pathSaveFile, string pathConnection, string rubro, string idRubro)
        {
            DataSet dataSet = new DataSet();
            DataTable table = new DataTable();
            for (Int16 i = 0; i <= 13; i++)
            {
                table = consb.TablaDiario(@pathConnection,rubro, idRubro, i);
                dataSet.Tables.Add(table);
                dataSet.Tables[i].TableName = i.ToString();
            }
            using (StreamWriter jsonFile = new StreamWriter(pathSaveFile + idRubro + ".json", false))
                jsonFile.WriteLine(JsonConvert.SerializeObject(dataSet, Formatting.None).ToString().Replace("  ", ""));
            dataSet.Clear();
        }
    }
}
