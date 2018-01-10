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
                + " sum((NDEBE14 - NHABER14))*(-1) as o, sum((NDEBED14 - NHABERD14))*(-1) as od from PLAN"
                + " where " + filter + " = '" + idRubro + "'"
                + " and NNIVEL = 3 ";
            return dat.extrae(query, pathConection);
        }
        public DataTable GetTotalMonthByRubro(string pathConection, string idRubro, string filter, bool tipoOperacion)
        {
            string query = "";
            if (tipoOperacion)
                query = " select sum((NDEBE0 - NHABER0)) as a, sum((NDEBED0 - NHABERD0)) as ad, "
                    + " sum((NDEBE1 - NHABER1)) as b,       sum((NDEBED1 - NHABERD1)) as bd, "
                    + " sum((NDEBE2 - NHABER2)) as c,       sum((NDEBED2 - NHABERD2)) as cd, "
                    + " sum((NDEBE3 - NHABER3)) as d,       sum((NDEBED3 - NHABERD3)) as dd, "
                    + " sum((NDEBE4 - NHABER4)) as e,       sum((NDEBED4 - NHABERD4)) as ed, "
                    + " sum((NDEBE5 - NHABER5)) as f,       sum((NDEBED5 - NHABERD5)) as fd, "
                    + " sum((NDEBE6 - NHABER6)) as g,       sum((NDEBED6 - NHABERD6)) as gd, "
                    + " sum((NDEBE7 - NHABER7)) as h,       sum((NDEBED7 - NHABERD7)) as hd, "
                    + " sum((NDEBE8 - NHABER8)) as i,       sum((NDEBED8 - NHABERD8)) as id, "
                    + " sum((NDEBE9 - NHABER9)) as j,       sum((NDEBED9 - NHABERD9)) as jd, "
                    + " sum((NDEBE10 - NHABER10)) as k,     sum((NDEBED10 - NHABERD10)) as kd, "
                    + " sum((NDEBE11 - NHABER11)) as l,     sum((NDEBED11 - NHABERD11)) as ld, "
                    + " sum((NDEBE12 - NHABER12)) as m,     sum((NDEBED12 - NHABERD12)) as md, "
                    + " sum((NDEBE13 - NHABER13)) as n,     sum((NDEBED13 - NHABERD13)) as nd, "
                    + " sum((NDEBE14 - NHABER14)) as o,     sum((NDEBED14 - NHABERD14)) as od from PLAN "
                    + " where " + filter + " = '" + idRubro + "'"
                    + " and NNIVEL = 3 ";
            else
                query = " select sum((NDEBE0 - NHABER0))*(-1) as a, sum((NDEBED0 - NHABERD0))*(-1) as ad, "
                    + " sum((NDEBE1 - NHABER1))*(-1) as b,      sum((NDEBED1 - NHABERD1))*(-1) as bd, "  // a, b, c... = Haber en soles, ad, bd, cd... = Haber en dólares
                    + " sum((NDEBE2 - NHABER2))*(-1) as c,      sum((NDEBED2 - NHABERD2))*(-1) as cd, "
                    + " sum((NDEBE3 - NHABER3))*(-1) as d,      sum((NDEBED3 - NHABERD3))*(-1) as dd, "
                    + " sum((NDEBE4 - NHABER4))*(-1) as e,      sum((NDEBED4 - NHABERD4))*(-1) as ed, "
                    + " sum((NDEBE5 - NHABER5))*(-1) as f,      sum((NDEBED5 - NHABERD5))*(-1) as fd, "
                    + " sum((NDEBE6 - NHABER6))*(-1) as g,      sum((NDEBED6 - NHABERD6))*(-1) as gd, "
                    + " sum((NDEBE7 - NHABER7))*(-1) as h,      sum((NDEBED7 - NHABERD7))*(-1) as hd, "
                    + " sum((NDEBE8 - NHABER8))*(-1) as i,      sum((NDEBED8 - NHABERD8))*(-1) as id, "
                    + " sum((NDEBE9 - NHABER9))*(-1) as j,      sum((NDEBED9 - NHABERD9))*(-1) as jd, "
                    + " sum((NDEBE10 - NHABER10))*(-1) as k,    sum((NDEBED10 - NHABERD10))*(-1) as kd, "
                    + " sum((NDEBE11 - NHABER11))*(-1) as l,    sum((NDEBED11 - NHABERD11))*(-1) as ld, "
                    + " sum((NDEBE12 - NHABER12))*(-1) as m,    sum((NDEBED12 - NHABERD12))*(-1) as md, "
                    + " sum((NDEBE13 - NHABER13))*(-1) as n,    sum((NDEBED13 - NHABERD13))*(-1) as nd, "
                    + " sum((NDEBE14 - NHABER14))*(-1) as o,    sum((NDEBED14 - NHABERD14))*(-1) as od from PLAN "
                    + " where " + filter + " = '" + idRubro + "'"
                    + " and NNIVEL = 3 ";
            return dat.extrae(query, pathConection);
        }
        public DataTable GetTotalMonthByRubro(string pathConection, string idRubro1, string filter1, string idRubro2, string filter2, bool tipoOperacion)
        {
            string query = "";
            if (tipoOperacion)
                query = " select sum((NDEBE0 - NHABER0)) as a, sum((NDEBED0 - NHABERD0)) as ad, "
                    + " sum((NDEBE1 - NHABER1)) as b,       sum((NDEBED1 - NHABERD1)) as bd, "
                    + " sum((NDEBE2 - NHABER2)) as c,       sum((NDEBED2 - NHABERD2)) as cd, "
                    + " sum((NDEBE3 - NHABER3)) as d,       sum((NDEBED3 - NHABERD3)) as dd, "
                    + " sum((NDEBE4 - NHABER4)) as e,       sum((NDEBED4 - NHABERD4)) as ed, "
                    + " sum((NDEBE5 - NHABER5)) as f,       sum((NDEBED5 - NHABERD5)) as fd, "
                    + " sum((NDEBE6 - NHABER6)) as g,       sum((NDEBED6 - NHABERD6)) as gd, "
                    + " sum((NDEBE7 - NHABER7)) as h,       sum((NDEBED7 - NHABERD7)) as hd, "
                    + " sum((NDEBE8 - NHABER8)) as i,       sum((NDEBED8 - NHABERD8)) as id, "
                    + " sum((NDEBE9 - NHABER9)) as j,       sum((NDEBED9 - NHABERD9)) as jd, "
                    + " sum((NDEBE10 - NHABER10)) as k,     sum((NDEBED10 - NHABERD10)) as kd, "
                    + " sum((NDEBE11 - NHABER11)) as l,     sum((NDEBED11 - NHABERD11)) as ld, "
                    + " sum((NDEBE12 - NHABER12)) as m,     sum((NDEBED12 - NHABERD12)) as md, "
                    + " sum((NDEBE13 - NHABER13)) as n,     sum((NDEBED13 - NHABERD13)) as nd, "
                    + " sum((NDEBE14 - NHABER14)) as o,     sum((NDEBED14 - NHABERD14)) as od from PLAN "
                    + " where " + filter1 + " = '" + idRubro1 + "'"
                    + " or " + filter2 + " = '" + idRubro2 + "'";
            else
                query = " select sum((NDEBE0 - NHABER0))*(-1) as a, sum((NDEBED0 - NHABERD0))*(-1) as ad, "
                    + " sum((NDEBE1 - NHABER1))*(-1) as b,      sum((NDEBED1 - NHABERD1))*(-1) as bd, "  // a, b, c... = Haber en soles, ad, bd, cd... = Haber en dólares
                    + " sum((NDEBE2 - NHABER2))*(-1) as c,      sum((NDEBED2 - NHABERD2))*(-1) as cd, "
                    + " sum((NDEBE3 - NHABER3))*(-1) as d,      sum((NDEBED3 - NHABERD3))*(-1) as dd, "
                    + " sum((NDEBE4 - NHABER4))*(-1) as e,      sum((NDEBED4 - NHABERD4))*(-1) as ed, "
                    + " sum((NDEBE5 - NHABER5))*(-1) as f,      sum((NDEBED5 - NHABERD5))*(-1) as fd, "
                    + " sum((NDEBE6 - NHABER6))*(-1) as g,      sum((NDEBED6 - NHABERD6))*(-1) as gd, "
                    + " sum((NDEBE7 - NHABER7))*(-1) as h,      sum((NDEBED7 - NHABERD7))*(-1) as hd, "
                    + " sum((NDEBE8 - NHABER8))*(-1) as i,      sum((NDEBED8 - NHABERD8))*(-1) as id, "
                    + " sum((NDEBE9 - NHABER9))*(-1) as j,      sum((NDEBED9 - NHABERD9))*(-1) as jd, "
                    + " sum((NDEBE10 - NHABER10))*(-1) as k,    sum((NDEBED10 - NHABERD10))*(-1) as kd, "
                    + " sum((NDEBE11 - NHABER11))*(-1) as l,    sum((NDEBED11 - NHABERD11))*(-1) as ld, "
                    + " sum((NDEBE12 - NHABER12))*(-1) as m,    sum((NDEBED12 - NHABERD12))*(-1) as md, "
                    + " sum((NDEBE13 - NHABER13))*(-1) as n,    sum((NDEBED13 - NHABERD13))*(-1) as nd, "
                    + " sum((NDEBE14 - NHABER14))*(-1) as o,    sum((NDEBED14 - NHABERD14))*(-1) as od from PLAN "
                    + " where " + filter1 + " = '" + idRubro1 + "'"
                    + " or " + filter2 + " = '" + idRubro2 + "'";
            return dat.extrae(query, pathConection);
        }
        public DataTable GetTotalMonthByRubro(string pathConection, string idRubro, string filter)
        {
            string query = "";                                                                    // False SumNdebeDiario  (DEBE)
            query = " select (sum(NDEBE0 - NHABER0) + sum(NDEBE1 - NHABER1)) as a, (sum(NDEBED0 - NHABERD0) + sum(NDEBED1 - NHABERD1)) as ad, "
            + " (sum(NDEBE0 - NHABER0) + sum(NDEBE1 - NHABER1) + sum(NDEBE2 - NHABER2)) as b, (sum(NDEBED0 - NHABERD0) + sum(NDEBED1 - NHABERD1) + sum(NDEBED2 - NHABERD2)) as bd, "
            + " (sum(NDEBE0 - NHABER0) + sum(NDEBE1 - NHABER1) + sum(NDEBE2 - NHABER2) + sum(NDEBE3 - NHABER3)) as c, "
            + " (sum(NDEBED0 - NHABERD0) + sum(NDEBED1 - NHABERD1) + sum(NDEBED2 - NHABERD2) + sum(NDEBED3 - NHABERD3)) as cd, "
            + " (sum(NDEBE0 - NHABER0) + sum(NDEBE1 - NHABER1) + sum(NDEBE2 - NHABER2) + sum(NDEBE3 - NHABER3) + sum(NDEBE4 - NHABER4)) as d, "
            + " (sum(NDEBED0 - NHABERD0) + sum(NDEBED1 - NHABERD1) + sum(NDEBED2 - NHABERD2) + sum(NDEBED3 - NHABERD3) + sum(NDEBED4 - NHABERD4)) as dd, "
            + " (sum(NDEBE0 - NHABER0) + sum(NDEBE1 - NHABER1) + sum(NDEBE2 - NHABER2) + sum(NDEBE3 - NHABER3) + sum(NDEBE4 - NHABER4) + sum(NDEBE5 - NHABER5)) as e, "
            + " (sum(NDEBED0 - NHABERD0) + sum(NDEBED1 - NHABERD1) + sum(NDEBED2 - NHABERD2) + sum(NDEBED3 - NHABERD3) + sum(NDEBED4 - NHABERD4) + sum(NDEBED5 - NHABERD5)) as ed, "
            + " (sum(NDEBE0 - NHABER0) + sum(NDEBE1 - NHABER1) + sum(NDEBE2 - NHABER2) + sum(NDEBE3 - NHABER3) + sum(NDEBE4 - NHABER4) + "
            + " sum(NDEBE5 - NHABER5) + sum(NDEBE6 - NHABER6)) as f, "
            + " (sum(NDEBED0 - NHABERD0) + sum(NDEBED1 - NHABERD1) + sum(NDEBED2 - NHABERD2) + sum(NDEBED3 - NHABERD3) + sum(NDEBED4 - NHABERD4) + "
            + " sum(NDEBED5 - NHABERD5) + sum(NDEBED6 - NHABERD6)) as fd, "
            + " (sum(NDEBE0 - NHABER0) + sum(NDEBE1 - NHABER1) + sum(NDEBE2 - NHABER2) + sum(NDEBE3 - NHABER3) + sum(NDEBE4 - NHABER4) + "
            + " sum(NDEBE5 - NHABER5) + sum(NDEBE6 - NHABER6) + sum(NDEBE7 - NHABER7)) as g, "
            + " (sum(NDEBED0 - NHABERD0) + sum(NDEBED1 - NHABERD1) + sum(NDEBED2 - NHABERD2) + sum(NDEBED3 - NHABERD3) + sum(NDEBED4 - NHABERD4) + "
            + " sum(NDEBED5 - NHABERD5) + sum(NDEBED6 - NHABERD6) + sum(NDEBED7 - NHABERD7)) as gd, "
            + " (sum(NDEBE0 - NHABER0) + sum(NDEBE1 - NHABER1) + sum(NDEBE2 - NHABER2) + sum(NDEBE3 - NHABER3) + sum(NDEBE4 - NHABER4) + "
            + " sum(NDEBE5 - NHABER5) + sum(NDEBE6 - NHABER6) + sum(NDEBE7 - NHABER7) + sum(NDEBE8 - NHABER8)) as h, "
            + " (sum(NDEBED0 - NHABERD0) + sum(NDEBED1 - NHABERD1) + sum(NDEBED2 - NHABERD2) + sum(NDEBED3 - NHABERD3) + sum(NDEBED4 - NHABERD4) + "
            + " sum(NDEBED5 - NHABERD5) + sum(NDEBED6 - NHABERD6) + sum(NDEBED7 - NHABERD7) + sum(NDEBED8 - NHABERD8)) as hd, "
            + " (sum(NDEBE0 - NHABER0) + sum(NDEBE1 - NHABER1) + sum(NDEBE2 - NHABER2) + sum(NDEBE3 - NHABER3) + sum(NDEBE4 - NHABER4) + "
            + " sum(NDEBE5 - NHABER5) + sum(NDEBE6 - NHABER6) + sum(NDEBE7 - NHABER7) + sum(NDEBE8 - NHABER8) + sum(NDEBE9 - NHABER9)) as i, "
            + " (sum(NDEBED0 - NHABERD0) + sum(NDEBED1 - NHABERD1) + sum(NDEBED2 - NHABERD2) + sum(NDEBED3 - NHABERD3) + sum(NDEBED4 - NHABERD4) + "
            + " sum(NDEBED5 - NHABERD5) + sum(NDEBED6 - NHABERD6) + sum(NDEBED7 - NHABERD7) + sum(NDEBED8 - NHABERD8) + sum(NDEBED9 - NHABERD9)) as id, "
            + " (sum(NDEBE0 - NHABER0) + sum(NDEBE1 - NHABER1) + sum(NDEBE2 - NHABER2) + sum(NDEBE3 - NHABER3) + sum(NDEBE4 - NHABER4) + sum(NDEBE5 - NHABER5) + sum(NDEBE6 - NHABER6) +"
            + " sum(NDEBE7 - NHABER7) + sum(NDEBE8 - NHABER8) + sum(NDEBE9 - NHABER9) + sum(NDEBE10 - NHABER10)) as j, "
            + " (sum(NDEBED0 - NHABERD0) + sum(NDEBED1 - NHABERD1) + sum(NDEBED2 - NHABERD2) + sum(NDEBED3 - NHABERD3) + sum(NDEBED4 - NHABERD4) + sum(NDEBED5 - NHABERD5) + sum(NDEBED6 - NHABERD6) +"
            + " sum(NDEBED7 - NHABERD7) + sum(NDEBED8 - NHABERD8) + sum(NDEBED9 - NHABERD9) + sum(NDEBED10 - NHABERD10)) as jd, "
            + " (sum(NDEBE0 - NHABER0) + sum(NDEBE1 - NHABER1) + sum(NDEBE2 - NHABER2) + sum(NDEBE3 - NHABER3) + sum(NDEBE4 - NHABER4) + sum(NDEBE5 - NHABER5) + sum(NDEBE6 - NHABER6) +"
            + " sum(NDEBE7 - NHABER7) + sum(NDEBE8 - NHABER8) + sum(NDEBE9 - NHABER9) + sum(NDEBE10 - NHABER10) + sum(NDEBE11 - NHABER11)) as k, "
            + " (sum(NDEBED0 - NHABERD0) + sum(NDEBED1 - NHABERD1) + sum(NDEBED2 - NHABERD2) + sum(NDEBED3 - NHABERD3) + sum(NDEBED4 - NHABERD4) + sum(NDEBED5 - NHABERD5) + sum(NDEBED6 - NHABERD6) +"
            + " sum(NDEBED7 - NHABERD7) + sum(NDEBED8 - NHABERD8) + sum(NDEBED9 - NHABERD9) + sum(NDEBED10 - NHABERD10) + sum(NDEBED11 - NHABERD11)) as kd, "
            + " (sum(NDEBE0 - NHABER0) + sum(NDEBE1 - NHABER1) + sum(NDEBE2 - NHABER2) + sum(NDEBE3 - NHABER3) + sum(NDEBE4 - NHABER4) + sum(NDEBE5 - NHABER5) + sum(NDEBE6 - NHABER6) +"
            + " sum(NDEBE7 - NHABER7) + sum(NDEBE8 - NHABER8) + sum(NDEBE9 - NHABER9) + sum(NDEBE10 - NHABER10) + sum(NDEBE11 - NHABER11)+ sum(NDEBE12 - NHABER12) + sum(NDEBE13 - NHABER13) + sum(NDEBE14 - NHABER14)) as l, "
            + " (sum(NDEBED0 - NHABERD0) + sum(NDEBED1 - NHABERD1) + sum(NDEBED2 - NHABERD2) + sum(NDEBED3 - NHABERD3) + sum(NDEBED4 - NHABERD4) + sum(NDEBED5 - NHABERD5) + sum(NDEBED6 - NHABERD6) +"
            + " sum(NDEBED7 - NHABERD7) + sum(NDEBED8 - NHABERD8) + sum(NDEBED9 - NHABERD9) + sum(NDEBED10 - NHABERD10) + sum(NDEBED11 - NHABERD11) + sum(NDEBED12 - NHABERD12) + sum(NDEBED13 - NHABERD13) + sum(NDEBED14 - NHABERD14)) as ld from PLAN "
            + " where " + filter + " = '" + idRubro + "'";
            return dat.extrae(query, pathConection);
        }
    }
}
