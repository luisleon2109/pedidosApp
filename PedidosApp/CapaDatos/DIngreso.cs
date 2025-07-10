using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaDatos
{
    public class DIngreso:DbConnection
    {
        private int _Idingreso;
        private int _Idtrabajador;
        private int _Idproveedor;
        private DateTime _Fecha;
        private string _Tipo_comprobante;
        private string _Serie;
        private string _Correlativo;
        private decimal _Iva;
        private string _Estado;


        public DIngreso()
        {

        }

        public DIngreso(int idingreso, int idtrabajador, int idproveedor, 
            DateTime fecha, string tipo_comprobante, string serie, string correlativo, 
            decimal iva, string estado)
        {
            _Idingreso = idingreso;
            _Idtrabajador = idtrabajador;
            _Idproveedor = idproveedor;
            _Fecha = fecha;
            _Tipo_comprobante = tipo_comprobante;
            _Serie = serie;
            _Correlativo = correlativo;
            _Iva = iva;
            _Estado = estado;
        }

        public int Idingreso { get => _Idingreso; set => _Idingreso = value; }
        public int Idtrabajador { get => _Idtrabajador; set => _Idtrabajador = value; }
        public int Idproveedor { get => _Idproveedor; set => _Idproveedor = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
        public string Tipo_comprobante { get => _Tipo_comprobante; set => _Tipo_comprobante = value; }
        public string Serie { get => _Serie; set => _Serie = value; }
        public string Correlativo { get => _Correlativo; set => _Correlativo = value; }
        public decimal Iva { get => _Iva; set => _Iva = value; }
        public string Estado { get => _Estado; set => _Estado = value; }

        public string Insertar(DIngreso Ingreso, List<DDetalle_Ingreso> Detalle)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Codigo
                SqlCon.ConnectionString = DbConnection.cn;
                SqlCon.Open();
                //Establecer la transaccion
                SqlTransaction SqlTra = SqlCon.BeginTransaction();
                //Establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "spinsertar_ingreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdingreso = new SqlParameter();
                ParIdingreso.ParameterName = "@idingreso";
                ParIdingreso.SqlDbType = SqlDbType.Int;
                ParIdingreso.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdingreso);

                SqlParameter ParIdtrabajador = new SqlParameter();
                ParIdtrabajador.ParameterName = "@idtrabajador";
                ParIdtrabajador.SqlDbType = SqlDbType.Int;
                ParIdtrabajador.Value = Ingreso.Idtrabajador;
                SqlCmd.Parameters.Add(ParIdtrabajador);

                SqlParameter ParIdproveedor = new SqlParameter();
                ParIdproveedor.ParameterName = "@idproveedor";
                ParIdproveedor.SqlDbType = SqlDbType.Int;
                ParIdproveedor.Value = Ingreso.Idproveedor;
                SqlCmd.Parameters.Add(ParIdproveedor);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.Date;
                ParFecha.Value = Ingreso.Fecha;
                SqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParTipo_comprobante = new SqlParameter();
                ParTipo_comprobante.ParameterName = "@tipo_comprobante";
                ParTipo_comprobante.SqlDbType = SqlDbType.VarChar;
                ParTipo_comprobante.Size = 20;
                ParTipo_comprobante.Value = Ingreso.Tipo_comprobante;
                SqlCmd.Parameters.Add(ParTipo_comprobante);

                SqlParameter ParSerie = new SqlParameter();
                ParSerie.ParameterName = "@serie";
                ParSerie.SqlDbType = SqlDbType.VarChar;
                ParSerie.Size = 10;
                ParSerie.Value = Ingreso.Serie;
                SqlCmd.Parameters.Add(ParSerie);

                SqlParameter ParCorrelativo = new SqlParameter();
                ParCorrelativo.ParameterName = "@correlativo";
                ParCorrelativo.SqlDbType = SqlDbType.VarChar;
                ParCorrelativo.Size = 10;
                ParCorrelativo.Value = Ingreso.Correlativo;
                SqlCmd.Parameters.Add(ParCorrelativo);

                SqlParameter ParIva= new SqlParameter();
                ParIva.ParameterName = "@iva";
                ParIva.SqlDbType = SqlDbType.Decimal;
                ParIva.Precision = 4;
                ParIva.Scale = 2;
                ParIva.Value = Ingreso.Iva;
                SqlCmd.Parameters.Add(ParIva);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 10;
                ParEstado.Value = Ingreso.Estado;
                SqlCmd.Parameters.Add(ParEstado);
                //Ejecutamos el comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO SE INGRESO EL REGISTRO";
                if (rpta.Equals("OK"))
                {
                    //Obtener el codigo del ingreso generado
                    this.Idingreso = Convert.ToInt32(SqlCmd.Parameters["@idingreso"].Value);
                    foreach (DDetalle_Ingreso det in Detalle)
                    {
                        det.Idingreso = this.Idingreso;
                        //Llamar al metodo insertar de la clase DDetalle_ingreso
                        rpta = det.Insertar(det, ref SqlCon, ref SqlTra);
                        if (!rpta.Equals("OK"))
                        {
                            break;
                        }
                    }
                }
                if (rpta.Equals("OK"))
                {
                    SqlTra.Commit();
                }
                else
                {
                    SqlTra.Rollback();
                }
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }
        //Metodo para anular un ingreso
        public string Anular(DIngreso Ingreso)
        {
            string rpta = "";
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        //Establecer el comando
                        command.Connection = connection;
                        command.CommandText = "spanular_ingreso";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdingreso = new SqlParameter();
                        ParIdingreso.ParameterName = "@idingreso";
                        ParIdingreso.SqlDbType = SqlDbType.Int;
                        ParIdingreso.Value = Ingreso.Idingreso;
                        command.Parameters.Add(ParIdingreso);
                        //Ejecutamos el comando
                        rpta = command.ExecuteNonQuery() == 1 ? "OK" : "NO SE ANULO EL REGISTRO";
                    }
                    catch (Exception ex)
                    {
                        rpta = ex.Message;
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open) connection.Close();
                    }
                }
            }
            return rpta;
        }
        //Metodo Mostrar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("ingreso");
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        //Establecer el comando
                        command.Connection = connection;
                        command.CommandText = "spmostrar_ingreso";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter Sqldat = new SqlDataAdapter(command);
                        Sqldat.Fill(DtResultado);
                    }
                    catch (Exception)
                    {
                        DtResultado = null;
                    }
                }
            }
            return DtResultado;
        }
        //Metodo Buscar por fechas
        public DataTable BuscarFechas(string TextoBuscar1, string TextoBuscar2)
        {
            DataTable DtResultado = new DataTable("ingreso");
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        //Establecer el comando
                        command.Connection = connection;
                        command.CommandText = "spbuscar_ingreso_fecha";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParTextoBuscar = new SqlParameter();
                        ParTextoBuscar.ParameterName = "@textobuscar1";
                        ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                        ParTextoBuscar.Size = 50;
                        ParTextoBuscar.Value = TextoBuscar1;
                        command.Parameters.Add(ParTextoBuscar);

                        SqlParameter ParTextoBuscar2 = new SqlParameter();
                        ParTextoBuscar2.ParameterName = "@textobuscar2";
                        ParTextoBuscar2.SqlDbType = SqlDbType.VarChar;
                        ParTextoBuscar2.Size = 50;
                        ParTextoBuscar2.Value = TextoBuscar2;
                        command.Parameters.Add(ParTextoBuscar2);

                        SqlDataAdapter Sqldat = new SqlDataAdapter(command);
                        Sqldat.Fill(DtResultado);
                    }
                    catch (Exception)
                    {
                        DtResultado = null;
                    }
                }
            }
            return DtResultado;
        }
        //Metodo Mostrar Detalle
        public DataTable MostrarDetalle(string TextoBuscar)
        {
            DataTable DtResultado = new DataTable("detalle_ingreso");
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        //Establecer el comando
                        command.Connection = connection;
                        command.CommandText = "spmostrar_detalle_ingreso";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParTextoBuscar = new SqlParameter();
                        ParTextoBuscar.ParameterName = "@textobuscar";
                        ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                        ParTextoBuscar.Size = 50;
                        ParTextoBuscar.Value = TextoBuscar;
                        command.Parameters.Add(ParTextoBuscar);

                        SqlDataAdapter Sqldat = new SqlDataAdapter(command);
                        Sqldat.Fill(DtResultado);
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
