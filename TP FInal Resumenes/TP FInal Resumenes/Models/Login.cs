using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TP_FInal_Resumenes.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Ingrese un Username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Ingrese una contraseña")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "La contraseña debe tener entre 6 y 15 caracteres")]
        public string Contrasena { get; set; }
    }
}