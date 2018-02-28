using System;
using System.Data;

namespace BusinessLayer
{
    //Consultas para los reportes de: "Mi negocio al día"
    public class Consultasb
    {
        AccesoDatos dat = new AccesoDatos();
        Paths paths = new Paths();
        string query = "";
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
        public DataTable FilterRubro(string pathConnection, string idRubro)
        {
            return dat.extrae(
                " select CCOD_CUE, CDSC from PLAN " +
                " where CCOD_BAL2 = '" + idRubro + "'"
                , pathConnection
                );
        }
        //Jorge Luis|13/12/2017|RW-91
        /*Consulta para extraes datos de la tabla VENTAS, con el filtro de CMES como parámetro*/
        public DataTable SumNhaberDiario(string pathConnection, Int16 mesProcesoCalculado, string idCuenta)
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
                , pathConnection
                );
        }
        //Jorge Luis|15/12/2017|RW-91
        /*Consulta para extraes datos de la tabla VENTAS, con el filtro de CMES como parámetro*/
        public DataTable SumNdebeDiario(string pathConnection, Int16 mesProcesoCalculado, string idCuenta)
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
                , pathConnection
                );
        }
        //Jorge Luis|15/12/2017|RW-91
        /*Consulta para ...*/
        public DataTable TablaDiario(string pathConnection, string rubro, string idRubro, Int16 mesProcesoCalculado, bool tipoOperacion)
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
                     + " where p." + rubro + " = '" + idRubro + "'"
                     + " and d.CMES = '" + mesParametro + "' ";
            }
            else                    //False SumNdebeDiario  (DEBE)
            {
                query = " select d.NDEBE as a, d.NDEBED as b from Diario as d "
                     + " inner join PLAN as p on p.CCOD_CUE = d.CCOD_CUE "
                     + " where p." + rubro + " = '" + idRubro + "'"
                     + " and d.CMES = '" + mesParametro + "' ";
            }
            return dat.extrae(query, pathConnection);
        }
        //Jorge Luis|15/12/2017|RW-91
        /*Consulta para ...*/
        public DataTable TablaDiario(string pathConnection, string rubro, string idRubro, Int16 mesProcesoCalculado)
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
                     + " where p." + rubro + " = '" + idRubro + "'" //CCOD_BAL2
                     + " and d.CMES = '" + mesParametro + "' "
                , pathConnection);
        }
        //Jorge Luis|15/12/2017|RW-91
        /*Consulta para ...*/
        public DataTable TablaDiarioN(string pathConnection, string idRubro, Int16 mesProcesoCalculado)
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
                , pathConnection);
        }
        //Jorge Luis|21/12/2017|RW-91
        /*Consulta para ...*/
        public DataTable ListCuentasByRubro(string pathConnection, string idRubro, Int16 mesProcesoCalculado)
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
                , pathConnection);
        }
        //Jorge Luis|15/12/2017|RW-91
        /*Consulta para ...*/
        public DataTable TableForEstadoResultado(string pathConnection, string idRubro, Int16 mesProcesoCalculado, bool tipoOperacion)
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
            return dat.extrae(query, pathConnection);
        }
        public DataTable TableForEstadoResultado(string pathConnection, string idRubro, Int16 mesProcesoCalculado)
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
            return dat.extrae(query, pathConnection);
        }
        public DataTable TableForEstadoResultado(string pathConnection, string idRubro, Int16 mesProcesoCalculado, string filter, bool tipoOperacion)
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
            return dat.extrae(query, pathConnection);
        }
        public DataTable TableForEstadoResultado(string pathConnection, string idRubro, string filter1, string filter2)
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
                + " where " + filter1 + " = '" + idRubro + "'"
                + " or " + filter2 + " = '" + idRubro + "'"
                + " and NNIVEL = 3 ";
            return dat.extrae(query, pathConnection);
        }
        // Estados financieros - Balance general
        public DataTable GetTotalMonthByRubro(string pathConnection, string filter1, string filter2, string idRubro, bool tipoOperacion)
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
                    + " where " + filter1 + " = '" + idRubro + "'"
                    + " or " + filter2 + " = '" + idRubro + "'";
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
                    + " where " + filter1 + " = '" + idRubro + "'"
                    + " or " + filter2 + " = '" + idRubro + "'";
            return dat.extrae(query, pathConnection);
        }
        //Flujo de caja
        //Flujo de caja detallado
        //Jorge Luis|19/01/2018|RW-93
        /*Método para*/
        public DataTable ListSaldoInicialDescripcion(string pathConnection)
        {
            string query = "";
            query = " select dist d.CCOD_CUE as a, p.CDSC as b from DIARIO as d "
                + " inner join PLAN as p on d.CCOD_CUE = p.CCOD_CUE "
                + " where p.nanalisis = 3 and p.ntipo = 1 ";
            return dat.extrae(query, pathConnection);
        }
        //Jorge Luis|19/01/2018|RW-93
        /*Método para*/
        public DataTable ListSaldoInicialDatos(string pathConnection)
        {
            string query = "";
            query = " select di.CCOD_CUE as a, di.FFECHA as b, di.NDEBE as c, di.NHABER as d, di.NDEBED as cd, di.NHABERD as dd, p.CMONEDA as g from DIARIO as di"
                + " inner join PLAN as p on di.CCOD_CUE = p.CCOD_CUE "
                + " where p.nanalisis = 3 and p.ntipo = 1 "
                + " and p.ccod_cue LIKE '10%' ";
            return dat.extrae(query, pathConnection);
        }
        //Jorge Luis|19/01/2018|RW-93
        /*Método para*/
        public DataTable ListIngresosDescripcion(string pathConnection)
        {
            string query = "";
            query = " select dist d.CCOD_CUE as a, p.CDSC as b from DIARIO as d "
                + " inner join PLAN as p on d.CCOD_CUE = p.CCOD_CUE "
                + " where p.nanalisis = 2 and p.ntipo = 1 ";
            return dat.extrae(query, pathConnection);
        }
        //Jorge Luis|19/01/2018|RW-93
        /*Método para*/
        public DataTable ListIngresosEgresosDatos(string pathConnection, Int16 analisis, Int16 tipo)
        {
            string query = "";
            query = " select di.CCOD_CUE as a, di.CCOD_CLI as b, di.FFECHADOC as c, di.FFECHAVEN as d, di.CNUMERO as e, di.CMREG as f, "
                + " di.CCOD_DOC as g, di.NDEBE as h, di.NHABER as i, di.NDEBED as hd, di.NHABERD as id from DIARIO as di "
                + " inner join PLAN  as p on di.CCOD_CUE = p.CCOD_CUE "
                + " where p.nanalisis = " + analisis + " and p.ntipo = " + tipo + " AND TRIM(di.CMESC ) == '' ";
            return dat.extrae(query, pathConnection);
        }
        //Jorge Luis|19/01/2018|RW-93
        /*Método para*/
        public DataTable ListEgresosDescripcion(string pathConnection)
        {
            string query = "";
            query = " select dist d.CCOD_CUE as a, p.CDSC as b from DIARIO as d "
                + " inner join PLAN  as p on d.CCOD_CUE = p.CCOD_CUE "
                + " where p.nanalisis = 2 and p.ntipo = 2 ";
            return dat.extrae(query, pathConnection);
        }
        //Jorge Luis|19/01/2018|RW-93
        /*Método para*/
        public DataTable ListCustumers(string pathConnection)
        {
            string query = "";
            query = " select CCOD_CLI as a, CRAZON as b from CLI_PRO as c ";
            return dat.extrae(query, pathConnection);
        }
        //query de prueba
        public DataTable reportFlujoCaja(string pathConnection, Int16 analisis, Int16 tipo) {
            query = " select dist di.CCOD_CUE as a, di.CCOD_CLI as b, di.FFECHADOC as c, di.FFECHAVEN as d, di.CNUMERO as e, di.CMREG as f, "
                + " di.CCOD_DOC as g, di.NDEBE as h, di.NHABER as i, di.NDEBED as hd, di.NHABERD as id from DIARIO as di "
                + " inner join PLAN  as p on di.CCOD_CUE = p.CCOD_CUE "
                + " where p.nanalisis = " + analisis + " and p.ntipo = " + tipo + " AND TRIM(di.CMESC ) == '' ";
            return dat.extrae(query, pathConnection);
        }
        //Correcciones: Entrega final de la primera versión
        //query de prueba
        public DataTable GetTableByRubro(string pathConnection, string nameColumnRubro1, string nameColumnRubro2, string rubro, bool tipoReporte)
        {
            if (tipoReporte)
            {
                query = " select CCOD_CUE as a, (NDEBE0 - NHABER0) as s0, (NDEBE1 - NHABER1) as s1, (NDEBE2 - NHABER2) as s2, (NDEBE3 - NHABER3) as s3, (NDEBE4 - NHABER4) as s4, (NDEBE5 - NHABER5) as s5, (NDEBE6 - NHABER6) as s6, (NDEBE7 - NHABER7) as s7, (NDEBE8 - NHABER8) as s8, (NDEBE9 - NHABER9) as s9, (NDEBE1 - NHABER10) as s10, (NDEBE1 - NHABER11) as s11, (NDEBE1 - NHABER12) as s12, (NDEBE1 - NHABER13) as s13, "
                    + " (NDEBED0 - NHABERD0) as d0, (NDEBED1 - NHABERD1) as d1, (NDEBED2 - NHABERD2) as d2, (NDEBED3 - NHABERD3) as d3, (NDEBED4 - NHABERD4) as d4, (NDEBED5 - NHABERD5) as d5, (NDEBED6 - NHABERD6) as d6, (NDEBED7 - NHABERD7) as d7, (NDEBED8 - NHABERD8) as d8, (NDEBED9 - NHABERD9) as d9, (NDEBED1 - NHABERD10) as d10, (NDEBED1 - NHABERD11) as d11, (NDEBED1 - NHABERD12) as d12, (NDEBED1 - NHABERD13) as d13 "
                    + " from PLAN where " + nameColumnRubro1 + " = '" + rubro + "' or " + nameColumnRubro2 + " = '" + rubro + "' ";
            }
            else
            {
                query = " select CCOD_CUE as a, (NDEBE0 - NHABER0)*(-1) as s0, (NDEBE1 - NHABER1)*(-1) as s1, (NDEBE2 - NHABER2)*(-1) as s2, (NDEBE3 - NHABER3)*(-1) as s3, (NDEBE4 - NHABER4)*(-1) as s4, (NDEBE5 - NHABER5)*(-1) as s5, (NDEBE6 - NHABER6)*(-1) as s6, (NDEBE7 - NHABER7)*(-1) as s7, (NDEBE8 - NHABER8)*(-1) as s8, (NDEBE9 - NHABER9)*(-1) as s9, (NDEBE1 - NHABER10)*(-1) as s10, (NDEBE1 - NHABER11)*(-1) as s11, (NDEBE1 - NHABER12)*(-1) as s12, (NDEBE1 - NHABER13)*(-1) as s13, "
                    + " (NDEBED0 - NHABERD0)*(-1) as d0, (NDEBED1 - NHABERD1)*(-1) as d1, (NDEBED2 - NHABERD2)*(-1) as d2, (NDEBED3 - NHABERD3)*(-1) as d3, (NDEBED4 - NHABERD4)*(-1) as d4, (NDEBED5 - NHABERD5)*(-1) as d5, (NDEBED6 - NHABERD6)*(-1) as d6, (NDEBED7 - NHABERD7)*(-1) as d7, (NDEBED8 - NHABERD8)*(-1) as d8, (NDEBED9 - NHABERD9)*(-1) as d9, (NDEBED1 - NHABERD10)*(-1) as d10, (NDEBED1 - NHABERD11)*(-1) as d11, (NDEBED1 - NHABERD12)*(-1) as d12, (NDEBED1 - NHABERD13)*(-1) as d13 "
                    + " from PLAN where " + nameColumnRubro1 + " = '" + rubro + "' or " + nameColumnRubro2 + " = '" + rubro + "' ";
            }
            return dat.extrae(query, pathConnection);
        }
        public DataTable listCuentasByRubrosGroup1(string pathConnection, bool tipoConsulta)
        {
            if (tipoConsulta) // true = activos, false = pasivos
            {
                query = " select dist CCOD_CUE as a from plan where CCOD_BAL in ('A105', 'A110', 'A115', 'A121', 'A123', 'A125', 'A135', 'A142', 'A151', 'A153', 'A157', 'A159', 'A164', 'A177', 'A179') "
                    + " or CCOD_BALN in ('A155')";
            }
            else // false = pasivos
            {
                query = " select dist CCOD_CUE as a from plan where CCOD_BAL in ('P115', 'P120', 'P122', 'P129', 'P135', 'P505', 'P510', 'P515', 'P530', 'P540') "
                    + " or CCOD_BALN2 in ('P105') ";
            }
            return dat.extrae(query, pathConnection);
        }
        public DataTable listCuentasByRubrosGroup2(string pathConnection, bool tipoConsulta)
        {
            if (tipoConsulta) // true = activos, false = pasivos
            {
                query = " select dist CCOD_CUE as a from plan where CCOD_BAL in ('A185', 'A106', 'A111', 'A120', 'A122', 'A124', 'A130', 'A140', 'A145', 'A152', 'A158', 'A160', 'A176', 'A178', 'A180') "
                    + " or CCOD_BALN in ('A151')";
            }
            else // false = pasivos
                query = " select dist CCOD_CUE as a from plan where CCOD_BAL in ('P110', 'P541', 'P121', 'P128', 'P133', 'P141', 'P507', 'P511', 'P520', 'P531') ";
            return dat.extrae(query, pathConnection);
        }
    }
}
