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
    public class LocalRepositorys
    {
        DataBase conn = new DataBase();
        private List<Local> local = new List<Local>();




        public IEnumerable<Local> getAll()
        {
            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();
            sql.Append("select  * ");
            sql.Append(" FROM locais  ");




            cmm.CommandText = sql.ToString();

            MySqlDataReader dr = conn.executarConsultas(cmm);
            while (dr.Read())
            {

                Local loc = new Local
                {
                    idLocal = (int)dr["idLocal"],
                    sigla = (string)dr["sigla"],
                    nomeEstado = (string)dr["nomeEstado"],
                    nomeCidade = (string)dr["nomeCidade"],




                };
                local.Add(loc);
            }
            dr.Dispose();
            return local;
        }


        public void Create(Local pLoc)
        {

            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();
            sql.Append(" insert into locais ( sigla, nomeEstado, nomeCidade ) ");
            sql.Append(" values ( @sigla, @estado, @cidade   ) ");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@estado", pLoc.nomeEstado);
            cmm.Parameters.AddWithValue("@sigla", pLoc.sigla);
            cmm.Parameters.AddWithValue("@cidade", pLoc.nomeCidade);


            conn.executarComando(cmm);
        }



        public Local getOne(int pId)
        {
            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM locais ");
            sql.Append(" WHERE idLocal = @loc ");


            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@loc", pId);
            MySqlDataReader dr = conn.executarConsultas(cmm);
            dr.Read();

            Local loc = new Local
            {
                idLocal = (int)dr["idLocal"],
                sigla = (string)dr["sigla"],
                nomeEstado = (string)dr["nomeEstado"],
                nomeCidade = (string)dr["nomeCidade"],



            };
            dr.Dispose();
            return loc;
        }




        public void Update(Local pLoc)
        {

            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();

            sql.Append("update locais ");
            sql.Append("set sigla = @sigla, nomeEstado = @estado, nomeCidade = @cidade ");
            sql.Append("where idLocal= @loc ");

            cmm.CommandText = sql.ToString();

            cmm.Parameters.AddWithValue("@estado", pLoc.nomeEstado);
            cmm.Parameters.AddWithValue("@sigla", pLoc.sigla);
            cmm.Parameters.AddWithValue("@cidade", pLoc.nomeCidade);

            cmm.Parameters.AddWithValue("@loc", pLoc.idLocal);
            conn.executarComando(cmm);
        }

        public void Delete(int pId)
        {


            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            sql.Append("delete from locais where idLocal = @id_delete");
            cmm.CommandText = sql.ToString();

            cmm.Parameters.AddWithValue("@id_delete", pId);

            conn.executarComando(cmm);


        }
    }
}
