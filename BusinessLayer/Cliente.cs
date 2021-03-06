﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class Cliente
    {
        public string IdCliente { get; set; }
        public string Contrasenia { get; set; }
        public DateTime DateUpdate { get; set; }
        //Jorge Luis|03/11/2017|RW-19
        /*Método para ejecutar un procedimiento almacenado, con los atributos de Cliente. Incluye dos parametros de entrada y dos de salida*/
        public bool[] AuthenticateUser(string storeProcedure)
        {
            bool[] states = new bool[2];
            Conexion con = new Conexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = storeProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con.cadena;

            SqlParameter paramIdCliente = new SqlParameter();
            paramIdCliente.SqlDbType = SqlDbType.NVarChar;
            paramIdCliente.ParameterName = "@IdCliente";
            paramIdCliente.Value = IdCliente;
            cmd.Parameters.Add(paramIdCliente);

            SqlParameter paramContrasenia = new SqlParameter();
            paramContrasenia.SqlDbType = SqlDbType.NVarChar;
            paramContrasenia.ParameterName = "@Contrasenia";
            paramContrasenia.Value = Contrasenia;
            cmd.Parameters.Add(paramContrasenia);

            SqlParameter paramComprobacion = new SqlParameter();
            paramComprobacion.Direction = ParameterDirection.Output;
            paramComprobacion.SqlDbType = SqlDbType.Bit;
            paramComprobacion.ParameterName = "@Comprobacion";
            cmd.Parameters.Add(paramComprobacion);

            SqlParameter paramActivateAccount = new SqlParameter();
            paramActivateAccount.Direction = ParameterDirection.Output;
            paramActivateAccount.SqlDbType = SqlDbType.Bit;
            paramActivateAccount.ParameterName = "@ActivateAccount";
            cmd.Parameters.Add(paramActivateAccount);

            con.ConnectDbWeb();
            cmd.ExecuteNonQuery();
            con.DisconnectDbWeb();
            states[0] = bool.Parse(cmd.Parameters["@Comprobacion"].Value.ToString());
            states[1] = bool.Parse(cmd.Parameters["@ActivateAccount"].Value.ToString());
            return states;
        }
        public bool WriteParametersUserLastUpdate(string storeProcedure)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = storeProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con.cadena;

            SqlParameter paramIdCliente = new SqlParameter();
            paramIdCliente.SqlDbType = SqlDbType.NVarChar;
            paramIdCliente.ParameterName = "@IdCliente";
            paramIdCliente.Value = IdCliente;
            cmd.Parameters.Add(paramIdCliente);

            SqlParameter paramDateUpdate = new SqlParameter();
            paramDateUpdate.SqlDbType = SqlDbType.DateTime;
            paramDateUpdate.ParameterName = "@DateUpdate";
            paramDateUpdate.Value = DateUpdate;
            cmd.Parameters.Add(paramDateUpdate);

            SqlParameter paramComprobacion = new SqlParameter();
            paramComprobacion.Direction = ParameterDirection.Output;
            paramComprobacion.SqlDbType = SqlDbType.Bit;
            paramComprobacion.ParameterName = "@Comprobacion";
            cmd.Parameters.Add(paramComprobacion);

            con.ConnectDbWeb();
            cmd.ExecuteNonQuery();
            con.DisconnectDbWeb();
            return bool.Parse(cmd.Parameters["@Comprobacion"].Value.ToString());
        }
    }
}
