using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DLogin:DbConnection
    {
        private string _Usuario;
        private string _Password;

        public DLogin(string usuario, string password)
        {
            Usuario = usuario;
            Password = password;
        }
        public DLogin()
        {

        }

        public string Usuario { get => _Usuario; set => _Usuario = value; }
        public string Password { get => _Password; set => _Password = value; }

        public DataTable Ingresar(DLogin Login)
        {
            DataTable DtResultado = new DataTable("login");
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "splogin";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParUsuario = new SqlParameter();
                        ParUsuario.ParameterName = "@usuario";
                        ParUsuario.SqlDbType = SqlDbType.VarChar;
                        ParUsuario.Size = 50;
                        ParUsuario.Value = Login.Usuario;
                        command.Parameters.Add(ParUsuario);

                        SqlParameter ParPassword = new SqlParameter();
                        ParPassword.ParameterName = "@password";
                        ParPassword.SqlDbType = SqlDbType.VarChar;
                        ParPassword.Size = 100;
                        ParPassword.Value = Login.Password;
                        command.Parameters.Add(ParPassword);

                        SqlDataAdapter SqlDat = new SqlDataAdapter(command);
                        SqlDat.Fill(DtResultado);
                    }
                    catch (Exception ex)
                    {
                        DtResultado = null;
                    }
                }

            }
            return DtResultado;
        }
    }
}
