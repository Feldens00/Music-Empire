using Entidades.E;
using Repositorio.R;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Music_Empire.Controllers
{
    public class MusicosController : Controller
    {
        // GET: Musicos
        MusicoRepositorys musRep = new MusicoRepositorys();
        LocalRepositorys locRep2 = new LocalRepositorys();

        public static int ident;
        public static string usuariologado;
        public static bool logou;
        public ActionResult Musicos()
        {
            if (logou)
            {
                ident = (int)TempData.Peek("identificador");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            var mus = musRep.getAll();
            return View(mus);
        }

       

        public ActionResult Delete(int id)
        {
            musRep.Delete(id);
            return RedirectToAction("Musicos");
        }

        public ActionResult UpdateMusicos(int id)
        {
           

            List<Local> ListCidades = new List<Local>(locRep2.getAll());
            ViewBag.ListCidades = ListCidades;


            var mus = musRep.getOne(id);
            return View(mus);
        }

        [HttpPost]
        public ActionResult UpdateMusicos(Musico mus)
        {

            musRep.Update(mus);
            return RedirectToAction("Musicos");
        }
    }
}