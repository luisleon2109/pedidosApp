using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CapaDatos
{
    public abstract class DbConnection
    {
        //public static string cn = "Server=(localdb)\\JOEL; DataBase=Dbventas; Integrated  Security=true";

        public static string cn = "Data source=(localdb)\\JOEL; initial catalog=Dbventas; integrated security=True";
        private readonly string connectionString;
        public DbConnection() 
        {
            connectionString = cn;
        }
        protected SqlConnection GetConnection() 
        {
            return new SqlConnection(connectionString);
        }
    }
}
