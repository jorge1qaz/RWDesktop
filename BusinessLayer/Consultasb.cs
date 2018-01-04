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
        public DataTable TableForEstadoResultado(string pathConection, string idRubro, string filter)
        {
            string query = "";                                                                    // False SumNdebeDiario  (DEBE)
            query = " select sum((NDEBE0 - NHABER0))*(-1) as a, sum((NDEBED0 - NHABERD0))*(-1) as ad, " 
                + " sum((NDEBE1 - NHABER1))*(-1) as b, sum((NDEBED1 - NHABERD1))*(-1) as bd, "  // a, b, c... = Haber en soles, ad, bd, cd... = Haber en dólares
                + " sum((NDEBE2 - NHABER2))*(-1) as c, sum((NDEBED2 - NHABERD2))*(-1) as cd, "
                + " sum((NDEBE3 - NHABER3))*(-1) as d, sum((NDEBED3 - NHABERD3))*(-1) as dd, "
                + " sum((NDEBE4 - NHABER4))*(-1) as e, sum((NDEBED4 - NHABERD4))*(-1) as ed, "
                + " sum((NDEBE5 - NHABER5))*(-1) as f, sum((NDEBED5 - NHABERD5))*(-1) as fd, "
                + " sum((NDEBE6 - NHABER6))*(-1) as g, sum((NDEBED6 - NHABERD6))*(-1) as gd, "
                + " sum((NDEBE7 - NHABER7))*(-1) as h, sum((NDEBED7 - NHABERD7))*(-1) as hd, "
                + " sum((NDEBE8 - NHABER8))*(-1) as i, sum((NDEBED8 - NHABERD8))*(-1) as id, "
                + " sum((NDEBE9 - NHABER9))*(-1) as j, sum((NDEBED9 - NHABERD9))*(-1) as jd, "
                + " sum((NDEBE10 - NHABER10))*(-1) as k, sum((NDEBED10 - NHABERD10))*(-1) as kd, "
                + " sum((NDEBE11 - NHABER11))*(-1) as l, sum((NDEBED11 - NHABERD11))*(-1) as ld, "
                + " sum((NDEBE12 - NHABER12))*(-1) as m, sum((NDEBED12 - NHABERD12))*(-1) as md, "
                + " sum((NDEBE13 - NHABER13))*(-1) as n, sum((NDEBED13 - NHABERD13))*(-1) as nd, "
                + " sum((NDEBE14 - NHABER14))*(-1) as o, sum((NDEBED14 - NHABERD14))*(-1) as od, "
                + " sum((NDEBE15 - NHABER15))*(-1) as p, sum((NDEBED15 - NHABERD15))*(-1) as pd from PLAN "
                + " where " + filter + " = '" + idRubro + "'"
                + " and NNIVEL = 3 ";
            return dat.extrae(query, pathConection);
        }
    }
}
