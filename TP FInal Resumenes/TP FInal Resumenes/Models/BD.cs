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
        public static List<Resumenes> TraerResumener(int idRes)//Cuando es -1 trae todo, sino trae esa
        {

          List<Resumenes> ListaDeResumenes = new List<Resumenes>();

            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            if (idRes!= -1)
            {
                command.CommandText = "SELECT* FROM Resumenes where IdResumen ='" + idRes + "'"; //Consulta
            }
            else
            {
                command.CommandText = "SELECT* FROM Resumenes"; //Consulta
            }
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {

                int idres = Convert.ToInt32(dataReader["IdResumen"]);
                string Nom = dataReader["Nombre"].ToString();
                int fkMat = Convert.ToInt32(dataReader["FkMateria"]);
                int fkUsu = Convert.ToInt32(dataReader["FkUsuario"]);
                double punt = Convert.ToDouble(dataReader["Puntuacion"]);
                int ano = Convert.ToInt32(dataReader["Anio"]);
                string ft= dataReader["Foto"].ToString();
                int fkesc = Convert.ToInt32(dataReader["FkEscuela"]);
                Resumenes resu = new Resumenes(idres, Nom,fkMat , fkUsu, punt, ano,ft,fkesc);
                ListaDeResumenes.Add(resu);
            }
            dataReader.Close();
            Desconectar();

            return ListaDeResumenes;
        }
        public static void EliminarResumen(int id)
        {
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "DELETE FROM Resumenes WHERE IdResumen =" + id; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            Desconectar();
        }

        public static void InsertarResumen(Resumenes res)
        {
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "INSERT into Resumenes(Nombre, FkMateria ,FkUsuario,Puntuacion,Anio,Foto,FkEscuela ) values ('" + res.Nombre + "'," + res.FkMateria + "," + res.FkUsuario + "," + res.Puntuacion + "," + res.Ano + ",'"+res.Imagen+"',"+res.FkEscuela+")"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            Desconectar();
        }
    }
}