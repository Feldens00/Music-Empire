using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.E
{
    public class Login
    {
        public int idLogin { get; set; }
        public string senha { get; set; }
        public string user { get; set; }
        public Empresas loginEmpresa { get; set; }
        public Musico loginMusico { get; set; }
        public int  log { get; set; }

        public Login()
        {

        }

        public Login(int pIdLogin, string pSenha, string pUser, Empresas pLoginEmpresa, Musico pLoginMusico)
        {
            idLogin = pIdLogin;
            senha = pSenha;
            user = pUser;
            loginEmpresa = pLoginEmpresa;
            loginMusico = pLoginMusico;
        }
    }
}
