using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Policy;

namespace CapaDatos
{
    public class DProveedor:DbConnection
    {
        int _Id_Proveedor;
        string _Razon_Social;
        string _Sector_Comercial;
        string _Tipo_Documento;
        string _Num_Documento;
        string _Direccion;
        string _Email;
        string _Telefono;
        string _Url;
        string _TextoBuscar;

        public int Idproveedor { get => _Id_Proveedor; set => _Id_Proveedor = value; }
        public string Razon_Social { get => _Razon_Social; set => _Razon_Social = value; }
        public string Sector_Comercial { get => _Sector_Comercial; set => _Sector_Comercial = value; }
        public string Tipo_Documento { get => _Tipo_Documento; set => _Tipo_Documento = value; }
        public string Num_Documento { get => _Num_Documento; set => _Num_Documento = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Url { get => _Url; set => _Url = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        public DProveedor()
        {

        }

        public DProveedor(int idproveedor, string razonsocial, string sector_Comercial, 
            string tipo_Documento, string num_Documento, string direccion, string email, 
            string telefono, string url, string textoBuscar)
        {
            Idproveedor = idproveedor;
            Razon_Social = razonsocial;
            Sector_Comercial = sector_Comercial;
            Tipo_Documento = tipo_Documento;
            Num_Documento = num_Documento;
            Direccion = direccion;
            Email = email;
            Telefono = telefono;
            Url = url;
            TextoBuscar = textoBuscar;
        }

        public string Insertar(DProveedor Proveedor)
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
                        command.CommandText = "spinsertar_proveedor";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdproveedor = new SqlParameter();
                        ParIdproveedor.ParameterName = "@idproveedor";
                        ParIdproveedor.SqlDbType = SqlDbType.Int;
                        ParIdproveedor.Direction = ParameterDirection.Output;
                        command.Parameters.Add(ParIdproveedor);

                        SqlParameter ParRazonsocial = new SqlParameter();
                        ParRazonsocial.ParameterName = "@razon_social";
                        ParRazonsocial.SqlDbType = SqlDbType.VarChar;
                        ParRazonsocial.Size = 150;
                        ParRazonsocial.Value = Proveedor.Razon_Social;
                        command.Parameters.Add(ParRazonsocial);

                        SqlParameter ParSector_Comercial = new SqlParameter();
                        ParSector_Comercial.ParameterName = "@sector_comercial";
                        ParSector_Comercial.SqlDbType = SqlDbType.VarChar;
                        ParSector_Comercial.Size = 50;
                        ParSector_Comercial.Value = Proveedor.Sector_Comercial;
                        command.Parameters.Add(ParSector_Comercial);

                        SqlParameter ParTipo_Documento = new SqlParameter();
                        ParTipo_Documento.ParameterName = "@tipo_documento";
                        ParTipo_Documento.SqlDbType = SqlDbType.VarChar;
                        ParTipo_Documento.Size = 20;
                        ParTipo_Documento.Value = Proveedor.Tipo_Documento;
                        command.Parameters.Add(ParTipo_Documento);

                        SqlParameter ParNum_Documento = new SqlParameter();
                        ParNum_Documento.ParameterName = "@num_documento";
                        ParNum_Documento.SqlDbType = SqlDbType.VarChar;
                        ParNum_Documento.Size = 20;
                        ParNum_Documento.Value = Proveedor.Num_Documento;
                        command.Parameters.Add(ParNum_Documento);

                        SqlParameter ParDireccion = new SqlParameter();
                        ParDireccion.ParameterName = "@direccion";
                        ParDireccion.SqlDbType = SqlDbType.VarChar;
                        ParDireccion.Size = 100;
                        ParDireccion.Value = Proveedor.Direccion;
                        command.Parameters.Add(ParDireccion);                        

                        SqlParameter ParTelefono = new SqlParameter();
                        ParTelefono.ParameterName = "@telefono";
                        ParTelefono.SqlDbType = SqlDbType.VarChar;
                        ParTelefono .Size = 10;
                        ParTelefono.Value = Proveedor.Telefono;
                        command.Parameters.Add(ParTelefono);

                        SqlParameter ParEmail = new SqlParameter();
                        ParEmail.ParameterName = "@email";
                        ParEmail.SqlDbType = SqlDbType.VarChar;
                        ParEmail.Size = 50;
                        ParEmail.Value = Proveedor.Email;
                        command.Parameters.Add(ParEmail);

                        SqlParameter ParUrl = new SqlParameter();
                        ParUrl.ParameterName = "@url";
                        ParUrl.SqlDbType = SqlDbType.VarChar;
                        ParUrl.Size = 100;
                        ParUrl.Value = Proveedor.Url;
                        command.Parameters.Add(ParUrl);

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
        public string Editar(DProveedor Proveedor)
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
                        command.CommandText = "speditar_proveedor";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdProveedor = new SqlParameter();
                        ParIdProveedor.ParameterName = "@idproveedor";
                        ParIdProveedor.SqlDbType = SqlDbType.Int;
                        ParIdProveedor.Value = Proveedor.Idproveedor;
                        command.Parameters.Add(ParIdProveedor);

                        SqlParameter ParRazonsocial = new SqlParameter();
                        ParRazonsocial.ParameterName = "@razon_social";
                        ParRazonsocial.SqlDbType = SqlDbType.VarChar;
                        ParRazonsocial.Size = 150;
                        ParRazonsocial.Value = Proveedor.Razon_Social;
                        command.Parameters.Add(ParRazonsocial);

                        SqlParameter ParSectorcomercial = new SqlParameter();
                        ParSectorcomercial.ParameterName = "@sector_comercial";
                        ParSectorcomercial.SqlDbType = SqlDbType.VarChar;
                        ParSectorcomercial.Size = 50;
                        ParSectorcomercial.Value = Proveedor.Sector_Comercial;
                        command.Parameters.Add(ParSectorcomercial);

                        SqlParameter ParTipodocumento = new SqlParameter();
                        ParTipodocumento.ParameterName = "@tipo_documento";
                        ParTipodocumento.SqlDbType = SqlDbType.VarChar;
                        ParTipodocumento.Size = 20;
                        ParTipodocumento.Value = Proveedor.Tipo_Documento;
                        command.Parameters.Add(ParTipodocumento);

                        SqlParameter ParNrodocumento = new SqlParameter();
                        ParNrodocumento.ParameterName = "@num_documento";
                        ParNrodocumento.SqlDbType = SqlDbType.VarChar;
                        ParNrodocumento.Size = 20;
                        ParNrodocumento.Value = Proveedor.Num_Documento;
                        command.Parameters.Add(ParNrodocumento);

                        SqlParameter ParDireccion = new SqlParameter();
                        ParDireccion.ParameterName = "@direccion";
                        ParDireccion.SqlDbType = SqlDbType.VarChar;
                        ParDireccion.Size = 100;
                        ParDireccion.Value = Proveedor.Direccion;
                        command.Parameters.Add(ParDireccion);

                        SqlParameter ParTelefono = new SqlParameter();
                        ParTelefono.ParameterName = "@telefono";
                        ParTelefono.SqlDbType = SqlDbType.VarChar;
                        ParTelefono.Size = 10;
                        ParTelefono.Value = Proveedor.Telefono;
                        command.Parameters.Add(ParTelefono);

                        SqlParameter ParEnlace = new SqlParameter();
                        ParEnlace.ParameterName = "@email";
                        ParEnlace.SqlDbType = SqlDbType.VarChar;
                        ParEnlace.Size = 100;
                        ParEnlace.Value = Proveedor._Email;
                        command.Parameters.Add(ParEnlace);

                        SqlParameter ParUrl = new SqlParameter();
                        ParUrl.ParameterName = "@url";
                        ParUrl.SqlDbType = SqlDbType.VarChar;
                        ParUrl.Value = Proveedor.Url;
                        command.Parameters.Add(ParUrl);

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
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("proveedor");
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "spmostrar_proveedor";
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

        // Método BuscarRazonSocial
        public DataTable BuscarRazon_Social(string textoBuscar)
        {
            DataTable dtResultado = new DataTable("proveedor");
            using (SqlConnection connection = GetConnection())
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "spbuscar_proveedor_razon_social";
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

        // Método BuscarNumDocumento
        public DataTable BuscarNum_Documento(string textoBuscar)
        {
            DataTable dtResultado = new DataTable("proveedor");
            using (SqlConnection connection = GetConnection())
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "spbuscar_proveedor_num_documento";
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

        public DataTable BuscarProveedor(DProveedor proveedor)
        {
            DataTable DtResultado = new DataTable("proveedor");
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "spbuscar_proveedor";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParTextoBuscar = new SqlParameter();
                        ParTextoBuscar.ParameterName = "@textobuscar";
                        ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                        ParTextoBuscar.Size = 50;
                        ParTextoBuscar.Value = proveedor.TextoBuscar;
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
        public string Eliminar(DProveedor proveedor)
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
                        command.CommandText = "speliminar_proveedor";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdproveedor = new SqlParameter();
                        ParIdproveedor.ParameterName = "@idproveedor";
                        ParIdproveedor.SqlDbType = SqlDbType.Int;
                        ParIdproveedor.Value = proveedor.Idproveedor;
                        command.Parameters.Add(ParIdproveedor);

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
    }
}
