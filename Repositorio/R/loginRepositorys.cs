using Entidades.E;
using FinancasConnections;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.R
{
    public class loginRepositorys
    {
       
        DataBase db = new DataBase();
        MySqlCommand cmm = new MySqlCommand();
        StringBuilder sql = new StringBuilder();

        public Login logar(Login pLogin)
        {
            if (pLogin.log == 1)
            {
                sql.Append("SELECT l.empresas_idEmpresa, l.senha, l.user " +
                    "FROM login l " +
                    "INNER JOIN empresas e " +
                    "ON e.idEmpresa = l.empresas_idEmpresa " +
                    "WHERE l.senha = @pass AND l.user = @user ");

                cmm.CommandText = sql.ToString();
                cmm.Parameters.AddWithValue("@pass", pLogin.senha);
                cmm.Parameters.AddWithValue("@user", pLogin.user);
                MySqlDataReader dr = db.executarConsultas(cmm);

                if (dr.HasRows)
                {
                    dr.Read();

                    Login log = new Login
                    {
                        user = (string)dr["user"],
                        senha = (string)dr["senha"],
                        loginEmpresa = new Empresas
                        {
                            idEmpresa = (int)dr["empresas_idEmpresa"]


                        }
                    };

                    dr.Close();
                    dr.Dispose();
                    sql.Clear();

                    return log;
                }
                else
                {
                    dr.Close();
                    dr.Dispose();
                    sql.Clear();

                    return null;
                }
            }
            else
            {
                sql.Append("SELECT l.musicos_idMusico, l.senha, l.user " +
                    "FROM login l " +
                    "INNER JOIN musicos m " +
                    "ON m.idMusico = l.musicos_idMusico " +
                    "WHERE l.senha = @pass AND l.user = @user");
                cmm.CommandText = sql.ToString();
                cmm.Parameters.AddWithValue("@pass", pLogin.senha);
                cmm.Parameters.AddWithValue("@user", pLogin.user);
                MySqlDataReader dr = db.executarConsultas(cmm);

                if (dr.HasRows)
                {
                    dr.Read();

                    Login log = new Login
                    {
                        user = (string)dr["user"],
                        senha = (string)dr["senha"],
                        loginMusico = new Musico
                        {
                            idMusico = (int)dr["musicos_idMusico"]
                        }
                    };

                    dr.Close();
                    dr.Dispose();
                    sql.Clear();

                    return log;
                }
                else
                {
                    dr.Close();
                    dr.Dispose();
                    sql.Clear();

                    return null;
                }
            }
        }
    }
}
