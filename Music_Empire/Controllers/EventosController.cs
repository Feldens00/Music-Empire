using Entidades.E;
using Repositorio.R;
using System.Collections.Generic;
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
            var eve = eveRep.getAllEventos();
            
            return View(eve);
        }

        public ActionResult EventosMusicos()
        {
            var eve = eveRep.getAllMusico();

            return View(eve);
        }

        [HttpGet]
        public ActionResult AddMusico()
        {


            //List<Eventos> ListMusEvento = new List<Eventos>(eveRep.getAllMusico());
            //ViewBag.ListMusEvento = ListMusEvento;


            List<Musico> ListMusico = new List<Musico>(musRep.getAll());
            ViewBag.ListMusico = ListMusico;

            List<Eventos> ListEvento = new List<Eventos>(eveRep.getAllEventos());
            ViewBag.ListEvento = ListEvento;

            return View();

        }

        [HttpPost]
        public ActionResult AddMusico(Eventos evento)
        {


            if (ModelState.IsValid)
            {
                eveRep.addMusico(evento);
                return RedirectToAction("EventosMusicos");
            }

            return View();
        }

        public ActionResult EventosEmpresas()
        {
            var eve = eveRep.getAllEmpresa();

            return View(eve);
        }


        [HttpGet]
        public ActionResult AddEmpresa()
        {
            List<Empresas> ListEmpresa = new List<Empresas>(empRep.getAll());
            ViewBag.ListEmpresa = ListEmpresa;
            
            List<Eventos> ListEvento = new List<Eventos>(eveRep.getAllEventos());
            ViewBag.ListEvento = ListEvento;


            return View();

        }

        [HttpPost]
        public ActionResult AddEmpresa(Eventos evento)
        {


            if (ModelState.IsValid)
            {
                eveRep.addEmpresa(evento);
                return RedirectToAction("EventosEmpresas");
            }

            return View();
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
            

            IEnumerable<Empresas> ListEmpresa = empRep.getAll();
            ViewBag.ListEmpresa = ListEmpresa;

            IEnumerable<Local> ListEstado = locRep.getAll();
            ViewBag.ListEstado = ListEstado;

            IEnumerable<Musico> ListMusico = musRep.getAll();
            ViewBag.ListMusico = ListMusico;

            IEnumerable<Eventos> evs = eveRep.getAllEventos();

            return View(evs);
        }

        [HttpPost]
        public ActionResult CreateEventos(Eventos evento)
        {


           
            if (ModelState.IsValid)
            {
                eveRep.Create(evento);
                return RedirectToAction("Eventos");
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            eveRep.Delete(id);
            return RedirectToAction("Eventos");
        }
        public ActionResult DeleteEmpresas(int id)
        {
            eveRep.DeleteEmpresa(id);
            return RedirectToAction("EventosEmpresas");
        }
        public ActionResult DeleteMusicos(int id)
        {
            eveRep.DeleteMusico(id);
            return RedirectToAction("EventosMusicos");
        }


        public ActionResult Update(int id)
        {
           
            IEnumerable<Local> ListEstado = locRep.getAll();
            ViewBag.ListEstado = ListEstado;


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