using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_FInal_Resumenes.Models
{
    public class Escuela
    {
        public int IdEscuela { get; set; }
        public string NombreEscuela { get; set; }

        public Escuela()
        {
            IdEscuela = -1;
            NombreEscuela = "";
        }
        public Escuela(int id,string nom)
        {
            IdEscuela = id;
            NombreEscuela = nom;
        }
    }
}