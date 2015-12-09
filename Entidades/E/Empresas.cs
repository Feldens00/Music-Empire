using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.E
{
    public class Empresas
    {

        public int idEmpresa { get; set; }
        public string nomeEmpresa { get; set; }
        public string enderecoEmpresa { get; set; }
        public Local localEmpresa { get; set; }
        public Login loginEmpresa { get; set; }


        public Empresas()
        {

        }


        public Empresas(int pIdEmpresa, string pNomeEmpresa, Login pLoginEmpresa, Local pLocalEmpresa, string pEnderecoEmpresa)
        {
            idEmpresa = pIdEmpresa;
            nomeEmpresa = pNomeEmpresa;
            enderecoEmpresa = pEnderecoEmpresa;
            localEmpresa = pLocalEmpresa;
            loginEmpresa = pLoginEmpresa;

        }
    }
}
