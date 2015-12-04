using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Music_Empire.Models
{
    public class Musico
    {
        public int idMusico { get; set; }
        public string  nomeMusico { get; set; }
        public string  enderecoMusico { get; set; }
        public Local  localMusico { get; set; }

        public Musico()
        {

        }

        public Musico(int pIdMusico, string pNomeMusico, string pEnderecoMusico, Local pLocalMusico)
        {
            idMusico = pIdMusico;
            nomeMusico = pNomeMusico;
            enderecoMusico = pEnderecoMusico;
            localMusico = pLocalMusico;


        }
    }
}