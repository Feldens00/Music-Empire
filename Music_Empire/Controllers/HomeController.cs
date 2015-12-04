using Music_Empire.Models;
using System.Web.Mvc;

namespace Music_Empire.Controllers
{
    public class HomeController : Controller
    {

        EmpresasRepositorys empRep = new EmpresasRepositorys();
        // GET: Home
        public ActionResult Index()
        {
            var empresas = empRep.getAll();
            return View(empresas);
        }
    }
}