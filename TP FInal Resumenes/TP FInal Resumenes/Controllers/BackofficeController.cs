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

        public ActionResult ValidarLoginUsuario(Usuarios usuario)
        {
            string username = usuario.Username;
            string pass = usuario.Contrasena;
            if (ModelState.IsValid)
            {
                Usuarios usu = BD.ValidarLoginUsuario(username, pass);
                if (usu.IdUsuario != -1)
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
        public ActionResult Loguearse()
        {
            return View("Login");
        }
        public ActionResult CrearCuenta()
        {
            return View("CrearCuenta");
        }
    }
}