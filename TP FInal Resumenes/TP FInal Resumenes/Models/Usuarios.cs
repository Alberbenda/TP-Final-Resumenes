﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TP_FInal_Resumenes.Models
{
    public class Usuarios
    {
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "Ingrese un Username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Ingrese una contraseña")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "La contraseña debe tener entre 6 y 15 caracteres")]
        public string Contrasena { get; set; }
        [Compare("Contrasena",ErrorMessage ="Las contraseñas no coinciden, por favor ingreselas de vuelta")]
        public string Contra2{get; set;}
        [Required(ErrorMessage = "Ingrese su Nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Ingrese su Apellido")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Ingrese un mail")]
        public string Mail { get; set; }
        public bool Admin { get; set; }

        public Usuarios()
        {
            IdUsuario = -1;
            Username = "";
            Contrasena = "";
            Nombre = "";
            Apellido = "";
            Mail = "";
            Admin = false;
        }
        public Usuarios(int id, string user,string contra,string nom, string ape, string mail, bool ad)
        {
            IdUsuario = id;
            Username = user;
            Contrasena = contra;
            Nombre = nom;
            Apellido = ape;
            Mail = mail;
            Admin = ad;
        }

    }
}