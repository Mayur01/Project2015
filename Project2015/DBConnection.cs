using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Project2015
{
    class DBConnection
    {
        /*
         * @param string s - takes the name of the server to connect to
         * @param string d - takes the name of the database to use
         *
         * @return SqlConnection conn - A connection object to the database
         */
        public static SqlConnection getConn(string s, string d)
        {
            SqlConnection conn = new SqlConnection("server="+s+"; initial catalog="+d+ "; integrated security=true");
            conn.Open();
            return conn;
        }
    }
}
