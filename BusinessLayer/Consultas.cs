﻿using System;
using System.Data;

namespace BusinessLayer
{
    //Consultas para los reportes de: "Cuentas pendientes y Margen de utilidad por producto"
    public class Consultas
    {
        AccesoDatos dat = new AccesoDatos();
        Paths paths = new Paths();
        //Jorge Luis|07/12/2017|RW-46
        /*Método para obtener la lista de empresas*/
        public DataTable GetCompanies()
        {
            return dat.extraeInit(
                "select dist e.CCOD_EMP as Código, e.CNIT as RUC, e.CDSC as 'Razón social' from PATH as a " + 
                " inner join EMPRESAS as e " +
                " on e.CCOD_EMP = a.CCOD_EMP "
                );
        }
        //Jorge Luis|26/10/2017|RW-19
        /*Método para extraer datos con un parámetro*/
        public DataTable ListCuentas(string path)
        {
            return dat.extrae(
                "SELECT dist p.Ccod_cue as a, p.Cdsc as b FROM  PLAN.DBF as p " +
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
                " SELECT d.Ccod_cli as a, SUM(d.Ndebe) as b, SUM(d.Nhaber) as c, (SUM(d.Ndebe) - SUM(d.Nhaber)) as d, c.Crazon as e, SUM(d.NDEBED) as f, SUM(d.NHABERD) as g, (SUM(d.NDEBED) - SUM(d.NHABERD)) as h "
                + " FROM DIARIO.DBF as d "
                + " inner join CLI_PRO.DBF as c "
                + " on c.Ccod_cli = d.Ccod_cli "
                + " group by d.Ccod_cli "
                + " having (SUM(d.Ndebe) - SUM(d.Nhaber)) != 0  "
                + " where d.ccod_cue = '" + idCuenta + "' "
                + " and d.Cmes <= '" + mesParametro + "' "
                + " and TRIM(d.CMESC) == '' "
                + " order by e desc", pathConection
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
                " SELECT d.Ccod_cli as a, SUM(d.Ndebe) as b, SUM(d.Nhaber) as c, (SUM(d.Nhaber) - SUM(d.Ndebe)) as d, c.Crazon as e, SUM(d.NDEBED) as f, SUM(d.NHABERD) as g, (SUM(d.NDEBED) - SUM(d.NHABERD)) as h"
                + " FROM DIARIO.DBF as d"
                + " inner join CLI_PRO.DBF as c "
                + " on c.Ccod_cli = d.Ccod_cli "
                + " group by d.Ccod_cli "
                + " having (SUM(d.Ndebe) - SUM(d.Nhaber)) != 0  "
                + " where d.ccod_cue = '" + idCuenta + "' "
                + " and d.Cmes <= '" + mesParametro + "' "
                + " and TRIM(d.CMESC ) == '' "
                + " order by e desc", pathConection
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
        public DataTable CheckDataBaseConta()
        {
            return dat.extraeInit(
                "select p.CCOD_EMP as a, e.CDSC as b, p.NYEAR as c, e.CNIT as d, p.MPATH1 as e from PATH as p" + //a = id, b = descripción, c = año, d = ruc, e = path
                " inner join EMPRESAS as e" +
                " on p.CCOD_EMP = e.CCOD_EMP  " +
                " where MPATH1 != ' ' " +
                " and p.CCOD_EMP = '" + paths.readFile(paths.PathIdCompany) + "' "
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
        public DataTable CheckDataBaseStock()
        {
            return dat.extraeInit(
                "select p.CCOD_EMP as a, e.CDSC as b, p.NYEAR as c, e.CNIT as d, p.MPATH3 as e from PATH as p" + //a = id, b = descripción, c = año, d = ruc, e = path
                " inner join EMPRESAS as e" +
                " on p.CCOD_EMP = e.CCOD_EMP  " +
                " where p.MPATH3 != ' ' " +
                " and p.CCOD_EMP = '" + paths.readFile(paths.PathIdCompany) + "' "
                );
        }
        /*Margen de utilidad*/
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
                " select dist v.CCOD_ALMA as a , a.CDSC as b from VENTAS as v" +
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
                " select dist vl.CCOD_COSTO as a, (vl.CCOD_COSTO + ' - ' + c.CDSC) as b from VENTASL as vl " + // A = CCOD_COSTO; B = Descripción
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
                " select dist v.CCOD_COSTO as a, (vl.CCOD_COSTO + ' - ' + c.CDSC) as b from VENTAS as v " + // A = CCOD_COSTO; B = Descripción
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
        //Jorge Luis|24/11/2017|RW-*
        /*Consulta para listar CENTRO DE COSTO 1 */
        public DataTable ListCOSTO2(string pathConection, Int16 mesProcesoCalculado)
        {
            string mesParametro = "";
            /*Mientras el mes sea menor a 9, antepone un cero. En caso contrario no lo hace.*/
            if (mesProcesoCalculado <= 9)
                mesParametro = "0" + mesProcesoCalculado.ToString();
            else
                mesParametro = mesProcesoCalculado.ToString();
            return dat.extrae(
                " select dist vl.CCOD_COS2 as a, (vl.CCOD_COS2 + ' - ' + c.CDSC) as b from VENTASL as vl " + // A = CCOD_COSTO; B = Descripción
                " inner join COSTOS2 as c " +
                " on vl.CCOD_COS2 = c.CCOD_COSTO " +
                " inner join VENTAS as v " +
                " on v.CID = vl.CID " +
                " where v.CMES = '" + mesParametro + "' " +
                " and vl.CCOD_COS2 != ' ' "
                , pathConection
                );
        }
        //Jorge Luis|24/11/2017|RW-*
        /*Consulta para listar CENTRO DE COSTO 1, cuando primero se haya buscado en la tabla VENTASL y no se haya encontrado su CCOD_COSTO
         entonces busca tambien en la tabla VENTAS y si lo encuentra lo almacena*/
        public DataTable ListCOSTO2Nulls(string pathConection, Int16 mesProcesoCalculado)
        {
            string mesParametro = "";
            /*Mientras el mes sea menor a 9, antepone un cero. En caso contrario no lo hace.*/
            if (mesProcesoCalculado <= 9)
                mesParametro = "0" + mesProcesoCalculado.ToString();
            else
                mesParametro = mesProcesoCalculado.ToString();
            return dat.extrae(
                " select dist v.CCOD_COS2 as a, (vl.CCOD_COS2 + ' - ' + c.CDSC) as b from VENTAS as v " + // A = CCOD_COSTO; B = Descripción
                " inner join VENTASL as vl " +
                " on v.CID = vl.CID " +
                " inner join COSTOS2 as c " +
                " on v.CCOD_COS2 = c.CCOD_COSTO " +
                " where v.CMES = '" + mesParametro + "' " +
                " and vl.CCOD_COS2 = ' ' " +
                " and v.CCOD_COS2 != ' ' "
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
                " select dist v.CCOD_VEND as a, ve.CDSC as b from VENTAS as v " +
                " inner join VENDEDOR as ve " +
                " on v.CCOD_VEND = ve.CCOD_VEND " +
                " where v.CMES = '" + mesParametro + "' " 
                , pathConnection
                );
        }
        //Jorge Luis|01/12/2017|RW-*
        /*Consulta para listar LSTOCK */
        public DataTable ListCustomer(string pathConection, Int16 mesProcesoCalculado)
        {
            string mesParametro = "";
            /*Mientras el mes sea menor a 9, antepone un cero. En caso contrario no lo hace.*/
            if (mesProcesoCalculado <= 9)
                mesParametro = "0" + mesProcesoCalculado.ToString();
            else
                mesParametro = mesProcesoCalculado.ToString();
            return dat.extrae(
                " select dist v.CCOD_CLI as a, c.CRAZON as b from VENTAS as v" + 
                " inner join CLI_PRO as c " +
                " on v.CCOD_CLI = c.CCOD_CLI " +
                " where v.CMES = '" + mesParametro + "' "
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
                "  v.CCOD_CLI as j, v.CCOD_ALMA as k, vl.CCOD_COSTO as m, (vl.CCOD_COS2) as n, (v.CCOD_VEND) as o, (v.LSTOCK) as p, (v.LREG) as q " +
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
                "  v.CCOD_CLI as j, v.CCOD_ALMA as k, v.CCOD_COSTO as m, (vl.CCOD_COS2) as n, (v.CCOD_VEND) as o, (v.LSTOCK) as p, (v.LREG) as q " +
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
                "  v.CCOD_CLI as j, v.CCOD_ALMA as k, vl.CCOD_COSTO as m, (vl.CCOD_COS2) as n, (v.CCOD_VEND) as o, (v.LSTOCK) as p, (v.LREG) as q " +
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
        //inicio
        //Jorge Luis|24/11/2017|RW-*
        /*Consulta para listar CENTRO DE COSTO 2 */
        public DataTable GetProductsByCOSTO2VentasL(string pathConection, Int16 mesProcesoCalculado, string idCosto2)
        {
            string mesParametro = "";
            /*Mientras el mes sea menor a 9, antepone un cero. En caso contrario no lo hace.*/
            if (mesProcesoCalculado <= 9)
                mesParametro = "0" + mesProcesoCalculado.ToString();
            else
                mesParametro = mesProcesoCalculado.ToString();
            return dat.extrae(
                " select dist vl.CCOD_PRO as a from VENTASL as vl " +
                " inner join COSTOS2 as c " +
                " on vl.CCOD_COS2 = c.CCOD_COSTO " +
                " inner join VENTAS as v " +
                " on v.CID = vl.CID " +
                " where v.CMES = '" + mesParametro + "' " +
                " and vl.CCOD_COS2 != ' ' " +
                " and  vl.CCOD_COS2 = '" + idCosto2 + "' "
                , pathConection
                );
        }
        //Jorge Luis|24/11/2017|RW-*
        /*Consulta para listar CENTRO DE COSTO 2, cuando primero se haya buscado en la tabla VENTASL y no se haya encontrado su CCOD_COSTO
         entonces busca tambien en la tabla VENTAS y si lo encuentra lo almacena*/
        public DataTable GetProductsByCOSTO2Ventas(string pathConection, Int16 mesProcesoCalculado, string idCosto2)
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
                " inner join COSTOS2 as c " +
                " on v.CCOD_COS2 = c.CCOD_COSTO " +
                " where v.CMES = '" + mesParametro + "' " +
                " and vl.CCOD_COS2 = ' ' " +
                " and v.CCOD_COS2 != ' ' " +
                " and  vl.CCOD_COS2 = '" + idCosto2 + "' "
                , pathConection
                );
        }
        //fin mi hedmano
        //Jorge Luis|01/12/2017|RW-*
        /*Consulta para obtener la lista de productos por cliente*/
        public DataTable GetProductsByCustomer(string pathConnection, Int16 mesProcesoCalculado, string idCustomer)
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
                " and v.CCOD_CLI = '" + idCustomer + "' "
                , pathConnection
                );
        }
        //Jorge Luis|01/12/2017|RW-*
        /*Consulta para obtener la lista de productos por vendedor*/
        public DataTable GetProductsByEmployee(string pathConnection, Int16 mesProcesoCalculado, string idEmployee)
        {
            string mesParametro = "";
            /*Mientras el mes sea menor a 9, antepone un cero. En caso contrario no lo hace.*/
            if (mesProcesoCalculado <= 9)
                mesParametro = "0" + mesProcesoCalculado.ToString();
            else
                mesParametro = mesProcesoCalculado.ToString();
            return dat.extrae(
                " select dist TRIM(vl.CCOD_PRO) as a " + // A = CCOD_VEND
                " from VENTASL as vl " +
                " inner join VENTAS as v " +
                " on vl.CID = v.CID " +
                " where v.CMES = '" + mesParametro + "' " +
                " and v.CCOD_VEND = '" + idEmployee + "' "
                , pathConnection
                );
        }
        //Jorge Luis|15/11/2017|RW-*
        /*Consulta para obtener la lista de productos por vendedor*/
        public DataTable GetProductsByAlcance(string pathConnection, Int16 mesProcesoCalculado, string idEstado)
        {
            string mesParametro = "";
            /*Mientras el mes sea menor a 9, antepone un cero. En caso contrario no lo hace.*/
            if (mesProcesoCalculado <= 9)
                mesParametro = "0" + mesProcesoCalculado.ToString();
            else
                mesParametro = mesProcesoCalculado.ToString();
            return dat.extrae(
                " select dist TRIM(vl.CCOD_PRO) as a " + // A = CCOD_VEND
                " from VENTASL as vl " +
                " inner join VENTAS as v " +
                " on vl.CID = v.CID " +
                " where v.CMES = '" + mesParametro + "' " +
                " and v.LREG = " + idEstado + " "
                , pathConnection
                );
        }
        //Jorge Luis|15/11/2017|RW-*
        /*Consulta para obtener la lista de productos por vendedor*/
        public DataTable GetProductsByStock(string pathConnection, Int16 mesProcesoCalculado, string idEstado)
        {
            string mesParametro = "";
            /*Mientras el mes sea menor a 9, antepone un cero. En caso contrario no lo hace.*/
            if (mesProcesoCalculado <= 9)
                mesParametro = "0" + mesProcesoCalculado.ToString();
            else
                mesParametro = mesProcesoCalculado.ToString();
            return dat.extrae(
                " select dist TRIM(vl.CCOD_PRO) as a " + // A = CCOD_VEND
                " from VENTASL as vl " +
                " inner join VENTAS as v " +
                " on vl.CID = v.CID " +
                " where v.CMES = '" + mesParametro + "' " +
                " and v.LSTOCK = " + idEstado + " "
                , pathConnection
                );
        }
    }
}
