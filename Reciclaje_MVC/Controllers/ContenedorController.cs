using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reciclaje_MVC.Controllers
{
    public class ContenedorController : Controller
    {
        // GET: ContenedorDistrito
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult asignarcomunacontenedor()
        {
            return View();
        }

        public ActionResult asignarcomuna()
        {
            return View();
        }
    }
}