using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Music_Empire.Models
{
    public class Local
    {
        //public string sigla { get; set; }
        //public string nome { get; set; }
        //public List<string> cidades { get; set; }

        public int idLocal { get; set; }
        public string sigla { get; set; }
        public string nomeEstado { get; set; }
        public string nomeCidade { get; set; }


        public Local()
        {
                
        }

        public Local(int pIdLocal, string pSigla, string pNomeEstado, string pNomeCidade )
        {
            idLocal = pIdLocal;
            nomeEstado = pNomeEstado;
            sigla = pSigla;
            nomeCidade = pNomeCidade;
            
            

        }
    }
}