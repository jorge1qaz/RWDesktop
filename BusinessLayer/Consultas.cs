using System;
using System.Collections.Generic;
using System.Data;

namespace BusinessLayer
{
    public class Consultas
    {
        AccesoDatos dat = new AccesoDatos();
        //Jorge Luis|26/10/2017|RW-19
        /*Método para extraer datos con un parámetro*/
        public DataTable ListCuentas(string path)
        {
            return dat.extrae(
                "SELECT dist p.Ccod_cue, p.Cdsc FROM " + "PLAN.DBF as p " +
                " inner join DIARIO.DBF as d " +
                " on d.Ccod_cue = p.Ccod_cue " +
                " Where p.Nanalisis = 2 " +
                " and p.Ntipo <= 2 ", path
                );
        }
        //Jorge Luis|26/10/2017|RW-19
        /*Método para extraer datos con un parámetro*/
        public DataTable ListCuentasTipo1(string path)
        {
            return dat.extrae(
                "SELECT dist p.Ccod_cue, p.Ntipo, p.Cdsc FROM " + "PLAN.DBF as p " +
                " inner join DIARIO.DBF as d " +
                " on d.Ccod_cue = p.Ccod_cue " +
                " Where p.Nanalisis = 2 " +
                " and p.Ntipo = 1 ", path
                );
        }
        //Jorge Luis|26/10/2017|RW-19
        /*Método para extraer datos con un parámetro*/
        public DataTable ListCuentasTipo2(string path)
        {
            return dat.extrae(
                "SELECT dist p.Ccod_cue, p.Ntipo, p.Cdsc FROM " + "PLAN.DBF as p " +
                " inner join DIARIO.DBF as d " +
                " on d.Ccod_cue = p.Ccod_cue " +
                " Where p.Nanalisis = 2 " +
                " and p.Ntipo = 2 ", path
                );
        }
        //Jorge Luis|26/10/2017|RW-19
        /*Método para extraer datos*/
        public DataTable ListDatosGenerales()
        {
            return dat.extraeInit(
                "SELECT p.Nyear, e.Ccod_emp, e.Cdsc, e.Cdir, e.Cgiro, e.Cnit, p.Mpath1 " +
                " from PATH.DBF as p " +
                " inner join EMPRESAS.DBF as e " +
                " on p.Ccod_emp = e.Ccod_emp " +
                " Where p.Nyear <= " + DateTime.Now.Year  +
                " order by p.Nyear desc"
                );
        }
        //Jorge Luis|26/10/2017|RW-19
        /*Método para extraer datos con un parámetro*/
        public DataTable ListDatosGenerales(string year)
        {
            return dat.extraeInit(
                "SELECT p.Nyear, e.Ccod_emp, e.Cdsc, e.Cdir, e.Cgiro, e.Cnit, p.Mpath1 " +
                " from PATH.DBF as p " +
                " inner join EMPRESAS.DBF as e " +
                " on p.Ccod_emp = e.Ccod_emp " +
                " Where p.Nyear = " + year +
                " order by p.Nyear desc"
                );
        }
        //Jorge Luis|26/10/2017|RW-19
        /*Método para extraer datos*/
        public DataTable ListDataForCompany()
        {
            return dat.extraeInit(
                "SELECT p.Nyear, e.Ccod_emp, e.Cdsc, e.Cdir, e.Cgiro, e.Cnit, p.Mpath1 " +
                " from PATH.DBF as p " +
                " inner join EMPRESAS.DBF as e " +
                " on p.Ccod_emp = e.Ccod_emp " +
                " Where p.Nyear <= " + DateTime.Now.Year +
                " and e.Ccod_emp = '01'" +
                " having  p.Nyear "
                );
        }
        //Jorge Luis|26/10/2017|RW-19
        /*Método para extraer datos*/
        public DataTable ListCompanies()
        {
            return dat.extraeInit(
                "SELECT dist e.Ccod_emp " +
                " from PATH.DBF as p " +
                " inner join EMPRESAS.DBF as e " +
                " on p.Ccod_emp = e.Ccod_emp " +
                " order by p.Nyear desc"
                );
        }
        //Jorge Luis|26/10/2017|RW-19
        /*Método para extraer datos con un parámetro*/
        public DataTable ListCompanies(string anio)
        {
            return dat.extraeInit(
                "SELECT dist e.Ccod_emp " +
                " from PATH.DBF as p " +
                " inner join EMPRESAS.DBF as e " +
                " on p.Ccod_emp = e.Ccod_emp " +
                " where p.Nyear = " + anio +
                " order by p.Nyear desc"
                );
        }
        //Jorge Luis|26/10/2017|RW-19
        /*Método para extraer datos con un parámetro*/
        public DataTable ListDetailsForCompany(string idCompany)
        {
            return dat.extraeInit(
                "SELECT dist p.Nyear, e.Ccod_emp, p.Mpath1 " +
                " from PATH.DBF as p " +
                " inner join EMPRESAS.DBF as e " +
                " on p.Ccod_emp = e.Ccod_emp " +
                " Where e.Ccod_emp = '" + idCompany + "' " +
                " order by p.Nyear desc"
                );
        }
        //Jorge Luis|26/10/2017|RW-19
        /*Método para extraer datos con dos parámetros*/
        public DataTable ListDetailsForCompany(string idCompany, string anio)
        {
            return dat.extraeInit(
                "SELECT dist p.Nyear, e.Ccod_emp, p.Mpath1 " +
                " from PATH.DBF as p " +
                " inner join EMPRESAS.DBF as e " +
                " on p.Ccod_emp = e.Ccod_emp " +
                " Where e.Ccod_emp = '" + idCompany  + "' " +
                " and p.Nyear = " + anio +
                " order by p.Nyear desc"
                );
        }
        //Jorge Luis|26/10/2017|RW-19
        /*Método para extraer datos con un parámetro*/
        public DataTable GetPathBySomething(string idCompany)
        {
            return dat.extraeInit(
                "SELECT dist p.Nyear, e.Ccod_emp, p.Mpath1 " +
                " from PATH.DBF as p " +
                " inner join EMPRESAS.DBF as e " +
                " on p.Ccod_emp = e.Ccod_emp " +
                " Where e.Ccod_emp = '" + idCompany + "' " +
                " order by p.Nyear desc"
                );
        }
        //Jorge Luis|26/10/2017|RW-19
        /*Método para extraer datos con tres parámetros*/
        public DataTable GetReporteCuentasPendientesByMesTipo1(string idCuenta, Int16 mesProcesoCalculado, string pathConection)
        {
            string mesParametro = "";
            /*Mientras el mes sea menor a 9, antepone un cero. En caso contrario no lo hace.*/
            if (mesProcesoCalculado <= 9)
                mesParametro = "0" + mesProcesoCalculado.ToString();
            else
                mesParametro = mesProcesoCalculado.ToString();
            return dat.extrae(
                " SELECT d.Ccod_cli, SUM(d.Ndebe), SUM(d.Nhaber), (SUM(d.Ndebe) - SUM(d.Nhaber)) as Total, c.Crazon " +
                " FROM DIARIO.DBF as d" +
                " inner join CLI_PRO.DBF as c " +
                " on c.Ccod_cli = d.Ccod_cli " +
                " group by d.Ccod_cli " +
                " having (SUM(d.Ndebe) - SUM(d.Nhaber)) != 0  " +
                " where d.ccod_cue = '" + idCuenta + "' " +
                " and d.Cmes <= '" + mesParametro + "' " +
                " order by Total desc", pathConection
                );
        }
        //Jorge Luis|26/10/2017|RW-19
        /*Método para extraer datos con tres parámetros*/
        public DataTable GetReporteCuentasPendientesByMesTipo2(string idCuenta, Int16 mesProcesoCalculado, string pathConection)
        {
            string mesParametro = "";
            /*Mientras el mes sea menor a 9, antepone un cero. En caso contrario no lo hace.*/
            if (mesProcesoCalculado <= 9)
                mesParametro = "0" + mesProcesoCalculado.ToString();
            else
                mesParametro = mesProcesoCalculado.ToString();
            return dat.extrae(
                " SELECT d.Ccod_cli, SUM(d.Ndebe), SUM(d.Nhaber), (SUM(d.Nhaber) - SUM(d.Ndebe)) as Total, c.Crazon " +
                " FROM DIARIO.DBF as d" +
                " inner join CLI_PRO.DBF as c " +
                " on c.Ccod_cli = d.Ccod_cli " +
                " group by d.Ccod_cli " +
                " having (SUM(d.Ndebe) - SUM(d.Nhaber)) != 0  " +
                " where d.ccod_cue = '" + idCuenta + "' " +
                " and d.Cmes <= '" + mesParametro + "' " +
                " order by Total desc", pathConection
                );
        }
        //Jorge Luis|02/11/2017|RW-19
        /*Método para obtener toda la tabla clientes, sin filtros*/
        public DataTable datosCliente()
        {
            return dat.extraeDbWeb(
                "SELECT * from Clientes"
                );
        }
        //Jorge Luis|27/11/2017|RW-19
        /*Método para obtener la lista de base de datos del módulo CONTA*/
        public DataTable ListDataBaseConta()
        {
            return dat.extraeInit(
                "select MPATH1 from PATH " +
                " where MPATH1 != ' ' "
                );
        }
        //Jorge Luis|27/11/2017|RW-19
        /*Método para obtener la lista de base de datos del módulo CONTA*/
        public DataTable CheckDataBaseConta(string path)
        {
            return dat.extraeInit(
                "select p.CCOD_EMP as a, e.CDSC as b, p.NYEAR as c, p.MPATH1 as d from PATH as p" + //a = id, b = descripción, c = año, d = path
                " inner join EMPRESAS as e" +
                " on p.CCOD_EMP = e.CCOD_EMP  " +
                " where MPATH1 != ' ' " +
                " and  MPATH1 = '" + path + "' "
                );
        }
        //Jorge Luis|27/11/2017|RW-19
        /*Método para obtener la lista de base de datos del módulo STOCK*/
        public DataTable ListDataBaseStock()
        {
            return dat.extraeInit(
                "select MPATH3 from PATH " +
                " where MPATH3 != ' ' "
                );
        }
        //Jorge Luis|27/11/2017|RW-19
        /*Método para obtener la lista de base de datos del módulo STOCK*/
        public DataTable CheckDataBaseStock(string path)
        {
            return dat.extraeInit(
                "select p.CCOD_EMP as a, e.CDSC as b, p.NYEAR as c, p.MPATH3 as d from PATH as p" + //a = id, b = descripción, c = año, d = path
                " inner join EMPRESAS as e" +
                " on p.CCOD_EMP = e.CCOD_EMP  " +
                " where MPATH3 != ' ' " +
                " and  MPATH3 = '" + path + "' "
                );
        }
        /*Margen de utilidad*/
        //Jorge Luis|14/11/2017|RW-*
        /*Consulta para extraes datos de la tabla VENTAS, con el filtro de CMES como parámetro*/
        public DataTable FilterSalesByMonth(Int16 mesProcesoCalculado, string pathConection)
        {
            string mesParametro = "";
            /*Mientras el mes sea menor a 9, antepone un cero. En caso contrario no lo hace.*/
            if (mesProcesoCalculado <= 9)
                mesParametro = "0" + mesProcesoCalculado.ToString();
            else
                mesParametro = mesProcesoCalculado.ToString();

            return dat.extrae(
                " SELECT cid from VENTAS " +
                " where Cmes = '" + mesParametro + "' ",
                pathConection
                );
        }
        //Jorge Luis|14/11/2017|RW-*
        /*Consulta para extraes datos de la tabla VENTAS, con el filtro de CMES como parámetro (soles)*/
        public DataTable GetFullProduct(Int16 idMonth, string idProduct, string pathConection)
        {
            string mesParametro = "";
            /*Mientras el mes sea menor a 9, antepone un cero. En caso contrario no lo hace.*/
            if (idMonth <= 9)
                mesParametro = "0" + idMonth.ToString();
            else
                mesParametro = idMonth.ToString();
            return dat.extrae(
                " select dist vl.CCOD_PRO, p.CDSC, p.CMEDIDA, " +
                " (sum(vl.NUNI)) as totalUnidades, " + //3
                " (sum((vl.NUNI*(vl.NPU/(1 + (vl.NPIGV/100)))))) as PUVentas, " + //4
                " (sum(vl.NCOSTO*vl.NUNI)) as PUCosto " + //5
                " from VENTASL as vl " + //6
                " inner join VENTAS as v " +
                " on vl.CID = v.CID " +
                " inner join PROD as p " +
                " on p.CCOD_PRO = vl.CCOD_PRO " +
                " where vl.CCOD_PRO = '" + idProduct + "' " +
                " and v.CMES = '" + mesParametro + "' "
                , pathConection
                );
        }
        //Jorge Luis|14/11/2017|RW-*
        /*Consulta para extraes datos de la tabla VENTAS, con el filtro de CMES como parámetro (dolares)*/
        public DataTable GetFullProductDolars(Int16 idMonth, string idProduct, string pathConection)
        {
            string mesParametro = "";
            /*Mientras el mes sea menor a 9, antepone un cero. En caso contrario no lo hace.*/
            if (idMonth <= 9)
                mesParametro = "0" + idMonth.ToString();
            else
                mesParametro = idMonth.ToString();
            return dat.extrae(
                " select dist vl.CCOD_PRO, p.CDSC, p.CMEDIDA, " +
                " (sum(vl.NUNI)) as totalUnidades, " +
                " (sum((vl.NUNI*(vl.NPUD/(1 + (vl.NPIGV/100)))))) as PUVentas, " +
                " (sum(vl.NCOSTOD*vl.NUNI)) as PUCosto " +
                " from VENTASL as vl " +
                " inner join VENTAS as v " +
                " on vl.CID = v.CID " +
                " inner join PROD as p " +
                " on p.CCOD_PRO = vl.CCOD_PRO " +
                " where vl.CCOD_PRO = '" + idProduct + "' " +
                " and v.CMES = '" + mesParametro + "' "
                , pathConection
                );
        }
        /*Jorge Luis|14/11/2017|RW-*
        /*Consulta para extraes datos de la tabla VENTAS, con el filtro de CMES como parámetro*/
        public DataTable ListProducts(Int16 mesProcesoCalculado, string pathConection)
        {
            string mesParametro = "";
            /*Mientras el mes sea menor a 9, antepone un cero. En caso contrario no lo hace.*/
            if (mesProcesoCalculado <= 9)
                mesParametro = "0" + mesProcesoCalculado.ToString();
            else
                mesParametro = mesProcesoCalculado.ToString();
            return dat.extrae(
                " select dist ltrim(vl.CCOD_PRO) as a  " + // a = CCOD_PRO
                " from VENTASL as vl " +
                " inner join VENTAS as v " +
                " on vl.CID = v.CID " +
                " where v.CMES = '" + mesParametro + "' " +
                " group by vl.CCOD_PRO "
                , pathConection
                );
        }
        //Jorge Luis|15/11/2017|RW-*
        /*Consulta para listar almacenes */
        public DataTable ListAlmacen(string pathConection, Int16 mesProcesoCalculado)
        {
            string mesParametro = "";
            /*Mientras el mes sea menor a 9, antepone un cero. En caso contrario no lo hace.*/
            if (mesProcesoCalculado <= 9)
                mesParametro = "0" + mesProcesoCalculado.ToString();
            else
                mesParametro = mesProcesoCalculado.ToString();
            return dat.extrae(
                " select dist v.CCOD_ALMA, a.CDSC from VENTAS as v" +
                " inner join ALMACEN as a" +
                " on v.CCOD_ALMA = a.CCOD_ALMA " +
                " where v.CMES = '" + mesParametro + "' "
                , pathConection
                );
        }
        //Jorge Luis|24/11/2017|RW-*
        /*Consulta para listar CENTRO DE COSTO 1 */
        public DataTable ListCOSTO1(string pathConection, Int16 mesProcesoCalculado)
        {
            string mesParametro = "";
            /*Mientras el mes sea menor a 9, antepone un cero. En caso contrario no lo hace.*/
            if (mesProcesoCalculado <= 9)
                mesParametro = "0" + mesProcesoCalculado.ToString();
            else
                mesParametro = mesProcesoCalculado.ToString();
            return dat.extrae(
                " select dist vl.CCOD_COSTO as a, c.CDSC as b from VENTASL as vl " + // A = CCOD_COSTO; B = Descripción
                " inner join COSTOS as c " +
                " on vl.CCOD_COSTO = c.CCOD_COSTO " +
                " inner join VENTAS as v " +
                " on v.CID = vl.CID " +
                " where v.CMES = '" + mesParametro + "' " +
                " and vl.CCOD_COSTO != ' ' "
                , pathConection
                );
        }
        //Jorge Luis|24/11/2017|RW-*
        /*Consulta para listar CENTRO DE COSTO 1, cuando primero se haya buscado en la tabla VENTASL y no se haya encontrado su CCOD_COSTO
         entonces busca tambien en la tabla VENTAS y si lo encuentra lo almacena*/
        public DataTable ListCOSTO1Nulls(string pathConection, Int16 mesProcesoCalculado)
        {
            string mesParametro = "";
            /*Mientras el mes sea menor a 9, antepone un cero. En caso contrario no lo hace.*/
            if (mesProcesoCalculado <= 9)
                mesParametro = "0" + mesProcesoCalculado.ToString();
            else
                mesParametro = mesProcesoCalculado.ToString();
            return dat.extrae(
                " select dist v.CCOD_COSTO as a, c.CDSC as b from VENTAS as v " + // A = CCOD_COSTO; B = Descripción
                " inner join VENTASL as vl " +
                " on v.CID = vl.CID " +
                " inner join COSTOS as c " +
                " on v.CCOD_COSTO = c.CCOD_COSTO " +
                " where v.CMES = '" + mesParametro + "' " +
                " and vl.CCOD_COSTO = ' ' " +
                " and v.CCOD_COSTO != ' ' "
                , pathConection
                );
        }
        //Jorge Luis|15/11/2017|RW-*
        /*Consulta para listar CENTRO DE COSTO 2 */
        public DataTable ListCOSTO2(string pathConection, Int16 mesProcesoCalculado)
        {
            string mesParametro = "";
            /*Mientras el mes sea menor a 9, antepone un cero. En caso contrario no lo hace.*/
            if (mesProcesoCalculado <= 9)
                mesParametro = "0" + mesProcesoCalculado.ToString();
            else
                mesParametro = mesProcesoCalculado.ToString();
            return dat.extrae(
                " select dist v.CCOD_COS2, p.CDSC from VENTAS as v " +
                " inner join PROD as p " +
                " on v.CCOD_COS2 = p.CCOD_COS2 " +
                " where v.CMES = '" + mesParametro + "' "
                , pathConection
                );
        }
        //Jorge Luis|15/11/2017|RW-*
        /*Consulta para listar Vendedor */
        public DataTable ListVendedor(string pathConnection, Int16 mesProcesoCalculado)
        {
            string mesParametro = "";
            /*Mientras el mes sea menor a 9, antepone un cero. En caso contrario no lo hace.*/
            if (mesProcesoCalculado <= 9)
                mesParametro = "0" + mesProcesoCalculado.ToString();
            else
                mesParametro = mesProcesoCalculado.ToString();
            return dat.extrae(
                " select dist v.CCOD_VEND, ve.CDSC from VENTAS as v " +
                " inner join VENDEDOR as ve " +
                " on v.CCOD_VEND = ve.CCOD_VEND " +
                " where v.CMES = '" + mesParametro + "' " 
                , pathConnection
                );
        }
        //Jorge Luis|15/11/2017|RW-*
        /*Consulta para listar LSTOCK */
        public DataTable ListTipoStock(string pathConnection)
        {
            return dat.extrae(
                " select dist LSTOCK from VENTAS "
                , pathConnection
                );
        }
        //Jorge Luis|15/11/2017|RW-*
        /*Consulta para listar LSTOCK */
        public DataTable ListAlcance(string pathConection)
        {
            return dat.extrae(
                " select dist LREG from VENTAS "
                , pathConection
                );
        }
        //Jorge Luis|14/11/2017|RW-*
        /*Consulta para  obtener los productos, pero solo los cuales tengan el campo de COSTO1 lleno
         Primero se toma el COSTO1 de la tabla ventasl*/
        public DataTable GetFullTableC1a(string pathConnection, Int16 mesProcesoCalculado)
        {
            string mesParametro = "";
            /*Mientras el mes sea menor a 9, antepone un cero. En caso contrario no lo hace.*/
            if (mesProcesoCalculado <= 9)
                mesParametro = "0" + mesProcesoCalculado.ToString();
            else
                mesParametro = mesProcesoCalculado.ToString();
            return dat.extrae(
                " select (vl.CCOD_PRO) as a, (trim(p.CDSC)) as b, vl.NUNI as c, (p.CMEDIDA) as d, " +
                "  (vl.NPU) as e, (vl.NPIGV) as f, (vl.NCOSTO) as g, (vl.NPUD) as h, (vl.NCOSTOD) as i, " +
                //Filtros
                "  v.CCOD_CLI as j, v.CCOD_ALMA as k, vl.CCOD_COSTO as m, (vl.CCOD_COS2) as n, (v.CCOD_VEND) as o, (v.LSTOCK) as l, (v.LREG) as lr " +
                " from VENTASL as vl " +
                " inner join VENTAS as v " +
                " on vl.CID = v.CID " +
                " inner join PROD as p " +
                " on p.CCOD_PRO = vl.CCOD_PRO " +
                " where v.CMES = '" + mesParametro + "' " +
                " and vl.CCOD_COSTO != ' ' "
                , pathConnection
                );
        }
        //Jorge Luis|14/11/2017|RW-*
        /*Consulta para  obtener los productos, pero solo los cuales tengan el campo de COSTO1 vacio, 
         entonce se busca en la tabla "ventas"*/
        public DataTable GetFullTableC1b(string pathConnection, Int16 mesProcesoCalculado)
        {
            string mesParametro = "";
            /*Mientras el mes sea menor a 9, antepone un cero. En caso contrario no lo hace.*/
            if (mesProcesoCalculado <= 9)
                mesParametro = "0" + mesProcesoCalculado.ToString();
            else
                mesParametro = mesProcesoCalculado.ToString();
            return dat.extrae(
                " select (vl.CCOD_PRO) as a, (trim(p.CDSC)) as b, vl.NUNI as c, (p.CMEDIDA) as d, " +
                "  (vl.NPU) as e, (vl.NPIGV) as f, (vl.NCOSTO) as g, (vl.NPUD) as h, (vl.NCOSTOD) as i, " +
                //Filtros
                "  v.CCOD_CLI as j, v.CCOD_ALMA as k, v.CCOD_COSTO as m, (v.CCOD_VEND) as o, (v.LSTOCK) as l, (v.LREG) as lr " +
                " from VENTASL as vl " +
                " inner join VENTAS as v " +
                " on vl.CID = v.CID " +
                " inner join PROD as p " +
                " on p.CCOD_PRO = vl.CCOD_PRO " +
                " where v.CMES = '" + mesParametro + "' " +
                " and vl.CCOD_COSTO = ' ' " +
                " and v.CCOD_COSTO != ' ' "
                , pathConnection
                );
        }
        //Jorge Luis|14/11/2017|RW-*
        /*Consulta para  obtener los productos, pero solo los cuales tengan el campo de COSTO1 vacio 
         en las tablas ventas y ventasl*/
        public DataTable GetFullTableC1c(string pathConnection, Int16 mesProcesoCalculado)
        {
            string mesParametro = "";
            /*Mientras el mes sea menor a 9, antepone un cero. En caso contrario no lo hace.*/
            if (mesProcesoCalculado <= 9)
                mesParametro = "0" + mesProcesoCalculado.ToString();
            else
                mesParametro = mesProcesoCalculado.ToString();
            return dat.extrae(
                " select (vl.CCOD_PRO) as a, (trim(p.CDSC)) as b, vl.NUNI as c, (p.CMEDIDA) as d, " +
                "  (vl.NPU) as e, (vl.NPIGV) as f, (vl.NCOSTO) as g, (vl.NPUD) as h, (vl.NCOSTOD) as i, " +
                //Filtros
                "  v.CCOD_CLI as j, v.CCOD_ALMA as k, vl.CCOD_COSTO as m, (vl.CCOD_COS2) as n, (v.CCOD_VEND) as o, (v.LSTOCK) as l, (v.LREG) as lr " +
                " from VENTASL as vl " +
                " inner join VENTAS as v " +
                " on vl.CID = v.CID " +
                " inner join PROD as p " +
                " on p.CCOD_PRO = vl.CCOD_PRO " +
                " where v.CMES = '" + mesParametro + "' " +
                " and vl.CCOD_COSTO = ' ' " +
                " and v.CCOD_COSTO = ' ' "
                , pathConnection
                );
        }
        //Jorge Luis|23/11/2017|RW-*
        /*Consulta para obtener la lista de productos por almacen*/
        public DataTable GetProductsByStore(string pathConnection, Int16 mesProcesoCalculado, string idStore)
        {
            string mesParametro = "";
            /*Mientras el mes sea menor a 9, antepone un cero. En caso contrario no lo hace.*/
            if (mesProcesoCalculado <= 9)
                mesParametro = "0" + mesProcesoCalculado.ToString();
            else
                mesParametro = mesProcesoCalculado.ToString();
            return dat.extrae(
                " select dist RTRIM(vl.CCOD_PRO) as a " + // A = CCOD_PRO
                " from VENTASL as vl " +
                " inner join VENTAS as v " +
                " on vl.CID = v.CID " +
                " where v.CMES = '" + mesParametro + "' " +
                " and v.CCOD_ALMA = '" + idStore + "' "
                , pathConnection
                );
        }
        //Jorge Luis|24/11/2017|RW-*
        /*Consulta para listar CENTRO DE COSTO 1 */
        public DataTable GetProductsByCOSTO1VentasL(string pathConection, Int16 mesProcesoCalculado, string idCosto1)
        {
            string mesParametro = "";
            /*Mientras el mes sea menor a 9, antepone un cero. En caso contrario no lo hace.*/
            if (mesProcesoCalculado <= 9)
                mesParametro = "0" + mesProcesoCalculado.ToString();
            else
                mesParametro = mesProcesoCalculado.ToString();
            return dat.extrae(
                " select dist vl.CCOD_PRO as a from VENTASL as vl " +
                " inner join COSTOS as c " +
                " on vl.CCOD_COSTO = c.CCOD_COSTO " +
                " inner join VENTAS as v " +
                " on v.CID = vl.CID " +
                " where v.CMES = '" + mesParametro + "' " +
                " and vl.CCOD_COSTO != ' ' " +
                " and  vl.CCOD_COSTO = '" + idCosto1 + "' "
                , pathConection
                );
        }
        //Jorge Luis|24/11/2017|RW-*
        /*Consulta para listar CENTRO DE COSTO 1, cuando primero se haya buscado en la tabla VENTASL y no se haya encontrado su CCOD_COSTO
         entonces busca tambien en la tabla VENTAS y si lo encuentra lo almacena*/
        public DataTable GetProductsByCOSTO1Ventas(string pathConection, Int16 mesProcesoCalculado, string idCosto1)
        {
            string mesParametro = "";
            /*Mientras el mes sea menor a 9, antepone un cero. En caso contrario no lo hace.*/
            if (mesProcesoCalculado <= 9)
                mesParametro = "0" + mesProcesoCalculado.ToString();
            else
                mesParametro = mesProcesoCalculado.ToString();
            return dat.extrae(
                " select dist vl.CCOD_PRO as a  from VENTAS as v " +
                " inner join VENTASL as vl " +
                " on v.CID = vl.CID " +
                " inner join COSTOS as c " +
                " on v.CCOD_COSTO = c.CCOD_COSTO " +
                " where v.CMES = '" + mesParametro + "' " +
                " and vl.CCOD_COSTO = ' ' " +
                " and v.CCOD_COSTO != ' ' " +
                " and  vl.CCOD_COSTO = '" + idCosto1 + "' "
                , pathConection
                );
        }
    }
}
