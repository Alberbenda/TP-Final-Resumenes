using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_FInal_Resumenes.Models;

namespace TP_FInal_Resumenes.Controllers
{
    public class BackofficeController : Controller
    {
        // GET: Backoffice
        public ActionResult Index()
        {

            ViewBag.lista = BD.TraerResumenesXPunt();
            return View();
        }
        public ActionResult EliminarRes()
        {
            ViewBag.lista = BD.TraerResumenesXPunt();
            return View("Index");
        }
    }
}