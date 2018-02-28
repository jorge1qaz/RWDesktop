using System.Data.Odbc;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BusinessLayer
{
    public class Conexion
    {
        //Jorge Luis|04/10/2017|RW-19
        /*Método para realizar la conexión a la base de datos de forma manual*/
        public OdbcConnection cn = new OdbcConnection();
        public OdbcConnection cnInit = new OdbcConnection();
        //Cadena local Contasis
        //public SqlConnection cadena = new SqlConnection("data source=localhost\\MSSQLSERVER01;initial catalog=reportesweb;integrated security=True;MultipleActiveResultSets=True;");
        // Cadena local casa
        //public SqlConnection cadena = new SqlConnection("data source=TOSHIBA;initial catalog=reportesweb;integrated security=True;MultipleActiveResultSets=True;");
        public SqlConnection cadena = new SqlConnection("data source=70.38.70.172;initial catalog=reportesweb;user id=jorge;password=X@cH7k+t^aC[;MultipleActiveResultSets=True;");
        Paths paths = new Paths();
        //Jorge Luis|23/10/2017|RW-19
        /*Método para realizar la conexión a la base de datos con parametro*/
        public void Conectar(string path)
        {
            try
            {
                cn.ConnectionString = "Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" +
                   @"" + path + ";";
                cn.Open();
            }
            catch (System.Exception ex)
            {
                Application.Restart();
                //MessageBox.Show("Error de tipo:" + ex.Message, "Conexión fallida a la base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Jorge Luis|23/10/2017|RW-19
        /*Método para realizar la conexión a la base de datos empleando path y a las tablas de la raiz del sistema*/
        public void ConnectInit()
        {
            try
            {
                cnInit.ConnectionString = "Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" +
                    @"" + paths.readPathInstanceIContasisInit().ToString().Replace('\\', '/') + "/" + ";";
                cnInit.Open();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error de tipo: " + ex.Message, " Conexión fallida a la base de datos inicial", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Jorge Luis|23/10/2017|RW-19
        /*Método para realizar la desconexión a la base de datos empleando path y a las tablas de la raiz del sistema*/
        public void DisconnectInit()
        {
            try
            {
                cnInit.Close();
            }
            catch (System.Exception ex)
            {
                Application.Restart();
                //MessageBox.Show("Error de tipo: " + ex.Message, " Conexión fallida a la base de datos inicial", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Jorge Luis|02/11/2017|RW-19
        /*Método para realizar la conexión a la base de datos empleando path y a las tablas de la raiz del sistema*/
        public void ConnectDbWeb()
        {
            try
            {
                cadena.Open();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error de tipo:" + ex.Message, "Conexión fallida a la base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void DisconnectDbWeb()
        {
            try
            {
                cadena.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error de tipo:" + ex.Message, "Desconexión fallida a la base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}