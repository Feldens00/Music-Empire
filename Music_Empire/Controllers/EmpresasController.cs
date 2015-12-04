using FinancasConnections;
using Music_Empire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Music_Empire.Controllers
{
    public class EmpresasController : Controller
    {
        DataBase database = new DataBase();
        EmpresasRepositorys empRep = new EmpresasRepositorys();

        LocalRepositorys locRep = new LocalRepositorys();
            LocalRepositorys locRep2 = new LocalRepositorys();
        // GET: Empresas
        public ActionResult Empresas()
        {
            var emp = empRep.getAll();
            return View(emp);
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
            List<Local> ListEstado = new List<Local>(locRep.getAll());
            ViewBag.ListEstado = ListEstado;

            

            if (ModelState.IsValid)
            {
                empRep.Create(emp);
                return RedirectToAction("Empresas");
            }
            return View();
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
