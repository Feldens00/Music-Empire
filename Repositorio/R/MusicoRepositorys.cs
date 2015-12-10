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
    public class MusicoRepositorys
    {
        DataBase conn = new DataBase();
        private List<Musico> musico = new List<Musico>();
        private List<Eventos> evento = new List<Eventos>();

        public IEnumerable<Eventos> getEventos(string nome)
        {
            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();
            sql.Append(" select * ");
            sql.Append(" From eventos e ");
            sql.Append(" inner join locais l ");
            sql.Append(" on e.idLocal = l.idLocal ");
            sql.Append(" inner join eventos_musicos em ");
            sql.Append(" on e.idEvento = em.eventos_idEvento");
            sql.Append(" inner join musicos m ");
            sql.Append(" on m.idMusico = em.musicos_idMusico ");
            sql.Append(" where m.nomeMusico = @mus ");
            sql.Append("   order by idEvento desc ");


            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@mus", nome);


            MySqlDataReader dr = conn.executarConsultas(cmm);
            while (dr.Read())
            {
                Eventos eve = new Eventos
                {
                    idEvento = (int)dr["idEvento"],
                    nomeEvento = (string)dr["nomeEvento"],
                    dataEvento = (DateTime)dr["dataEvento"],
                    enderecoEvento = (string)dr["enderecoEvento"],

                    localEvento = new Local
                    {
                        idLocal = (int)dr["idLocal"],
                        sigla = (string)dr["sigla"],
                        nomeEstado = (string)dr["nomeEstado"],
                        nomeCidade = (string)dr["nomeCidade"]


                    },
                    musico = new Musico
                    {
                        idMusico = (int)dr["idMusico"],
                        nomeMusico = (string)dr["nomeMusico"],
                        enderecoMusico = (string)dr["enderecoMusico"]
                    }
                };
                evento.Add(eve);
            }
            dr.Dispose();
            return evento;
        }
        public IEnumerable<Musico> getAll()
        {
            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();
            sql.Append("select  * from musicos ");
            sql.Append("INNER JOIN locais ");
            sql.Append("ON musicos.idLocal = locais.idLocal");

            //select* from musicos m
            //inner join eventos_musicos em on em.musicos_idMusico = m.idMusico
            //where idMusico <> em.musicos_idMusico and em.eventos_idEvento = 27

            cmm.CommandText = sql.ToString();

            MySqlDataReader dr = conn.executarConsultas(cmm);



            while (dr.Read())
            {

                Musico mus = new Musico
                {
                    idMusico = (int)dr["idMusico"],
                    nomeMusico = (string)dr["nomeMusico"],
                    enderecoMusico = (string)dr["enderecoMusico"],

                    localMusico = new Local
                    {
                        idLocal = (int)dr["idLocal"],
                        sigla = (string)dr["sigla"],
                        nomeEstado = (string)dr["nomeEstado"],
                        nomeCidade = (string)dr["nomeCidade"]


                    }


                };
                musico.Add(mus);
            }
            dr.Dispose();
            return musico;
        }


        public void Create(Musico pMus)
        {
            int idPrimario = 0;

            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();
            sql.Append(" insert into musicos ( nomeMusico, enderecoMusico, idLocal ) ");
            sql.Append(" values (@nome, @endereco, @local ) ");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@nome", pMus.nomeMusico);
            cmm.Parameters.AddWithValue("@endereco", pMus.enderecoMusico);
            cmm.Parameters.AddWithValue("@local", pMus.localMusico.idLocal);
            string nom = pMus.nomeMusico;
            string endereco = pMus.enderecoMusico;

            conn.executarComandoScalar(cmm);
            sql.Clear();

            string comandar;
            comandar = "select idMusico, nomeMusico, enderecoMusico  from musicos where nomeMusico = '";
            comandar += nom;
            comandar += "'";
            comandar += " and enderecoMusico = '";
            comandar += endereco;
            comandar += "'";


            MySqlDataReader dr = conn.executarConsulta(comandar);

            if (dr.Read())
            {
                idPrimario = (int)dr["idMusico"];
            }

            conn.desconectarDB();

            sql.Append("insert into login ( musicos_idMusico, user, senha ) ");
            sql.Append(" values ( @idE, @user, @senha) ");
            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@idE", idPrimario);
            cmm.Parameters.AddWithValue("@senha", pMus.loginMusico.senha);
            cmm.Parameters.AddWithValue("@user", pMus.loginMusico.user);


            conn.executarComando(cmm);
            sql.Clear();




        }



        public Musico getOne(int pId)
        {
            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM musicos ");
            sql.Append(" INNER JOIN locais");
            sql.Append(" ON musicos.idLocal = locais.idLocal ");
            sql.Append(" WHERE idMusico = @mus");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@mus", pId);
            MySqlDataReader dr = conn.executarConsultas(cmm);
            dr.Read();

            Musico mus = new Musico
            {
                idMusico = (int)dr["idMusico"],
                nomeMusico = (string)dr["nomeMusico"],
                enderecoMusico = (string)dr["enderecoMusico"],

                localMusico = new Local
                {
                    idLocal = (int)dr["idLocal"],
                    sigla = (string)dr["sigla"],
                    nomeEstado = (string)dr["nomeEstado"],
                    nomeCidade = (string)dr["nomeCidade"]

                }
            };
            dr.Dispose();
            return mus;
        }




        public void Update(Musico pMus)
        {

            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();

            sql.Append("update musicos ");
            sql.Append("set nomeMusico = @nome, enderecoMusico = @endereco, idLocal = @local ");
            sql.Append("where idMusico = @mus ");

            cmm.CommandText = sql.ToString();

            cmm.Parameters.AddWithValue("@mus", pMus.idMusico);
            cmm.Parameters.AddWithValue("@nome", pMus.nomeMusico);
            cmm.Parameters.AddWithValue("@endereco", pMus.enderecoMusico);
            cmm.Parameters.AddWithValue("@local", pMus.localMusico.idLocal);
            conn.executarComando(cmm);
        }
        public void Delete(int pId)
        {


            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            sql.Append("delete from musicos where idMusico = @id_delete");
            cmm.CommandText = sql.ToString();

            cmm.Parameters.AddWithValue("@id_delete", pId);

            conn.executarComando(cmm);


        }
    }
}
