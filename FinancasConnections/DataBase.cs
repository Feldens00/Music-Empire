using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasConnections
{
    public class DataBase
    {

        public MySqlConnection conn = new MySqlConnection();
        public MySqlCommand cmm;
        public MySqlDataReader dr;

        public string connString
        {
            get { return "Server=localhost;Database=musicempire;Uid=root;Pwd=;"; }
        }

        private void conectarDB()
        {
            conn.ConnectionString = connString;

            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
        }

        public void desconectarDB()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        /*public void executarComando(string pSql)
        {
            conectarDB();
            cmm = new MySqlCommand(pSql, conn);
            cmm.ExecuteNonQuery();
        }*/

        public void executarComando(MySqlCommand cmm)
        {
            conectarDB();
            cmm.Connection = conn;

            try
            {
                cmm.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
               
             throw ex;
            }
            desconectarDB();

        }

        public MySqlDataReader executarConsulta(string pSql)
        {
            conectarDB();
            cmm = new MySqlCommand(pSql, conn);

            try
            {
                dr = cmm.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                dr.Dispose();
                throw ex;
            }

            return dr;
        }

        public MySqlDataReader executarConsultas(MySqlCommand cmm)
        {
            conectarDB();
            cmm.Connection = conn;

            try
            {
                dr = cmm.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                dr.Dispose();
                throw ex;
            }
            
            return dr;
        }
        public void executarComandoScalar(MySqlCommand cmm)
        {

            conectarDB();
            cmm.Connection = conn;

            try
            {
                cmm.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                dr.Dispose();
                throw ex;
            }

            desconectarDB();
            
        }
    }
}
