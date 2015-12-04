using Music_Empire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Music_Empire.Controllers
{
    public class MusicosController : Controller
    {
        // GET: Musicos
        MusicoRepositorys musRep = new MusicoRepositorys();
        LocalRepositorys locRep = new LocalRepositorys();
        LocalRepositorys locRep2 = new LocalRepositorys();

        public ActionResult Musicos()
        {
            var mus = musRep.getAll();
            return View(mus);
        }

        [HttpGet]
        public ActionResult CreateMusicos()
        {

            List<Local> ListEstado = new List<Local>(locRep.getAll());
            ViewBag.ListEstado = ListEstado;

            List<Local> ListCidades = new List<Local>(locRep2.getAll());
            ViewBag.ListCidades = ListCidades;


            return View();
        }

        [HttpPost]
        public ActionResult CreateMusicos(Musico mus)
        {
            //List<Local> ListEstado = new List<Local>(locRep.getAll());
            //ViewBag.ListEstado = ListEstado;

            //List<Local> ListCidades = new List<Local>(locRep2.getAll());
            //ViewBag.ListCidades = ListCidades;

            if (ModelState.IsValid)
            {
                musRep.Create(mus);
                return RedirectToAction("Musicos");
            }
            return View();

        }

        public ActionResult Delete(int id)
        {
            musRep.Delete(id);
            return RedirectToAction("Musicos");
        }

        public ActionResult UpdateMusicos(int id)
        {
            List<Local> ListEstado = new List<Local>(locRep.getAll());
            ViewBag.ListEstado = ListEstado;

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