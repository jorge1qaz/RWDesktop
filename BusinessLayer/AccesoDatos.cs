﻿using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class AccesoDatos
    {
        //Jorge Luis|04/10/2017|RW-19
        /*Método para extraer datos, mediante una consulta como parámetro*/
        Conexion con = new Conexion();
        public DataTable extrae(string consulta)
        {
            DataTable tabla = new DataTable();
            con.Conectar();
            OdbcCommand cmd = new OdbcCommand();
            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.cn;
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            da.Fill(tabla);
            con.cn.Close();
            return tabla;
        }
        //Jorge Luis|23/10/2017|RW-19
        /*Método para extraer datos, mediante una consulta con dos parámetros*/
        public DataTable extrae(string consulta, string path)
        {
            DataTable tabla = new DataTable();
            con.Conectar(path);
            OdbcCommand cmd = new OdbcCommand();
            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            //cmd.CommandTimeout = 0;
            cmd.Connection = con.cn;
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            da.Fill(tabla);
            con.cn.Close();
            return tabla;
        }
        //Jorge Luis|15/11/2017|RW-19
        /*Método para extraer datos, mediante una consulta con dos parámetros en un objeto de tipo List*/
        public List<string> extraeList(string consulta, string path)
        {
            List<string> list = new List<string>();
            con.Conectar(path);
            OdbcCommand cmd = new OdbcCommand();
            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.cn;
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            using( OdbcDataReader reader = cmd.ExecuteReader()) {
                while (reader.Read())
                {
                    list.Add(reader.GetString(0));
                }
            }
            con.cn.Close();
            return list;
        }
        //Jorge Luis|23/10/2017|RW-19
        /*Método para extraer datos, mediante una consulta con dos parámetros*/
        public DataTable extraeInit(string consulta)
        {
            DataTable tabla = new DataTable();
            con.ConectInit();
            OdbcCommand cmd = new OdbcCommand();
            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.cn;
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            da.Fill(tabla);
            con.cn.Close();
            return tabla;
        }
        //Jorge Luis|02/11/2017|RW-19
        /*Método para extraer datos de la base de datos web, mediante una consulta como parámetro*/
        public DataTable extraeDbWeb(string consulta)
        {
            DataTable tabla = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            tabla = new DataTable();
            cmd.Connection = con.cadena;
            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.StoredProcedure;
            con.ConectDbWeb();
            da.SelectCommand = cmd;
            da.Fill(tabla);
            con.cadena.Close();
            return tabla;
        }
    }
}
