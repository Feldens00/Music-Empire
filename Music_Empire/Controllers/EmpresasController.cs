using Entidades.E;
using FinancasConnections;
using Repositorio.R;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Music_Empire.Controllers
{
    public class EmpresasController : Controller
    {
        DataBase database = new DataBase();
        EmpresasRepositorys empRep = new EmpresasRepositorys();
        LocalRepositorys locRep = new LocalRepositorys();
        

        public static int ident;
        public static string usuariologado;
        public static bool logou;
        // GET: Empresas
        public ActionResult Empresas()
        {
            if (logou)
            {
                ident = (int)TempData.Peek("identificador");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            var emp = empRep.getAll();
            return View(emp);
        }

       

        public ActionResult Delete(int id)
        {
            empRep.Delete(id);
            return RedirectToAction("Empresas");
        }

        public ActionResult UpdateEmpresas(int id)
        {
            List<Local> ListEstado = new List<Local>(locRep.getAll());
            ViewBag.ListEstado = ListEstado;
            

            var emp = empRep.getOne(id);
            return View(emp);
        }

        [HttpPost]
        public ActionResult UpdateEmpresas(Empresas emp)
        {

            empRep.Update(emp);
            return RedirectToAction("Empresas");
        }
    }
}
