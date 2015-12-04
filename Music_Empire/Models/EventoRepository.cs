using FinancasConnections;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Music_Empire.Models
{
    public class EventoRepository
    {
        DataBase conn = new DataBase();
        private List<Eventos> evento = new List<Eventos>();


        public IEnumerable<Eventos> getAll()
        {
            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();
            sql.Append("select * ");
            sql.Append(" FROM eventos ");
            sql.Append(" INNER JOIN locais");
            sql.Append(" ON eventos.idLocal = locais.idLocal ");
           



            cmm.CommandText = sql.ToString();

            MySqlDataReader dr = conn.executarConsultas(cmm);
            while (dr.Read())
            {

                Eventos eve = new Eventos
                {
                    idEvento = (int)dr["idEvento"],
                    nomeEvento = (string)dr["nomeEvento"],
                    dataEvento = (string)dr["dataEvento"],
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

        public void addEmpresaEvento(Empresas empresa, int pIdEvento)
        {

            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();
           
            
                sql.Append(" insert into eventos_empresas (eventos_idEvento, empresas_idEmpresa ) ");
                sql.Append(" values (@evento, @empresa ) ");

                cmm.CommandText = sql.ToString();
                cmm.Parameters.AddWithValue("@empresa", empresa.idEmpresa);
                cmm.Parameters.AddWithValue("@evento", pIdEvento);
                conn.executarComando(cmm);
            


        }

        //public void GetAll_EmpresaEvento( )
        //{

        //    MySqlCommand cmm = new MySqlCommand();

        //    StringBuilder sql = new StringBuilder();
        //    sql.Append("select * ");
        //    sql.Append(" FROM eventos_empresa ");
           




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
        //            localEvento = new Local
        //            {
        //                idLocal = (int)dr["idLocal"],
        //                sigla = (string)dr["sigla"],
        //                nomeEstado = (string)dr["nomeEstado"],
        //                nomeCidade = (string)dr["nomeCidade"]


        //            },

        //        };
        //        evento.Add(eve);
        //    }
        //    dr.Dispose();
        //    return evento;



        //}


        public void Create(Eventos pEve )
        {

            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();
            sql.Append(" insert into eventos ( nomeEvento, dataEvento, enderecoEvento, idLocal ) ");
            sql.Append(" values (@nome, @data, @endereco, @local ) ");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@nome", pEve.nomeEvento);
            cmm.Parameters.AddWithValue("@data", pEve.dataEvento);
            cmm.Parameters.AddWithValue("@local", pEve.localEvento.idLocal);
            cmm.Parameters.AddWithValue("@endereco", pEve.dataEvento);
           
                
            conn.executarComando(cmm);
            sql.Clear();
            addEmpresaEvento(pEve.empresaEvento, pEve.idEvento);
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
                dataEvento = (string)dr["dataEvento"],
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
            sql.Append("set nomeEvento = @nome, dataEvento = @data, endereco = @endereco, idLocal = @local");
            sql.Append("where idEvento=@eve ");

            cmm.CommandText = sql.ToString();

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