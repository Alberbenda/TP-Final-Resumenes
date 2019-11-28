using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace TP_FInal_Resumenes.Models
{
    public class Resumenes
    {
        public int IdResumen { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int FkMateria { get; set; }
        public int FkUsuario { get; set; }
        public double Puntuacion { get; set; }
        [Required]
        [Range(0,6,ErrorMessage ="Ingrese un año entre 1 y 5")]
        public int Ano { get; set; }
        [Required]
        public HttpApplicationStateBase Archivo { get; set; }
        public string NombreImagen { get; set; }
        [Required]
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
        public Resumenes (int id, string nom, int fkmat, int fkua, double puntu, int ano, string nomimg,int fkesc)
        {
            IdResumen = id;
            Nombre = nom;
            FkMateria = fkmat;
            FkUsuario = fkua;
            Puntuacion = puntu;
            Ano = ano;
            NombreImagen = nomimg;
            FkEscuela = fkesc;
        }
    }
}