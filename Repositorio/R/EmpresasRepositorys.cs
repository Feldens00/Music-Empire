
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
    public class EmpresasRepositorys
    {
        DataBase conn = new DataBase();
        private List<Empresas> empresa = new List<Empresas>();


        public IEnumerable<Empresas> getAll()
        {
            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();
            sql.Append("select * ");
            sql.Append("FROM empresas  ");
            sql.Append("INNER JOIN locais ");
            sql.Append("ON empresas.idLocal = locais.idLocal ");



            cmm.CommandText = sql.ToString();

            MySqlDataReader dr = conn.executarConsultas(cmm);
            while (dr.Read())
            {

                Empresas emp = new Empresas
                {
                    idEmpresa = (int)dr["idEmpresa"],
                    nomeEmpresa = (string)dr["nomeEmpresa"],
                    enderecoEmpresa = (string)dr["enderecoEmpresa"],

                    localEmpresa = new Local
                    {
                        idLocal = (int)dr["idLocal"],
                        sigla = (string)dr["sigla"],
                        nomeEstado = (string)dr["nomeEstado"],
                        nomeCidade = (string)dr["nomeCidade"]

                    }




                };
                empresa.Add(emp);
            }
            dr.Dispose();
            return empresa;
        }


        public void Create(Empresas pEmp)
        {
            int idPrimario = 0;

            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();
            sql.Append(" insert into empresas ( nomeEmpresa, enderecoEmpresa, idLocal ) ");
            sql.Append(" values (@nome, @endereco, @local ) ");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@nome", pEmp.nomeEmpresa);

            cmm.Parameters.AddWithValue("@local", pEmp.localEmpresa.idLocal);
            cmm.Parameters.AddWithValue("@endereco", pEmp.enderecoEmpresa);
            string nom = pEmp.nomeEmpresa;
            string endereco = pEmp.enderecoEmpresa;

            conn.executarComandoScalar(cmm);
            sql.Clear();

            string comandar;
            comandar = "select idEmpresa, nomeEmpresa, enderecoEmpresa  from empresas where nomeEmpresa = '";
            comandar += nom;
            comandar += "'";
            comandar += " and enderecoEmpresa = '";
            comandar += endereco;
            comandar += "'";


            MySqlDataReader dr = conn.executarConsulta(comandar);

            if (dr.Read())
            {
                idPrimario = (int)dr["idEmpresa"];
            }

            conn.desconectarDB();

            sql.Append("insert into login (empresas_idEmpresa, user, senha ) ");
            sql.Append(" values ( @idE, @user, @senha) ");
            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@idE", idPrimario);
            cmm.Parameters.AddWithValue("@senha", pEmp.loginEmpresa.senha);
            cmm.Parameters.AddWithValue("@user", pEmp.loginEmpresa.user);


            conn.executarComando(cmm);
            sql.Clear();




        }



        public Empresas getOne(int pId)
        {
            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM empresas ");
            sql.Append(" INNER JOIN locais");
            sql.Append(" ON empresas.idLocal = locais.idLocal ");
            sql.Append(" WHERE idEmpresa = @emp");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@emp", pId);
            MySqlDataReader dr = conn.executarConsultas(cmm);
            dr.Read();

            Empresas emp = new Empresas
            {
                idEmpresa = (int)dr["idEmpresa"],
                nomeEmpresa = (string)dr["nomeEmpresa"],
                enderecoEmpresa = (string)dr["enderecoEmpresa"],

                localEmpresa = new Local
                {
                    idLocal = (int)dr["idLocal"],
                    sigla = (string)dr["sigla"],
                    nomeEstado = (string)dr["nomeEstado"],
                    nomeCidade = (string)dr["nomeCidade"],

                }

            };
            dr.Dispose();
            return emp;
        }




        public void Update(Empresas pEmp)
        {

            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();

            sql.Append("update empresas ");
            sql.Append("set nomeEmpresa = @nome, enderecoEmpresa = @endereco, idLocal = @local ");
            sql.Append("where idEmpresa=@emp ");

            cmm.CommandText = sql.ToString();

            cmm.Parameters.AddWithValue("@emp", pEmp.idEmpresa);
            cmm.Parameters.AddWithValue("@endereco", pEmp.enderecoEmpresa);
            cmm.Parameters.AddWithValue("@nome", pEmp.nomeEmpresa);
            cmm.Parameters.AddWithValue("@local", pEmp.localEmpresa.idLocal);
            conn.executarComando(cmm);
        }
        public void Delete(int pId)
        {


            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            sql.Append("delete from empresas where idEmpresa = @id_delete");
            cmm.CommandText = sql.ToString();

            cmm.Parameters.AddWithValue("@id_delete", pId);

            conn.executarComando(cmm);


        }
    }
}
