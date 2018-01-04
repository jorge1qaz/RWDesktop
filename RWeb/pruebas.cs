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
using Newtonsoft.Json.Linq;

namespace RWeb
{
    public partial class pruebas : MetroFramework.Forms.MetroForm
    {
        public pruebas()
        {
            InitializeComponent();
        }
        private void pruebas_Load(object sender, EventArgs e)
        {
            //grdPruebas2.DataSource = miNegocioAlDia.GetTotalByRubro("d:", @"C:\Contasis14\2017\01\conta", "N005", true);
            //grdPruebas.DataSource = consb.FilterRubro(@"C:\Contasis14\2016\01\conta", "N005");
            //grdPruebas3.DataSource = consb.SumNhaberDiario(@"C:\Contasis14\2016\01\conta", 12, "701102");

            //estadoDeResultadoPMS
            DataTable dataTable = new DataTable();
            dataTable = consb.TableForEstadoResultado(@"C:\Contasis14\2017\02\conta", "N015", "CCOD_BAL2");
            grdPruebas2.DataSource = dataTable;

        }
        AccesoDatos dat = new AccesoDatos();
        Consultas cons = new Consultas();
        Consultasb consb = new Consultasb();
        Transferencia trans = new Transferencia();
        R_MiNegocioAlDia miNegocioAlDia = new R_MiNegocioAlDia();
        R_MargenUtilidad margenUtilidad = new R_MargenUtilidad();
        Paths paths = new Paths();
        Directorios dirs = new Directorios();
        VerificarInstancia vi = new VerificarInstancia();
        R_EstadoDeResultadoPMS estadoDeResultadoPMS = new R_EstadoDeResultadoPMS();
    }
}
