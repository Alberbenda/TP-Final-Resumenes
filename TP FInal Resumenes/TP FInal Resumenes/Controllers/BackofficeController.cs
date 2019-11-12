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
            return View();
        }
        public ActionResult ValidarLoginUsuario (Usuarios user)
        {
            if (ModelState.IsValid)// falta completar la clase BD cdo este hecha la home
            {
                bool valido = BD.ValidarLoginUsuario(user);
                if (valido == true)
                {
                    return View("Index");
                }
                else
                {
                    return View("Login");
                }
            }
            else
            {
                return View("Login");
            }
        }
    }
}