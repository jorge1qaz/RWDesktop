﻿using BusinessLayer;
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
using System.Diagnostics;

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

            if (MessageBox.Show("Estimado usuario, hemos detectado que no tienes instalado el driver (Visual FoxPro ODBC Driver), pulsa el botón “Aceptar” para descargarlo, ejecútalo y vuelve a iniciar. En caso de que no se abra la ventana de descarga, descárguelo de forma manual en el siguiente enlace. \r" + paths.nameDomain + "/updates/vfpodbc.msi", "Error de driver", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                System.Diagnostics.Process.Start(paths.nameDomain + "/updates/vfpodbc.msi");

            //grdPruebas2.DataSource = miNegocioAlDia.GetTotalByRubro("d:", @"C:\Contasis14\2017\01\conta", "N005", true);
            //grdPruebas.DataSource = consb.FilterRubro(@"C:\Contasis14\2016\01\conta", "N005");
            //grdPruebas3.DataSource = consb.SumNhaberDiario(@"C:\Contasis14\2016\01\conta", 12, "701102");

            DataTable dataTable = new DataTable();
            //dataTable = consb.GetTotalMonthByRubro(@"C:\Contasis14\2015\ff\conta", "A115", "CCOD_BAL2");
            //dataTable = consb.ListSaldoInicial1(@"C:\Contasis14\2015\ff\conta");
            //grdPruebas.DataSource = dataTable;
            //grdPruebas2.DataSource = consb.ListSaldoInicial2(@"C:\Contasis14\2015\ff\conta");
            //grd3.DataSource = consb.ListSaldoInicial3(@"C:\Contasis14\2015\ff\conta");

            //DataSet dataSet = new DataSet();
            //dataSet.Tables.Add(dataTable);
            //using (StreamWriter json = new StreamWriter("d:/list1.json", false))
            //    json.WriteLine(JsonConvert.SerializeObject(dataSet, Formatting.None).ToString().Replace("  ", ""));

            grdPruebas.DataSource = consb.GetTableByRubro(@"D:\contasis\empresas\2015\01\conta", "CCOD_BAL2", "CCOD_BALN2", "A105", false);
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void grdPruebas2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pruebas_MouseEnter(object sender, EventArgs e)
        {

        }
    }
}
