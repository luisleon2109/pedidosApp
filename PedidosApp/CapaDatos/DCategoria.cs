using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DCategoria:DbConnection
    {
        //Campos y propiedades
        private int _Idcategoria;
        private string _Nombre;
        private string _Descripcion;
        private string _TextoBuscar;
        //Refactorizar las variables
        public int Idcategoria { get => _Idcategoria; set => _Idcategoria = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        //Costructores
        public DCategoria()
        {

        }

        public DCategoria(int idcategoria, string nombre, string descripcion, string textoBuscar)
        {
            Idcategoria = idcategoria;
            Nombre = nombre;
            Descripcion = descripcion;
            TextoBuscar = textoBuscar;
        }

        //Metodo Insertar 
        public string Insertar(DCategoria Categoria)
        {
            string rpta = string.Empty;
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "spinsertar_categoria";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdcategoria = new SqlParameter();
                        ParIdcategoria.ParameterName = "@idcategoria";
                        ParIdcategoria.SqlDbType = SqlDbType.Int;
                        ParIdcategoria.Direction = ParameterDirection.Output;
                        command.Parameters.Add(ParIdcategoria);

                        SqlParameter ParNombre = new SqlParameter();
                        ParNombre.ParameterName = "@nombre";
                        ParNombre.SqlDbType = SqlDbType.VarChar;
                        ParNombre.Size = 50;
                        ParNombre.Value = Categoria.Nombre;
                        //ParNombre.Direction = ParameterDirection.Output;
                        command.Parameters.Add(ParNombre);

                        SqlParameter ParDescripcion = new SqlParameter();
                        ParDescripcion.ParameterName = "@descripcion";
                        ParDescripcion.SqlDbType = SqlDbType.VarChar;
                        ParDescripcion.Size = 256;
                        ParDescripcion.Value = Categoria.Descripcion;
                        //ParDescripcion.Direction = ParameterDirection.Output;
                        command.Parameters.Add(ParDescripcion);

                        //Ejecutamos el comando
                        rpta = command.ExecuteNonQuery() == 1 ? "OK" : "NO SE INGRESO EL REGISTRO";


                    }
                    catch (Exception ex)
                    {

                        rpta = ex.Message;
                    }
                    finally { if (connection.State == ConnectionState.Open) connection.Close(); }

                }

            }
            return rpta;
        }
        //Metodo Editar
        public string Editar(DCategoria Categoria)
        {
            string rpta = string.Empty;
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "speditar_categoria";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdpresentacion = new SqlParameter();
                        ParIdpresentacion.ParameterName = "@idcategoria";
                        ParIdpresentacion.SqlDbType = SqlDbType.Int;
                        ParIdpresentacion.Value = Categoria.Idcategoria;
                        command.Parameters.Add(ParIdpresentacion);

                        SqlParameter ParNombre = new SqlParameter();
                        ParNombre.ParameterName = "@nombre";
                        ParNombre.SqlDbType = SqlDbType.VarChar;
                        ParNombre.Size = 50;
                        ParNombre.Value = Categoria.Nombre;
                        //ParNombre.Direction = ParameterDirection.Output;
                        command.Parameters.Add(ParNombre);

                        SqlParameter ParDescripcion = new SqlParameter();
                        ParDescripcion.ParameterName = "@descripcion";
                        ParDescripcion.SqlDbType = SqlDbType.VarChar;
                        ParDescripcion.Size = 256;
                        ParDescripcion.Value = Categoria.Descripcion;
                        //ParDescripcion.Direction = ParameterDirection.Output;
                        command.Parameters.Add(ParDescripcion);
                        //Ejecutamos el comando
                        rpta = command.ExecuteNonQuery() == 1 ? "OK" : "NO SE ACTUALIZO EL REGISTRO";


                    }
                    catch (Exception ex)
                    {

                        rpta = ex.Message;
                    }
                    finally { if (connection.State == ConnectionState.Open) connection.Close(); }

                }

            }
            return rpta;
        }
        //Metodo Eliminar
        public string Eliminar(DCategoria Categoria)
        {
            string rpta = string.Empty;
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "speliminar_categoria";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdpresentacion = new SqlParameter();
                        ParIdpresentacion.ParameterName = "@idcategoria";
                        ParIdpresentacion.SqlDbType = SqlDbType.Int;
                        ParIdpresentacion.Value = Categoria.Idcategoria;
                        command.Parameters.Add(ParIdpresentacion);

                        //Ejecutamos el comando
                        rpta = command.ExecuteNonQuery() == 1 ? "OK" : "NO SE ELIMINO EL REGISTRO";


                    }
                    catch (Exception ex)
                    {

                        rpta = ex.Message;
                    }
                    finally { if (connection.State == ConnectionState.Open) connection.Close(); }

                }

            }
            return rpta;
        }
        //Metodo Mostrar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("Categoria");
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "spmostrar_categoria";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter SqlDat = new SqlDataAdapter(command);
                        SqlDat.Fill(DtResultado);
                    }
                    catch (Exception)
                    {
                        DtResultado = null;
                    }

                }

            }
            return DtResultado;
        }
        //Metodo BuscarNombre
        public DataTable BuscarNombre(DCategoria Categoria)
        {
            DataTable DtResultado = new DataTable("categoria");
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "spbuscar_categoria";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParTextoBuscar = new SqlParameter();
                        ParTextoBuscar.ParameterName = "@textobuscar";
                        ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                        ParTextoBuscar.Size = 50;
                        ParTextoBuscar.Value = Categoria.TextoBuscar;
                        command.Parameters.Add(ParTextoBuscar);

                        SqlDataAdapter SqlDat = new SqlDataAdapter(command);
                        SqlDat.Fill(DtResultado);
                    }
                    catch (Exception)
                    {
                        DtResultado = null;
                    }

                }

            }
            return DtResultado;
        }
    }
}
