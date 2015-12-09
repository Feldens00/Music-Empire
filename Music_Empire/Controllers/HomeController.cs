using Entidades.E;
using Repositorio.R;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Music_Empire.Controllers
{
    public class HomeController : Controller
    {
        MusicoRepositorys musRep = new MusicoRepositorys();
        LocalRepositorys locRep = new LocalRepositorys();
        loginRepositorys logRep = new loginRepositorys();
        EmpresasRepositorys empRep = new EmpresasRepositorys();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateEmpresas()
        {
            List<Local> ListEstado = new List<Local>(locRep.getAll());
            ViewBag.ListEstado = ListEstado;


            return View();
        }

        [HttpPost]
        public ActionResult CreateEmpresas(Empresas emp)
        {
           
            

            if (ModelState.IsValid)
            {
                empRep.Create(emp);
                return RedirectToAction("Login");
            }
            return View();
        }
        [HttpGet]
        public ActionResult CreateMusicos()
        {

           

            List<Local> ListCidades = new List<Local>(locRep.getAll());
            ViewBag.ListCidades = ListCidades;


            return View();
        }

        [HttpPost]
        public ActionResult CreateMusicos(Musico mus)
        {


            if (ModelState.IsValid)
            {
                musRep.Create(mus);
                return RedirectToAction("Login");
            }
            return View();

        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login pLogin)
        {
            Login usuario;
            if (pLogin.log == 1)
            {
                usuario =  logRep.logar(pLogin);
                if (usuario != null)
                {
                    TempData["identificador"] = usuario.loginEmpresa.idEmpresa;
                    TempData.Keep("identificador");
                    EmpresasController.usuariologado = usuario.loginEmpresa.nomeEmpresa;

                   
                    EmpresasController.logou = true;
                    return RedirectToAction("Empresas", "Empresas");
                }
                else
                {
                    return View();
                }


            }
            if (pLogin.log == 2)
            {
              usuario = logRep.logar(pLogin);
                if (usuario != null)
                {
                    TempData["identificador"] = usuario.loginMusico.idMusico;
                    TempData.Keep("identificador");
                    MusicosController.usuariologado = usuario.loginMusico.nomeMusico;


                    MusicosController.logou = true;
                    return RedirectToAction("Musicos", "Musicos");
                }
                else
                {
                    return View();
                }
            }
            return View();
        }

    }
}