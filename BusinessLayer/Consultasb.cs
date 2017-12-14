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
                " where CCOD_BAL2 = TRIM('" + idRubro + "') "
                ,pathConection
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
    }
}
