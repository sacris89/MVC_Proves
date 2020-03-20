using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models.BBDD
{
    public class Connection
    {

         static SqlConnection con;
        static  String cadenaConexion;

        static public SqlConnection conexion()
        {

            if (con == null) {          
                new Connection();
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                return con;
            }
            return con;

        }

        public static void SetCadenaConexion( String cadena)
        {
            cadenaConexion = cadena;
            con.ConnectionString = cadenaConexion;
        }
       public static void CerrarConexion() {
            if (con != null) {
                con.Close();
            }
        }
       public  Connection()
        {
            con = new SqlConnection();
            con.ConnectionString = "Data Source=localhost;Initial Catalog=Northwind;User ID=sa;Password=sa";
        }
    }
}
