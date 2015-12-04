using FinancasConnections;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Music_Empire.Models
{
    public class Empresas
    {

        DataBase conn = new DataBase();

        public int idEmpresa { get; set; }
        public string nomeEmpresa { get; set; }
        public string enderecoEmpresa { get; set; }
        public  Local  localEmpresa { get; set; }
        
        
        public Empresas()
        {

        }
       

        public Empresas(int pIdEmpresa, string pNomeEmpresa, Local pLocalEmpresa, string pEnderecoEmpresa)
        {
            idEmpresa = pIdEmpresa;
            nomeEmpresa = pNomeEmpresa;
            enderecoEmpresa = pEnderecoEmpresa;
            localEmpresa = pLocalEmpresa;
        }
    }


}