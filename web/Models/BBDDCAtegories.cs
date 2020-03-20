using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models.BBDD
{
    public class BBDDCAtegories
    {


        SqlCommand comand;
        String query;
        DataTable dt;
        SqlDataAdapter da;



        public BBDDCAtegories() { }

        public  DataTable getCategories(String query, SqlConnection conexion)
        {
            dt = new DataTable();
            comand = new SqlCommand(query, conexion);
            da = new SqlDataAdapter(comand);
            da.Fill(dt);

            return dt;
        }
    }
}
