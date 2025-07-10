
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DTrabajador:DbConnection
    {
        //variables
        private int _Idtrabajador;
        private string _Nombre;
        private string _Apellidos;
        private string _Sexo;
        private DateTime _Fecha_Nac;
        private string _Num_Documento;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _Acceso;
        private string _Usuario;
        private string _Password;
        private string _TextoBuscar;


        public DTrabajador()
        {

        }
        public DTrabajador(int idtrabajador, string nombre,string apellidos, string sexo, 
            DateTime fecha_Nac, string num_Documento, string direccion, 
            string telefono, string email, string acceso, string usuario, 
            string password, string textoBuscar)
        {
            Idtrabajador = idtrabajador;
            Nombre = nombre;
            Apellidos = apellidos;
            Sexo = sexo;
            Fecha_Nac = fecha_Nac;
            Num_Documento = num_Documento;
            Direccion = direccion;
            Telefono = telefono;
            Email = email;
            Acceso = acceso;
            Usuario = usuario;
            Password = password;
            TextoBuscar = textoBuscar;
        }

        public int Idtrabajador { get => _Idtrabajador; set => _Idtrabajador = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Sexo { get => _Sexo; set => _Sexo = value; }
        public DateTime Fecha_Nac { get => _Fecha_Nac; set => _Fecha_Nac = value; }
        public string Num_Documento { get => _Num_Documento; set => _Num_Documento = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Acceso { get => _Acceso; set => _Acceso = value; }
        public string Usuario { get => _Usuario; set => _Usuario = value; }
        public string Password { get => _Password; set => _Password = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }



        public string Insertar(DTrabajador Trabajador)
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
                        command.CommandText = "spinsertar_trabajador";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdTrabajador = new SqlParameter();
                        ParIdTrabajador.ParameterName = "@idtrabajador";
                        ParIdTrabajador.SqlDbType = SqlDbType.Int;
                        ParIdTrabajador.Direction = ParameterDirection.Output;
                        command.Parameters.Add(ParIdTrabajador);

                        SqlParameter ParNombre = new SqlParameter();
                        ParNombre.ParameterName = "@nombre";
                        ParNombre.SqlDbType = SqlDbType.VarChar;
                        ParNombre.Size = 20;
                        ParNombre.Value = Trabajador.Nombre;
                        command.Parameters.Add(ParNombre);

                        SqlParameter ParApellido = new SqlParameter();
                        ParApellido.ParameterName = "@apellidos";
                        ParApellido.SqlDbType = SqlDbType.VarChar;
                        ParApellido.Size = 40;
                        ParApellido.Value = Trabajador.Apellidos;
                        command.Parameters.Add(ParApellido);

                        SqlParameter ParSexo = new SqlParameter();
                        ParSexo.ParameterName = "@sexo";
                        ParSexo.SqlDbType = SqlDbType.VarChar;
                        ParSexo.Size = 1;
                        ParSexo.Value = Trabajador.Sexo;
                        command.Parameters.Add(ParSexo);

                        SqlParameter ParaFecha_Nac = new SqlParameter();
                        ParaFecha_Nac.ParameterName = "@fecha_nac";
                        ParaFecha_Nac.SqlDbType = SqlDbType.Date;
                        ParaFecha_Nac.Size = 20;
                        ParaFecha_Nac.Value = Trabajador.Fecha_Nac;
                        command.Parameters.Add(ParaFecha_Nac);

                        SqlParameter ParNum_Documento = new SqlParameter();
                        ParNum_Documento.ParameterName = "@num_documento";
                        ParNum_Documento.SqlDbType = SqlDbType.VarChar;
                        ParNum_Documento.Size = 8;
                        ParNum_Documento.Value = Trabajador.Num_Documento;
                        command.Parameters.Add(ParNum_Documento);

                        SqlParameter ParDireccion = new SqlParameter();
                        ParDireccion.ParameterName = "@direccion";
                        ParDireccion.SqlDbType = SqlDbType.VarChar;
                        ParDireccion.Size = 100;
                        ParDireccion.Value = Trabajador.Direccion;
                        command.Parameters.Add(ParDireccion);

                        SqlParameter ParTelefono = new SqlParameter();
                        ParTelefono.ParameterName = "@telefono";
                        ParTelefono.SqlDbType = SqlDbType.VarChar;
                        ParTelefono.Size = 10;
                        ParTelefono.Value = Trabajador.Telefono;
                        command.Parameters.Add(ParTelefono);

                        SqlParameter ParEmail = new SqlParameter();
                        ParEmail.ParameterName = "@email";
                        ParEmail.SqlDbType = SqlDbType.VarChar;
                        ParEmail.Size = 50;
                        ParEmail.Value = Trabajador.Email;
                        command.Parameters.Add(ParEmail);

                        SqlParameter ParAcceso = new SqlParameter();
                        ParAcceso.ParameterName = "@acceso";
                        ParAcceso.SqlDbType = SqlDbType.VarChar;
                        ParAcceso.Size = 20;
                        ParAcceso.Value = Trabajador.Acceso;
                        command.Parameters.Add(ParAcceso);

                        SqlParameter ParUsuario = new SqlParameter();
                        ParUsuario.ParameterName = "usuario";
                        ParUsuario.SqlDbType = SqlDbType.VarChar;
                        ParUsuario.Size = 20;
                        ParUsuario.Value = Trabajador.Usuario;
                        command.Parameters.Add(ParUsuario);

                        SqlParameter ParPassword = new SqlParameter();
                        ParPassword.ParameterName = "@password";
                        ParPassword.SqlDbType = SqlDbType.VarChar;
                        ParPassword.Size = 20;
                        ParPassword.Value = Trabajador.Password;
                        command.Parameters.Add(ParPassword);


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

        //metodo editar
        public string Editar(DTrabajador Trabajador)
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
                        command.CommandText = "speditar_Trabajador";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdTrabajador = new SqlParameter();
                        ParIdTrabajador.ParameterName = "@idtrabajador";
                        ParIdTrabajador.SqlDbType = SqlDbType.Int;
                        //ParIdTrabajador.Direction = ParameterDirection.Output;
                        ParIdTrabajador.Value = Trabajador.Idtrabajador;
                        command.Parameters.Add(ParIdTrabajador);

                        SqlParameter ParNombre = new SqlParameter();
                        ParNombre.ParameterName = "@nombre";
                        ParNombre.SqlDbType = SqlDbType.VarChar;
                        ParNombre.Size = 20;
                        ParNombre.Value = Trabajador.Nombre;
                        command.Parameters.Add(ParNombre);

                        SqlParameter ParApellido = new SqlParameter();
                        ParApellido.ParameterName = "@apellidos";
                        ParApellido.SqlDbType = SqlDbType.VarChar;
                        ParApellido.Size = 40;
                        ParApellido.Value = Trabajador.Apellidos;
                        command.Parameters.Add(ParApellido);

                        SqlParameter ParSexo = new SqlParameter();
                        ParSexo.ParameterName = "@sexo";
                        ParSexo.SqlDbType = SqlDbType.Char;
                        ParSexo.Size = 1;
                        ParSexo.Value = Trabajador.Sexo;
                        command.Parameters.Add(ParSexo);

                        SqlParameter ParaFecha_Nac = new SqlParameter();
                        ParaFecha_Nac.ParameterName = "@fecha_nac";
                        ParaFecha_Nac.SqlDbType = SqlDbType.Date;
                        ParaFecha_Nac.Size = 20;
                        ParaFecha_Nac.Value = Trabajador.Fecha_Nac;
                        command.Parameters.Add(ParaFecha_Nac);

                        SqlParameter ParNum_Documento = new SqlParameter();
                        ParNum_Documento.ParameterName = "@num_documento";
                        ParNum_Documento.SqlDbType = SqlDbType.VarChar;
                        ParNum_Documento.Size = 8;
                        ParNum_Documento.Value = Trabajador.Num_Documento;
                        command.Parameters.Add(ParNum_Documento);

                        SqlParameter ParDireccion = new SqlParameter();
                        ParDireccion.ParameterName = "@direccion";
                        ParDireccion.SqlDbType = SqlDbType.VarChar;
                        ParDireccion.Size = 100;
                        ParDireccion.Value = Trabajador.Direccion;
                        command.Parameters.Add(ParDireccion);

                        SqlParameter ParTelefono = new SqlParameter();
                        ParTelefono.ParameterName = "@telefono";
                        ParTelefono.SqlDbType = SqlDbType.VarChar;
                        ParTelefono.Size = 10;
                        ParTelefono.Value = Trabajador.Telefono;
                        command.Parameters.Add(ParTelefono);

                        SqlParameter ParEmail = new SqlParameter();
                        ParEmail.ParameterName = "@email";
                        ParEmail.SqlDbType = SqlDbType.VarChar;
                        ParEmail.Size = 50;
                        ParEmail.Value = Trabajador.Email;
                        command.Parameters.Add(ParEmail);

                        SqlParameter ParAcceso = new SqlParameter();
                        ParAcceso.ParameterName = "@acceso";
                        ParAcceso.SqlDbType = SqlDbType.VarChar;
                        ParAcceso.Size = 20;
                        ParAcceso.Value = Trabajador.Acceso;
                        command.Parameters.Add(ParAcceso);

                        SqlParameter ParUsuario = new SqlParameter();
                        ParUsuario.ParameterName = "usuario";
                        ParUsuario.SqlDbType = SqlDbType.VarChar;
                        ParUsuario.Size = 20;
                        ParUsuario.Value = Trabajador.Usuario;
                        command.Parameters.Add(ParUsuario);

                        SqlParameter ParPassword = new SqlParameter();
                        ParPassword.ParameterName = "@password";
                        ParPassword.SqlDbType = SqlDbType.VarChar;
                        ParPassword.Size = 20;
                        ParPassword.Value = Trabajador.Password;
                        command.Parameters.Add(ParPassword);
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

        // mostrar trabajador
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("trabajador");
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "spmostrar_trabajador";
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

        //eliminar
        public string Eliminar(DTrabajador Trabajador)
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
                        command.CommandText = "speliminar_Trabajador";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdTrabajador = new SqlParameter();
                        ParIdTrabajador.ParameterName = "@idTrabajador";
                        ParIdTrabajador.SqlDbType = SqlDbType.Int;
                        ParIdTrabajador.Value = Trabajador.Idtrabajador;
                        command.Parameters.Add(ParIdTrabajador);

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

        // Método BuscarNumDocumento
        public DataTable BuscarNum_Documento(string textoBuscar)
        {
            DataTable dtResultado = new DataTable("trabajador");
            using (SqlConnection connection = GetConnection())
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "spbuscar_Trabajador_num_documento";
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParTextoBuscar = new SqlParameter();
                    ParTextoBuscar.ParameterName = "@textobuscar";
                    ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                    ParTextoBuscar.Size = 50;
                    ParTextoBuscar.Value = textoBuscar;
                    command.Parameters.Add(ParTextoBuscar);

                    SqlDataAdapter sqlDat = new SqlDataAdapter(command);
                    sqlDat.Fill(dtResultado);
                }
                catch (Exception ex)
                {
                    dtResultado = null;
                }
            }
            return dtResultado;
        }

        //buscar trabajador por apellidos
        public DataTable Buscartrabajador_apellidos(DTrabajador Trabajador)
        {
            DataTable DtResultado = new DataTable("trabajador");
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "spbuscar_trabajador_apellidos";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParTextoBuscar = new SqlParameter();
                        ParTextoBuscar.ParameterName = "@textobuscar";
                        ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                        ParTextoBuscar.Size = 50;
                        ParTextoBuscar.Value = Trabajador.TextoBuscar;
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

    //Metodos
    
}
