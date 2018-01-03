using System;
using System.Data;

namespace BusinessLayer
{
    //Consultas para los reportes de: "Mi negocio al día"
    public class Consultasb
    {
        AccesoDatos dat = new AccesoDatos();
        Paths paths = new Paths();
        //Jorge Luis|13/12/2017|RW-91
        /*Método para extraer datos*/
        public DataTable ListDatosGenerales()
        {
            return dat.extraeInit(
                "SELECT p.Nyear, e.Ccod_emp, e.Cdsc, e.Cdir, e.Cgiro, e.Cnit, p.Mpath1 " +
                " from PATH.DBF as p " +
                " inner join EMPRESAS.DBF as e " +
                " on p.Ccod_emp = e.Ccod_emp " +
                " Where p.Nyear <= " + DateTime.Now.Year +
                " order by p.Nyear desc"
                );
        }
        //Jorge Luis|13/12/2017|RW-91
        /*Consulta para extraes datos de la tabla VENTAS, con el filtro de CMES como parámetro*/
        public DataTable FilterRubro(string pathConection, string idRubro)
        {
            return dat.extrae(
                " select CCOD_CUE, CDSC from PLAN " +
                " where CCOD_BAL2 = '" + idRubro + "'"
                , pathConection
                );
        }
        //Jorge Luis|13/12/2017|RW-91
        /*Consulta para extraes datos de la tabla VENTAS, con el filtro de CMES como parámetro*/
        public DataTable SumNhaberDiario(string pathConection, Int16 mesProcesoCalculado, string idCuenta)
        {
            string mesParametro = "";
            /*Mientras el mes sea menor a 9, antepone un cero. En caso contrario no lo hace.*/
            if (mesProcesoCalculado <= 9)
                mesParametro = "0" + mesProcesoCalculado.ToString();
            else
                mesParametro = mesProcesoCalculado.ToString();
            return dat.extrae(
                 " select sum(NHABER) as haber from Diario "
                 + " where CCOD_CUE = '" + idCuenta + "' " 
                 +" and CMES = '" + mesParametro + "' " 
                , pathConection
                );
        }
        //Jorge Luis|15/12/2017|RW-91
        /*Consulta para extraes datos de la tabla VENTAS, con el filtro de CMES como parámetro*/
        public DataTable SumNdebeDiario(string pathConection, Int16 mesProcesoCalculado, string idCuenta)
        {
            string mesParametro = "";
            /*Mientras el mes sea menor a 9, antepone un cero. En caso contrario no lo hace.*/
            if (mesProcesoCalculado <= 9)
                mesParametro = "0" + mesProcesoCalculado.ToString();
            else
                mesParametro = mesProcesoCalculado.ToString();
            return dat.extrae(
                 " select sum(NDEBE) as debe from Diario "
                 + " where CCOD_CUE = '" + idCuenta + "' "
                 + " and CMES = '" + mesParametro + "' "
                , pathConection
                );
        }
        //Jorge Luis|15/12/2017|RW-91
        /*Consulta para ...*/
        public DataTable TablaDiario(string pathConection, string idRubro, Int16 mesProcesoCalculado, bool tipoOperacion)
        {
            string mesParametro = "";
            string query = "";
            /*Mientras el mes sea menor a 9, antepone un cero. En caso contrario no lo hace.*/
            if (mesProcesoCalculado <= 9)
                mesParametro = "0" + mesProcesoCalculado.ToString();
            else
                mesParametro = mesProcesoCalculado.ToString();
            if (tipoOperacion)     //True SumNhaberDiario (HABER)
            {
                query = " select d.NHABER as a, d.NHABERD as b from Diario as d "
                     + " inner join PLAN as p on p.CCOD_CUE = d.CCOD_CUE "
                     + " where p.CCOD_BAL2 = '" + idRubro + "'"
                     + " and d.CMES = '" + mesParametro + "' ";
            }
            else                    //False SumNdebeDiario  (DEBE)
            {
                query = " select d.NDEBE as a, d.NDEBED as b from Diario as d "
                     + " inner join PLAN as p on p.CCOD_CUE = d.CCOD_CUE "
                     + " where p.CCOD_BAL2 = '" + idRubro + "'"
                     + " and d.CMES = '" + mesParametro + "' ";
            }
            return dat.extrae(query, pathConection);
        }
        //Jorge Luis|15/12/2017|RW-91
        /*Consulta para ...*/
        public DataTable TablaDiario(string pathConection, string idRubro, Int16 mesProcesoCalculado)
        {
            string mesParametro = "";
            /*Mientras el mes sea menor a 9, antepone un cero. En caso contrario no lo hace.*/
            if (mesProcesoCalculado <= 9)
                mesParametro = "0" + mesProcesoCalculado.ToString();
            else
                mesParametro = mesProcesoCalculado.ToString();
            return dat.extrae(
                " select d.CCOD_CUE as a, d.NHABER as b, d.NDEBE as c, d.NHABERD as d, d.NDEBED as e from Diario as d "              //a = haber, b = debe
                     + " inner join PLAN as p on p.CCOD_CUE = d.CCOD_CUE "
                     + " where p.CCOD_BAL2 = '" + idRubro + "'"
                     + " and d.CMES = '" + mesParametro + "' "
                , pathConection );
        }
        //Jorge Luis|15/12/2017|RW-91
        /*Consulta para ...*/
        public DataTable TablaDiarioN(string pathConection, string idRubro, Int16 mesProcesoCalculado)
        {
            string mesParametro = "";
            /*Mientras el mes sea menor a 9, antepone un cero. En caso contrario no lo hace.*/
            if (mesProcesoCalculado <= 9)
                mesParametro = "0" + mesProcesoCalculado.ToString();
            else
                mesParametro = mesProcesoCalculado.ToString();
            return dat.extrae(
                " select d.CCOD_CUE as a, d.NHABER as b, d.NDEBE as c, d.NHABERD as d, d.NDEBED as e from Diario as d "              //a = haber, b = debe
                     + " inner join PLAN as p on p.CCOD_CUE = d.CCOD_CUE "
                     + " where p.CCOD_BALN2 = '" + idRubro + "'"
                     + " and d.CMES = '" + mesParametro + "' "
                , pathConection);
        }
        //Jorge Luis|21/12/2017|RW-91
        /*Consulta para ...*/
        public DataTable ListCuentasByRubro(string pathConection, string idRubro, Int16 mesProcesoCalculado)
        {
            string mesParametro = "";
            /*Mientras el mes sea menor a 9, antepone un cero. En caso contrario no lo hace.*/
            if (mesProcesoCalculado <= 9)
                mesParametro = "0" + mesProcesoCalculado.ToString();
            else
                mesParametro = mesProcesoCalculado.ToString();
            return dat.extrae(
                " select dist d.CCOD_CUE as a from Diario as d "
                + " inner join PLAN as p on p.CCOD_CUE = d.CCOD_CUE "
                + " where CCOD_BAL2 = TRIM('" + idRubro + "') "
                + " and CMES = '" + mesParametro + "' "
                , pathConection);
        }
        //Jorge Luis|15/12/2017|RW-91
        /*Consulta para ...*/
        public DataTable TableForEstadoResultado(string pathConection, string idRubro, Int16 mesProcesoCalculado, bool tipoOperacion)
        {
            string mesParametro = "";
            string query = "";
            /*Mientras el mes sea menor a 9, antepone un cero. En caso contrario no lo hace.*/
            if (mesProcesoCalculado <= 9)
                mesParametro = "0" + mesProcesoCalculado.ToString();
            else
                mesParametro = mesProcesoCalculado.ToString();
            if (tipoOperacion)                                                      //True SumNhaberDiario (HABER)
                query = " select d.NHABER as a, d.NHABERD as b from Diario as d "   // a = Haber en soles, b = Haber en dólares
                     + " inner join PLAN as p on p.CCOD_CUE = d.CCOD_CUE "
                     + " where p.CCOD_BAL2 = '" + idRubro + "'"
                     + " and d.CMES = '" + mesParametro + "' "
                     + " and p.NNIVEL = 3 ";
            else                                                                    //False SumNdebeDiario  (DEBE)
                query = " select d.NDEBE as a, d.NDEBED as b from Diario as d "                    // a = Haber en soles, b = Haber en dólares
                     + " inner join PLAN as p on p.CCOD_CUE = d.CCOD_CUE "
                     + " where p.CCOD_BAL2 = '" + idRubro + "'"
                     + " and d.CMES = '" + mesParametro + "' "
                     + " and p.NNIVEL = 3 ";
            return dat.extrae(query, pathConection);
        }
        public DataTable TableForEstadoResultado(string pathConection, string idRubro, Int16 mesProcesoCalculado)
        {
            string mesParametro = "";
            string query = "";
            /*Mientras el mes sea menor a 9, antepone un cero. En caso contrario no lo hace.*/
            if (mesProcesoCalculado <= 9)
                mesParametro = "0" + mesProcesoCalculado.ToString();
            else
                mesParametro = mesProcesoCalculado.ToString();
            query = " select d.CCOD_CUE as a, d.NHABER as b, d.NDEBE as c, d.NHABERD as d, d.NDEBED as e from Diario as d "   // a = Haber en soles, b = Haber en dólares
                    + " inner join PLAN as p on p.CCOD_CUE = d.CCOD_CUE "
                    + " where p.CCOD_BAL2 = '" + idRubro + "'"
                    + " and d.CMES = '" + mesParametro + "' "
                    + " and p.NNIVEL = 3 ";
            return dat.extrae(query, pathConection);
        }
        public DataTable TableForEstadoResultado(string pathConection, string idRubro, Int16 mesProcesoCalculado, string filter, bool tipoOperacion)
        {
            string mesParametro = "";
            string query = "";
            /*Mientras el mes sea menor a 9, antepone un cero. En caso contrario no lo hace.*/
            if (mesProcesoCalculado <= 9)
                mesParametro = "0" + mesProcesoCalculado.ToString();
            else
                mesParametro = mesProcesoCalculado.ToString();
            if (tipoOperacion)                                                      // True SumNhaberDiario (HABER)
                query = " select d.NHABER as a, d.NHABERD as b from Diario as d "   // a = Haber en soles, b = Haber en dólares
                     + " inner join PLAN as p on p.CCOD_CUE = d.CCOD_CUE "
                     + " where p.CCOD_BAL2 = '" + idRubro + "'"
                     + " and d.CMES = '" + mesParametro + "' "
                     + " and p.NNIVEL = 3 ";
            else                                                                    // False SumNdebeDiario  (DEBE)
                query = " select d.NDEBE as a, d.NDEBED as b from Diario as d "     // a = Haber en soles, b = Haber en dólares
                     + " inner join PLAN as p on p.CCOD_CUE = d.CCOD_CUE "
                     + " where p." + filter + " = '" + idRubro + "'"
                     + " and d.CMES = '" + mesParametro + "' "
                     + " and p.NNIVEL = 3 ";
            return dat.extrae(query, pathConection);
        }
    }
}
