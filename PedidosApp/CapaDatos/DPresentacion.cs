using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DPresentacion: DbConnection
    {
        //Campos y propiedades
        private int _Idpresentacion;
        private string _Nombre;
        private string _Descripcion;
        private string _TextoBuscar;
        //Refactorizar las variables
        public int Idpresentacion { get => _Idpresentacion; set => _Idpresentacion = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        //Costructores
        public DPresentacion()
        {

        }

        public DPresentacion(int idpresentacion, string nombre, string descripcion, string textoBuscar)
        {
            Idpresentacion = idpresentacion;
            Nombre = nombre;
            Descripcion = descripcion;
            TextoBuscar = textoBuscar;
        }

        //Metodo Insertar 
        public string Insertar(DPresentacion Presentacion)
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
                        command.CommandText = "spinsertar_presentacion";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdpresentacion = new SqlParameter();
                        ParIdpresentacion.ParameterName = "@idpresentacion";
                        ParIdpresentacion.SqlDbType = SqlDbType.Int;
                        ParIdpresentacion.Direction = ParameterDirection.Output;
                        command.Parameters.Add(ParIdpresentacion);

                        SqlParameter ParNombre = new SqlParameter();
                        ParNombre.ParameterName = "@nombre";
                        ParNombre.SqlDbType = SqlDbType.VarChar;
                        ParNombre.Size = 50;
                        ParNombre.Value = Presentacion.Nombre;
                        //ParNombre.Direction = ParameterDirection.Output;
                        command.Parameters.Add(ParNombre);

                        SqlParameter ParDescripcion = new SqlParameter();
                        ParDescripcion.ParameterName = "@descripcion";
                        ParDescripcion.SqlDbType = SqlDbType.VarChar;
                        ParDescripcion.Size = 256;
                        ParDescripcion.Value = Presentacion.Descripcion;
                        //ParDescripcion.Direction = ParameterDirection.Output;
                        command.Parameters.Add(ParDescripcion);

                        //Ejecutamos el comando
                        rpta = command.ExecuteNonQuery() == 1 ? "OK" : "NO SE INGRESO EL REGISTRO";


                    }
                    catch (Exception ex)
                    {

                        rpta = ex.Message;
                    }
                    finally { 
                        if (connection.State == ConnectionState.Open)
                        { 
                            connection.Close(); 
                        }
                    }

                }

            }
            return rpta;
        }
        //Metodo Editar
        public string Editar(DPresentacion Presentacion)
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
                        command.CommandText = "speditar_presentacion";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdpresentacion = new SqlParameter();
                        ParIdpresentacion.ParameterName = "@idpresentacion";
                        ParIdpresentacion.SqlDbType = SqlDbType.Int;
                        ParIdpresentacion.Value = Presentacion.Idpresentacion;
                        command.Parameters.Add(ParIdpresentacion);

                        SqlParameter ParNombre = new SqlParameter();
                        ParNombre.ParameterName = "@nombre";
                        ParNombre.SqlDbType = SqlDbType.VarChar;
                        ParNombre.Size = 50;
                        ParNombre.Value = Presentacion.Nombre;
                        //ParNombre.Direction = ParameterDirection.Output;
                        command.Parameters.Add(ParNombre);

                        SqlParameter ParDescripcion = new SqlParameter();
                        ParDescripcion.ParameterName = "@descripcion";
                        ParDescripcion.SqlDbType = SqlDbType.VarChar;
                        ParDescripcion.Size = 256;
                        ParDescripcion.Value = Presentacion.Descripcion;
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
        public string Eliminar(DPresentacion Presentacion)
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
                        command.CommandText = "speliminar_presentacion";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdpresentacion = new SqlParameter();
                        ParIdpresentacion.ParameterName = "@idpresentacion";
                        ParIdpresentacion.SqlDbType = SqlDbType.Int;
                        ParIdpresentacion.Value = Presentacion.Idpresentacion;
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
            DataTable DtResultado = new DataTable("presentacion");
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "spmostrar_presentacion";
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
        public DataTable BuscarNombre(DPresentacion Presentacion)
        {
            DataTable DtResultado = new DataTable("presentacion");
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "spbuscar_presentacion_nombre";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParTextoBuscar = new SqlParameter();
                        ParTextoBuscar.ParameterName = "@textobuscar";
                        ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                        ParTextoBuscar.Size = 50;
                        ParTextoBuscar.Value = Presentacion.TextoBuscar;
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
