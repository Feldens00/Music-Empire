using Music_Empire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Music_Empire.Controllers
{
    public class EventosController : Controller
    {
        // GET: Eventos
        EventoRepository eveRep = new EventoRepository();
        EmpresasRepositorys empRep = new EmpresasRepositorys();
        LocalRepositorys locRep = new LocalRepositorys();
        MusicoRepositorys musRep = new MusicoRepositorys();

        public ActionResult Eventos()
        {
            var eve = eveRep.getAll();
            return View(eve);
        }
       
        //private SelectList ListEmpresa()
        //{
        //    var lista = empRep.getAll();
        //    return new SelectList(lista, "idEmpresa", "nomeEmpresa");
        //}
        [HttpGet]
        public ActionResult CreateEventos()
        {
            //ViewBag.ListEmpresa = ListEmpresa();
            

            List<Empresas> ListEmpresa = new List<Empresas>(empRep.getAll());
            ViewBag.ListEmpresa = ListEmpresa;

            List<Local> ListEstado = new List<Local>(locRep.getAll());
            ViewBag.ListEstado = ListEstado;


            return View();
        }

        [HttpPost]
        public ActionResult CreateEventos(Eventos evento)
        {


            //Eventos eve = new Eventos();
            //eve.dataEvento = form["dataEvento"];
            //eve.nomeEvento = form["nomeEvento"];
            //eve.enderecoEvento = form["enderecoEvento"];
            //eve.localEvento.idLocal = int.Parse(form["localEvento.idLocal"]);
            //eve.arrayEmpresa = ViewBag.ListEmpresa;

            //var evento = eve;

            //var evento = new Eventos
            ////{

            //    dataEvento = form["dataEvento"],
            //    nomeEvento = form["nomeEvento"],
            //    enderecoEvento = form["enderecoEvento"],
            //    localEvento = new Local
            //    {
            //        idLocal = int.Parse(form["idLocal"])

            //    },
            //    arrayEmpresa = ViewBag.ListEmpresa


            //};
            if (ModelState.IsValid)
            {
                eveRep.Create(evento);
                return RedirectToAction("Eventos");
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            empRep.Delete(id);
            return RedirectToAction("Eventos");
        }

        public ActionResult Update(int id)
        {
            List<Local> ListEstado = new List<Local>(locRep.getAll());
            ViewBag.ListEstado = ListEstado;
            

            List<Local> ListEmpresa = new List<Local>(locRep.getAll());
            ViewBag.ListEmpresa = ListEmpresa;


            var eve = eveRep.getOne(id);
            return View(eve);
        }

        [HttpPost]
        public ActionResult Update(Eventos eve)
        {

            eveRep.Update(eve);
            return RedirectToAction("Eventos");
        }
    }
}