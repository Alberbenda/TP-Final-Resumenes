using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace TP_FInal_Resumenes.Models
{
    public static class BD
    {
        public static SqlConnection SQL = new SqlConnection("Server=.;Database=Resumamos;user id= alumno;password= alumno;");
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
        public static Usuarios ValidarLoginUsuario(string Username, string Pass)
        {
            Usuarios user = new Usuarios();

            // Busco en la base de datos si existe un usuario con ese username y password
            //Si lo encuentra (Read = true) llenas el objeto user con lo que encontro.
            // devuelvo user

            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM Usuarios WHERE Username ='" + Username +"' and Contrasena = '" + Pass+"'"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read() == true)
            {
                user.IdUsuario= Convert.ToInt32(dataReader["IdUsuario"]);
                user.Username=dataReader["Username"].ToString();
                user.Contrasena = dataReader["Contrasena"].ToString();
                user.Nombre = dataReader["Nombre"].ToString();
                user.Apellido = dataReader["Apellido"].ToString();
                user.Mail= dataReader["Mail"].ToString();
                user.Admin = Convert.ToBoolean(dataReader["Admin"]);
            }
            dataReader.Close();
            Desconectar();
            return user;
        }
        public static List<Resumenes> TraerResumenes (int idRes)//Cuando es -1 trae todo, sino trae esa
        {

          List<Resumenes> ListaDeResumenes = new List<Resumenes>();

            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            if (idRes!= -1)
            {
                command.CommandText = "SELECT* FROM Resumenes where IdResumen =" + idRes ; //Consulta
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
            command.CommandText = "INSERT into Resumenes(Nombre, FkMateria ,FkUsuario,Puntuacion,Anio,Archivo,FkEscuela ) values ('" + res.Nombre + "'," + res.FkMateria + "," + res.FkUsuario + "," + res.Puntuacion + "," + res.Ano + ",'"+res.Archivo+"',"+res.FkEscuela+")"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            Desconectar();
        }

        public static void InsertarUsuario(Usuarios usu)
        {
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "INSERT into Usuarios (Username, Contrasena , Nombre , Apellido ,Mail,Admin) values ('" + usu.Username + "','" + usu.Contrasena + "','" + usu.Nombre + "','" + usu.Apellido + "','" + usu.Mail + "',0)"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            Desconectar();
        }
        public static void ModificarResumen (Resumenes resu)
        {
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "UPDATE Resumenes SET Nombre = '" + resu.Nombre + "', FkMateria =" + resu.FkMateria + ", FkUsuario = " + resu.FkUsuario + ", Puntuacion = " + resu.Puntuacion + "' WHERE IdResumen = " + resu.IdResumen; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            Desconectar();
        }
        public static List<Escuela> TraerEscuelas()
        {

            List<Escuela> ListaDeEscuela = new List<Escuela>();

            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT* FROM Escuelas"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                int idesc = Convert.ToInt32(dataReader["IdEscuela"]);
                string Nom = dataReader["NombreEscuela"].ToString();
                Escuela escu = new Escuela (idesc, Nom);
                ListaDeEscuela.Add(escu);
            }
            dataReader.Close();
            Desconectar();

            return ListaDeEscuela;
        }
        public static List<Materia> TraerMateria()
        {

            List<Materia> ListaDeMaterias = new List<Materia>();

            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT* FROM Materias"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                int idmate = Convert.ToInt32(dataReader["IdMateria"]);
                string NomMa = dataReader["NombreMateria"].ToString();
                Materia mat = new Materia(idmate, NomMa);
                ListaDeMaterias.Add(mat);
            }
            dataReader.Close();
            Desconectar();

            return ListaDeMaterias;
        }
        public static List<Resumenes> TraerResumenesXAno(int Ano)//Cuando es -1 trae todo, sino trae esa
        {

            List<Resumenes> ListaDeResumenes = new List<Resumenes>();

            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT* FROM Resumenes where Anio = " + Ano ; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {

                int idres = Convert.ToInt32(dataReader["IdResumen"]);
                string Nom = dataReader["Nombre"].ToString();
                int fkMat = Convert.ToInt32(dataReader["FkMateria"]);
                int fkUsu = Convert.ToInt32(dataReader["FkUsuario"]);
                double punt = Convert.ToDouble(dataReader["Puntuacion"]);
                int ano = Convert.ToInt32(dataReader["Anio"]);
                string ft = dataReader["Foto"].ToString();
                int fkesc = Convert.ToInt32(dataReader["FkEscuela"]);
                Resumenes resu = new Resumenes(idres, Nom, fkMat, fkUsu, punt, ano, ft, fkesc);
                ListaDeResumenes.Add(resu);
            }
            dataReader.Close();
            Desconectar();

            return ListaDeResumenes;
        }
        public static List<Resumenes> TraerResumenesXMat(int Mat)//Cuando es -1 trae todo, sino trae esa
        {

            List<Resumenes> ListaDeResumenes = new List<Resumenes>();

            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT* FROM Resumenes where FkMateria = " + Mat; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {

                int idres = Convert.ToInt32(dataReader["IdResumen"]);
                string Nom = dataReader["Nombre"].ToString();
                int fkMat = Convert.ToInt32(dataReader["FkMateria"]);
                int fkUsu = Convert.ToInt32(dataReader["FkUsuario"]);
                double punt = Convert.ToDouble(dataReader["Puntuacion"]);
                int ano = Convert.ToInt32(dataReader["Anio"]);
                string ft = dataReader["Foto"].ToString();
                int fkesc = Convert.ToInt32(dataReader["FkEscuela"]);
                Resumenes resu = new Resumenes(idres, Nom, fkMat, fkUsu, punt, ano, ft, fkesc);
                ListaDeResumenes.Add(resu);
            }
            dataReader.Close();
            Desconectar();

            return ListaDeResumenes;
        }
        public static List<Resumenes> TraerResumenesXEsc(int Esc)//Cuando es -1 trae todo, sino trae esa
        {

            List<Resumenes> ListaDeResumenes = new List<Resumenes>();

            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT* FROM Resumenes where FkEscuela = " + Esc; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {

                int idres = Convert.ToInt32(dataReader["IdResumen"]);
                string Nom = dataReader["Nombre"].ToString();
                int fkMat = Convert.ToInt32(dataReader["FkMateria"]);
                int fkUsu = Convert.ToInt32(dataReader["FkUsuario"]);
                double punt = Convert.ToDouble(dataReader["Puntuacion"]);
                int ano = Convert.ToInt32(dataReader["Anio"]);
                string ft = dataReader["Foto"].ToString();
                int fkesc = Convert.ToInt32(dataReader["FkEscuela"]);
                Resumenes resu = new Resumenes(idres, Nom, fkMat, fkUsu, punt, ano, ft, fkesc);
                ListaDeResumenes.Add(resu);
            }
            dataReader.Close();
            Desconectar();
            return ListaDeResumenes;
        }
    }
}