using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace TP_FInal_Resumenes.Models
{
    public class Resumenes
    {
        public int IdResumen { get; set; }
        public string Nombre { get; set; }
        public int FkMateria { get; set; }
        public int FkUsuario { get; set; }
        public float Puntuacion { get; set; }
        public int Ano { get; set; }
        public System.Web.HttpPostedFileBase Imagen { get; set; }
        public string NombreImagen { get; set; }
        public int FkEscuela { get; set; }

        public Resumenes()
        {
            IdResumen = -1;
            Nombre = "";
            FkMateria = -1;
            FkUsuario = -1;
            Puntuacion = 0;
            Ano = 0;
            NombreImagen = "";
            FkEscuela = 0;
        }
    }
}