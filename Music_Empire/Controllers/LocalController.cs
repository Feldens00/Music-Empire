using FinancasConnections;
using Music_Empire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Music_Empire.Controllers
{
    public class LocalController : Controller
    {
        DataBase database = new DataBase();
        LocalRepositorys locRep = new LocalRepositorys();
       
        public ActionResult Local()
        {
            var loc = locRep.getAll();
            return View(loc);
        }

        [HttpGet]
        public ActionResult CreateLocal()
        {
           
            
            return View();
        }

        [HttpPost]
        public ActionResult CreateLocal(Local local)
        {
            
          
            
                locRep.Create(local);
                return RedirectToAction("Local");
            
            
               
        }

        public ActionResult Delete(int id)
        {
            locRep.Delete(id);
            return RedirectToAction("Local");
        }

        public ActionResult UpdateLocal(int id)
        {
            
        

            var loc = locRep.getOne(id);
            return View(loc);
        }

        [HttpPost]
        public ActionResult UpdateLocal(Local local)
        {

            locRep.Update(local);
            return RedirectToAction("Local");
        }
    }
}