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
        //double totalVentas;
        //double totalCajaBancosHaber;
        //double totalCajaBancosDebe;
        //decimal totalCajaBancos;
        //double totalCobrarHaber;
        //double totalCobrarDebe;
        //decimal totalCobrar;
        public class Post
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string Link { get; set; }
            public IList<string> Categories { get; set; }
        }
        
        private void pruebas_Load(object sender, EventArgs e)
        {
            List<Post> posts = GetPosts();

            JObject rss =
                new JObject(
                    new JProperty("channel",
                        new JObject(
                            new JProperty("title", "James Newton-King"),
                            new JProperty("link", "http://james.newtonking.com"),
                            new JProperty("description", "James Newton-King's blog."),
                            new JProperty("item",
                                new JArray(
                                    from p in posts
                                    orderby p.Title
                                    select new JObject(
                                        new JProperty("title", p.Title),
                                        new JProperty("description", p.Description),
                                        new JProperty("link", p.Link),
                                        new JProperty("category",
                                            new JArray(
                                                from c in p.Categories
                                                select new JValue(c)))))))));
            MessageBox.Show(json.ToString());
            #region temp
            //grdPruebas2.DataSource = miNegocioAlDia.GetTotalByRubro("d:", @"C:\Contasis14\2016\01\conta", "N005", true);
            //grdPruebas.DataSource = consb.FilterRubro(@"C:\Contasis14\2016\01\conta", "N005");
            //grdPruebas3.DataSource = consb.SumNhaberDiario(@"C:\Contasis14\2016\01\conta", 12, "701102");

            //DataTable tableDataN005 = new DataTable();
            //tableDataN005 = miNegocioAlDia.GetTotalByRubro("d:", @"C:\Contasis14\2016\01\conta", "N005", true);
            //try
            //{ totalVentas = tableDataN005.AsEnumerable().Where(x => x.Field<Int16>("a") == 12).Select(x => x.Field<double>("c")).Sum(); }
            //catch (Exception)
            //    { totalVentas = 0; }
            //MessageBox.Show(totalVentas.ToString());

            ////Cajas y bancos
            //DataTable tableDataA105Haber = new DataTable();
            //tableDataA105Haber = miNegocioAlDia.GetTotalByRubro("d:", @"C:\Contasis14\2016\01\conta", "A105", true);
            //try
            //{ totalCajaBancosHaber = tableDataA105Haber.AsEnumerable().Where(x => x.Field<Int16>("a") == 12).Select(x => x.Field<double>("c")).Sum(); }
            //catch (Exception)
            //    { totalCajaBancosHaber = 0; }
            //MessageBox.Show(totalCajaBancosHaber.ToString());

            //DataTable tableDataA105Debe = new DataTable();
            //tableDataA105Debe = miNegocioAlDia.GetTotalByRubro("d:", @"C:\Contasis14\2016\01\conta", "A105", false);
            //try
            //{ totalCajaBancosDebe = tableDataA105Debe.AsEnumerable().Where(x => x.Field<Int16>("a") == 12).Select(x => x.Field<double>("c")).Sum(); }
            //catch (Exception)
            //{ totalCajaBancosDebe = 0; }
            //MessageBox.Show(totalCajaBancosDebe.ToString());
            //totalCajaBancos = Convert.ToDecimal(totalCajaBancosDebe) - Convert.ToDecimal(totalCajaBancosHaber);
            //MessageBox.Show("Total! Papu!!: " + totalCajaBancos.ToString());

            ////Cuentas por cobrar
            //DataTable tableDataA115Haber = new DataTable();
            //tableDataA115Haber = miNegocioAlDia.GetTotalByRubro("d:", @"C:\Contasis14\2016\01\conta", "A115", true);
            //try
            //{ totalCobrarHaber = tableDataA115Haber.AsEnumerable().Where(x => x.Field<Int16>("a") == 12).Select(x => x.Field<double>("c")).Sum(); }
            //catch (Exception)
            //{ totalCobrarHaber = 0; }
            //MessageBox.Show(totalCobrarHaber.ToString());

            //DataTable tableDataA115Debe = new DataTable();
            //tableDataA115Debe = miNegocioAlDia.GetTotalByRubro("d:", @"C:\Contasis14\2016\01\conta", "A115", false);
            //try
            //{
            //    totalCobrarDebe = tableDataA115Debe.AsEnumerable().Where(x => x.Field<Int16>("a") == 12).Select(x => x.Field<double>("c")).Sum(); 
            //    if (totalCobrarDebe < 0)
            //        MessageBox.Show("negrativo mi hedmano: " + totalCobrarDebe.ToString());
            //}
            //catch (Exception)
            //{ totalCobrarDebe = 0; }
            //MessageBox.Show(totalCobrarDebe.ToString());
            //totalCobrar = Convert.ToDecimal(totalCobrarDebe) - Convert.ToDecimal(totalCobrarHaber);
            //MessageBox.Show("Total! Papu!!: " + totalCobrar.ToString());
            #endregion
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
    }
}
