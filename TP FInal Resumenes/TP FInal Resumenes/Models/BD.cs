using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace TP_FInal_Resumenes.Models
{
    public static class BD
    {
        public static SqlConnection SQL = new SqlConnection("Server=.;Database=Resumamos;Trusted_Connection=True;");
        public static SqlConnection Conectar()
        {
            SQL.Open();
            return SQL;
        }

        public static SqlConnection Desconectar()
        {
            SQL.Close();
            return SQL;
        }
        public static bool ValidarLoginUsuario (Usuarios us)
        {
            bool valido = false;
            // falta completar cuando este hecha la home



            return valido;
        }
    }
}