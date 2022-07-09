using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using MigracionDAL.Models;

namespace MigracionDAL
{
    public class Datos
    {
        //Se crea una variable de tipo MySqlConnection
        MySqlConnection conexion;
        //Se crea una variable de tipo SqlConnecion
        SqlConnection SqlConnec;
        //Cadena de conexion
        private string CadConMySql;
        private string CadConSqlServer;

        //Método para invocar la cadena de conexión
        public Datos()
        {
            CadConMySql = ConfigurationManager.ConnectionStrings["covid"].ConnectionString;
            CadConSqlServer = ConfigurationManager.ConnectionStrings["seguiCovid"].ConnectionString;
        }

        //SE PROBÓ AMBAS CADENAS DE CONEXIÓN TANTO MYSQL COMO SQLServer
        //Método para establecer la prueba de cadena de conexion con MySql
        public string RevisarConexionMysql()
        {
            try
            {
                conexion = new MySqlConnection(CadConMySql);
                conexion.Open();
                conexion.Close();
            }
            catch(Exception e)
            {
                return "SALIO MAL, PESIMO CONTIGO ANDREI DEBERAS " + e.Message;
            }
            return "La conexión se abrió y se cerró sin problemas con MySql";
        }//Fin del método

        //Método para establecer la prueba de cadena de conexion con SQLServer
        public string RevisaConexionSqlServer()
        {
            try
            {
                SqlConnec = new SqlConnection(CadConSqlServer);
                SqlConnec.Open();
                SqlConnec.Close();
            }
            catch(Exception e)
            {
                return "SALIO MAL, PESIMO CONTIGO ANDREI DEBERAS " + e.Message;
            }
            return "La conexión se abrió y se cerró sin problemas con SqlServer";
        }//Fin del método

        //Prueba de consulta
        public DataTable consultarEmpleado()
        {
            DataTable tabla = null;
            DataSet container = new DataSet();
            using (MySqlConnection Con = new MySqlConnection(CadConMySql))
            {
                using (MySqlCommand Com = new MySqlCommand())
                {
                    Com.Connection = Con;
                    Com.CommandText = "select docente.id AS 'ID_Profe', empleados.id AS 'RegistroEmpleado', nombre AS 'Nombre', apaterno AS 'Ap_pat', amaterno AS 'Ap_Mat', if(empleados.sexo = 1, 'Femenino', 'Masculino') AS 'Genero', puesto AS 'Categoria', correo AS 'Correo', telefono AS 'Celular', estadoCivil AS 'F_EdoCivil'" +
                        "from empleados INNER JOIN docente on (empleados.id = docente.nempleado);";
                    MySqlDataAdapter DA = new MySqlDataAdapter(Com);
                    DA.Fill(container);
                    tabla = container.Tables[0];
                }
            }
            return (tabla);
        }

        public void migracionSQL() 
        {
            using (MySqlConnection Con = new MySqlConnection(CadConMySql))
            {
                Con.Open();
                using (MySqlCommand Com = new MySqlCommand())
                {
                    Com.Connection = Con;
                    //Com.CommandText = "select docente.id AS ID_Profe, empleados.id AS RegistroEmpleado, nombre AS Nombre, apaterno AS Ap_pat, amaterno AS Ap_Mat, if(empleados.sexo = 1, 'Femenino', 'Masculino') AS Genero, puesto AS Categoria, correo AS Correo, telefono AS Celular, estadoCivil AS F_EdoCivil from empleados INNER JOIN docente on (empleados.id = docente.nempleado);";
                    Com.CommandText = "select docente.id AS 'ID_Profe', empleados.id AS 'RegistroEmpleado', empleados.nombre AS 'Nombre', empleados.apaterno AS 'Ap_pat', empleados.amaterno AS 'Ap_Mat', if(empleados.sexo = 1, 'Femenino', 'Masculino') AS 'Genero', docente.puesto AS 'Categoria', empleados.correo AS 'Correo', empleados.telefono AS 'Celular', empleados.estadoCivil AS 'F_EdoCivil'" +
                        "from empleados INNER JOIN docente on (empleados.id = docente.nempleado);";
                    MySqlDataReader lect = Com.ExecuteReader();
                    if (lect.HasRows)
                    {
                        while (lect.Read())
                        {
                            string insertar = @"SET IDENTITY_INSERT Profesor ON; insert into Profesor(ID_Profe, RegistroEmpleado, Nombre, Ap_pat, Ap_Mat, Genero, Categoria, Correo, Celular, F_EdoCivil) values('" + lect["ID_Profe"] + "', '" + lect["RegistroEmpleado"] + "', '" + lect["Nombre"] + "', '" + lect["Ap_pat"] + "', '" + lect["Ap_Mat"] + "', '" + lect["Genero"] + "', '" + lect["Categoria"] + "', '" + lect["Correo"] + "', '" + lect["Celular"] + "', '" + lect["F_EdoCivil"] + "');";
                            InsertSqlServer(insertar);
                        }
                    }
                }
                Con.Close();
            }
        }

        public void InsertSqlServer(string consulta)
        {
            using (SqlConnection Con = new SqlConnection(CadConSqlServer))
            {
                Con.Open();
                using (SqlCommand Com = new SqlCommand())
                {
                    Com.Connection = Con;
                    Com.CommandText = consulta;
                    Com.ExecuteNonQuery();
                }
                Con.Close();
            }
        }

        
    }//Fin de la clase
}
