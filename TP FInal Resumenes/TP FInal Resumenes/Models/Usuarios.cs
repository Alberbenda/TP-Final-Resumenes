using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_FInal_Resumenes.Models
{
    public class Usuarios
    {
        public int IdUsuario { get; set; }
        public string Username { get; set; }
        public string Contrasena { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }

        public Usuarios()
        {
            IdUsuario = -1;
            Username = "";
            Contrasena = "";
            Nombre = "";
            Apellido = "";
            Mail = "";
        }
        public Usuarios(int id, string user,string contra,string nom, string ape, string mail)
        {
            IdUsuario = id;
            Username = user;
            Contrasena = contra;
            Nombre = nom;
            Apellido = ape;
            Mail = mail;
        }

    }
}