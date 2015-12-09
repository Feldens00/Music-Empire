using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.E
{
    public class Local
    {
        

        public int idLocal { get; set; }
        public string sigla { get; set; }
        public string nomeEstado { get; set; }
        public string nomeCidade { get; set; }


        public Local()
        {

        }

        public Local(int pIdLocal, string pSigla, string pNomeEstado, string pNomeCidade)
        {
            idLocal = pIdLocal;
            nomeEstado = pNomeEstado;
            sigla = pSigla;
            nomeCidade = pNomeCidade;



        }
    }
}
