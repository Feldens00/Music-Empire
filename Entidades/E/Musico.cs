using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.E
{
    public class Musico
    {
        public int idMusico { get; set; }
        public string nomeMusico { get; set; }
        public string enderecoMusico { get; set; }
        public Local localMusico { get; set; }
        public Login loginMusico { get; set; }

        public Musico()
        {

        }

        public Musico(int pIdMusico, string pNomeMusico,Login pLoginMusico, string pEnderecoMusico, Local pLocalMusico)
        {
            idMusico = pIdMusico;
            nomeMusico = pNomeMusico;
            enderecoMusico = pEnderecoMusico;
            localMusico = pLocalMusico;
            loginMusico = pLoginMusico;

        }
    }
}
