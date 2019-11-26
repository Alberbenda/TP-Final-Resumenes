using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_FInal_Resumenes.Models;

namespace TP_FInal_Resumenes.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "page";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult ValidarLoginUsuario(Login usuario)
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
        [HttpPost]
        public ActionResult ValidarCrearUsuario(Usuarios user)
        {
            if (ModelState.IsValid)// falta completar la clase BD cdo este hecha la home
            {
                BD.InsertarUsuario(user);
                    return View("Login");
            }
            else
            {
                return View("CrearCuenta");
            }

        }
        public ActionResult InserRes()
        {
            List<int> años = new List<int>();
            años.Add(1);
            años.Add(2);
            años.Add(3);
            años.Add(4);
            años.Add(5);
            ViewBag.ListaAños = años;
            ViewBag.ListaMaterias = BD.TraerMateria();
            ViewBag.ListaEscuelas = BD.TraerEscuelas();
            return View("InsertarResumen");
        }
        [HttpPost]
        public ActionResult InsertarResumen (Resumenes resu)
        {



            return View("Index");
        }

    }

}