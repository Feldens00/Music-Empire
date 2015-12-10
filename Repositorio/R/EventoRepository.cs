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
    public class EventoRepository
    {
        DataBase conn = new DataBase();
        private List<Eventos> evento = new List<Eventos>();


        public IEnumerable<Eventos> getAllEventos()
        {
            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();
            sql.Append("select * ");
            sql.Append("FROM eventos e ");
            sql.Append("inner join locais l ON e.idLocal = l.idLocal ");



            //para nao dar muitas linhas fiz assim



            cmm.CommandText = sql.ToString();

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


                };
                evento.Add(eve);
            }
            dr.Dispose();
            return evento;
        }
        public StringBuilder ConverterData(DateTime pData)
        {
            int dataY = pData.Year;
            int dataM = pData.Month;
            int dataD = pData.Day;
            StringBuilder datac = new StringBuilder();
            datac.Append(dataY.ToString());
            datac.Append("/");
            datac.Append(dataM.ToString());
            datac.Append("/");
            datac.Append(dataD.ToString());

            return datac;
        }


        //public IEnumerable<Eventos> getAll()
        //{
        //    MySqlCommand cmm = new MySqlCommand();

        //    StringBuilder sql = new StringBuilder();
        //    sql.Append("select  DISTINCT * ");
        //    sql.Append("FROM eventos e ");
        //    sql.Append("inner join eventos_empresas ee on ee.eventos_idEvento = e.idEvento ");
        //    sql.Append("inner join empresas emp on emp.idEmpresa = ee.empresas_idEmpresa ");
        //    sql.Append("UNION ");
        //    sql.Append("inner join eventos_musicos em on em.eventos_idEvento = e.idEvento ");
        //    sql.Append("inner join musicos m on m.idMusico = em.musicos_idMusico");


        //    //para nao dar muitas linhas fiz assim



        //    cmm.CommandText = sql.ToString();

        //    MySqlDataReader dr = conn.executarConsultas(cmm);
        //    while (dr.Read())
        //    {

        //        Eventos eve = new Eventos
        //        {
        //            idEvento = (int)dr["idEvento"],
        //            nomeEvento = (string)dr["nomeEvento"],
        //            dataEvento = (string)dr["dataEvento"],
        //            enderecoEvento = (string)dr["enderecoEvento"],

        //            empresaEvento = new Empresas
        //            {
        //                idEmpresa = (int)dr["idEmpresa"],
        //                nomeEmpresa = (string)dr["nomeEmpresa"],
        //                enderecoEmpresa = (string)dr["enderecoEmpresa"]
        //            },

        //            musico = new Musico
        //            {
        //                idMusico = (int)dr["idMusico"],
        //                nomeMusico = (string)dr["nomeMusico"],
        //                enderecoMusico = (string)dr["enderecoMusico"]
        //            }

        //        };
        //        evento.Add(eve);
        //    }
        //    dr.Dispose();
        //    return evento;
        //}

        public IEnumerable<Eventos> getAllMusico()
        {
            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();
            sql.Append("select  * ");
            sql.Append("from eventos e ");
            sql.Append("inner join eventos_musicos em on em.eventos_idEvento = e.idEvento ");
            sql.Append("inner join musicos m on m.idMusico = em.musicos_idMusico ");
            sql.Append("order by idEvento desc");

            //para nao dar muitas linhas fiz assim



            cmm.CommandText = sql.ToString();

            MySqlDataReader dr = conn.executarConsultas(cmm);
            while (dr.Read())
            {

                Eventos eve = new Eventos
                {
                    idEvento = (int)dr["idEvento"],
                    nomeEvento = (string)dr["nomeEvento"],
                    dataEvento = (DateTime)dr["dataEvento"],
                    enderecoEvento = (string)dr["enderecoEvento"],



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


        public IEnumerable<Eventos> getAllEmpresa()
        {
            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();
            sql.Append("select * ");
            sql.Append("from eventos e ");
            sql.Append("inner join eventos_empresas ee on ee.eventos_idEvento = e.idEvento ");
            sql.Append("inner join empresas emp on emp.idEmpresa = ee.empresas_idEmpresa ");
            sql.Append("order by idEvento desc ");


            //para nao dar muitas linhas fiz assim



            cmm.CommandText = sql.ToString();

            MySqlDataReader dr = conn.executarConsultas(cmm);
            while (dr.Read())
            {

                Eventos eve = new Eventos
                {
                    idEvento = (int)dr["idEvento"],
                    nomeEvento = (string)dr["nomeEvento"],
                    dataEvento = (DateTime)dr["dataEvento"],
                    enderecoEvento = (string)dr["enderecoEvento"],

                    empresaEvento = new Empresas
                    {
                        idEmpresa = (int)dr["idEmpresa"],
                        nomeEmpresa = (string)dr["nomeEmpresa"],
                        enderecoEmpresa = (string)dr["enderecoEmpresa"]
                    },



                };
                evento.Add(eve);
            }
            dr.Dispose();
            return evento;
        }



        public void addEmpresa(Eventos evento)
        {

            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();


            sql.Append("insert into eventos_empresas (eventos_idEvento, empresas_idEmpresa ) ");
            sql.Append("values (@evento, @empresa ) ");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@empresa", evento.empresaEvento.idEmpresa);
            cmm.Parameters.AddWithValue("@evento", evento.idEvento);
            conn.executarComando(cmm);
            sql.Clear();



        }

        public void addMusico(Eventos evento)
        {

            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();



            sql.Append("insert into eventos_musicos (eventos_idEvento, musicos_idMusico ) ");
            sql.Append("values (@eve, @musico ) ");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@musico", evento.musico.idMusico);
            cmm.Parameters.AddWithValue("@eve", evento.idEvento);
            conn.executarComando(cmm);
            sql.Clear();



        }


        public void DeleteEmpresa(int pId)
        {



            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            sql.Append("delete from eventos_empresas where empresas_idEmpresa = @delete");
            cmm.CommandText = sql.ToString();

            cmm.Parameters.AddWithValue("@delete", pId);

            conn.executarComando(cmm);



        }

        public void DeleteMusico(int pId)
        {



            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            sql.Append("delete from eventos_musicos where musicos_idMusico = @id_delete");
            cmm.CommandText = sql.ToString();

            cmm.Parameters.AddWithValue("@id_delete", pId);

            conn.executarComando(cmm);



        }


        public void Create(Eventos pEve)
        {
            int idPrimario = 0;

            MySqlCommand cmm = new MySqlCommand();

            StringBuilder datac = ConverterData(pEve.dataEvento);

            StringBuilder sql = new StringBuilder();
            sql.Append("insert into eventos (nomeEvento, dataEvento, enderecoEvento, idLocal) ");
            sql.Append("values (@nome, @data, @endereco, @local ) ");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@nome", pEve.nomeEvento);
            cmm.Parameters.AddWithValue("@data", datac);
            cmm.Parameters.AddWithValue("@local", pEve.localEvento.idLocal);
            cmm.Parameters.AddWithValue("@endereco", pEve.enderecoEvento);
            string nom = pEve.nomeEvento;
            string datae = datac.ToString();

            conn.executarComandoScalar(cmm);
            sql.Clear();

            string comandar;
            comandar = "select idEvento, nomeEvento, dataEvento  from eventos where nomeEvento = '";
            comandar += nom;
            comandar += "'";
            comandar += " and dataEvento = '";
            comandar += datae;
            comandar += "'";


            MySqlDataReader dr = conn.executarConsulta(comandar);

            if (dr.Read())
            {
                idPrimario = (int)dr["idEvento"];
            }

            conn.desconectarDB();

            sql.Append("insert into eventos_empresas (empresas_idEmpresa, eventos_idEvento) ");
            sql.Append("values (@idE, @idP) ");
            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@idE", pEve.empresaEvento.idEmpresa);
            cmm.Parameters.AddWithValue("@idP", idPrimario);

            conn.executarComando(cmm);
            sql.Clear();

            sql.Append("insert into eventos_musicos (eventos_idEvento, musicos_idMusico) ");
            sql.Append("values (@idChato, @idM) ");
            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@idChato", idPrimario);
            cmm.Parameters.AddWithValue("@idM", pEve.musico.idMusico);

            conn.executarComando(cmm);
            sql.Clear();


        }



        public Eventos getOne(int pId)
        {
            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();
            sql.Append("select * ");
            sql.Append(" FROM eventos ");
            sql.Append(" INNER JOIN locais");
            sql.Append(" ON eventos.idLocal = locais.idLocal ");

            sql.Append(" WHERE idEvento = @eve");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@eve", pId);
            MySqlDataReader dr = conn.executarConsultas(cmm);
            dr.Read();

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

                }




            };
            dr.Dispose();
            return eve;
        }




        public void Update(Eventos pEve)
        {

            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();

            sql.Append("update eventos ");
            sql.Append("set nomeEvento = @nome, dataEvento = @data, enderecoEvento = @endereco, idLocal = @local ");
            sql.Append("where idEvento = @eve ");

            cmm.CommandText = sql.ToString();

            cmm.Parameters.AddWithValue("@eve", pEve.idEvento);
            cmm.Parameters.AddWithValue("@nome", pEve.nomeEvento);
            cmm.Parameters.AddWithValue("@data", pEve.dataEvento);
            cmm.Parameters.AddWithValue("@endereco", pEve.enderecoEvento);
            cmm.Parameters.AddWithValue("@local", pEve.localEvento.idLocal);

            conn.executarComando(cmm);
        }
        public void Delete(int pId)
        {



            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            sql.Append("delete from eventos where idEvento = @id_delete");
            cmm.CommandText = sql.ToString();

            cmm.Parameters.AddWithValue("@id_delete", pId);

            conn.executarComando(cmm);



        }
    }
}
