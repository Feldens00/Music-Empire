using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.E
{
    public class Eventos
    {
        public int idEvento { get; set; }
        public string nomeEvento { get; set; }
        public string dataEvento { get; set; }
        public string enderecoEvento { get; set; }
        public Local localEvento { get; set; }
        public Empresas empresaEvento { get; set; }
        public Musico musico { get; set; }
        //public List<Empresas> arrayEmpresa { get; set; }




        public Eventos()
        {

        }

        public Eventos(int pIdEvento, string pNomeEvento, Empresas pEmpresaEvento, Musico pMusico, string pDataEvento, string pEnderecoEvento,
            Local pLocalEvento)
        {
            idEvento = pIdEvento;
            nomeEvento = pNomeEvento;
            dataEvento = pDataEvento;
            enderecoEvento = pEnderecoEvento;
            localEvento = pLocalEvento;
            musico = pMusico;
            empresaEvento = pEmpresaEvento;


        }
    }
}
