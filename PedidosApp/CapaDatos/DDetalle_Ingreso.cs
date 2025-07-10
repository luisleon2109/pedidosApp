using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DDetalle_Ingreso : DbConnection
    {
        //Variables
        private int _Iddetalle_ingreso;
        private int _Idingreso;
        private int _Idarticulo;
        private decimal _Precio_compra;
        private decimal _Precio_venta;
        private int _Stock_inicial;
        private int _Stock_actual;
        private DateTime _Fecha_produccion;
        private DateTime _Fecha_vencimiento;
        //Propiedades
        public int Iddetalle_ingreso { get => _Iddetalle_ingreso; set => _Iddetalle_ingreso = value; }
        public int Idingreso { get => _Idingreso; set => _Idingreso = value; }
        public int Idarticulo { get => _Idarticulo; set => _Idarticulo = value; }
        public decimal Precio_compra { get => _Precio_compra; set => _Precio_compra = value; }
        public decimal Precio_venta { get => _Precio_venta; set => _Precio_venta = value; }
        public int Stock_inicial { get => _Stock_inicial; set => _Stock_inicial = value; }
        public int Stock_actual { get => _Stock_actual; set => _Stock_actual = value; }
        public DateTime Fecha_produccion { get => _Fecha_produccion; set => _Fecha_produccion = value; }
        public DateTime Fecha_vencimiento { get => _Fecha_vencimiento; set => _Fecha_vencimiento = value; }
        //Constructores
        public DDetalle_Ingreso()
        {

        }
        public DDetalle_Ingreso(int iddetalle_ingreso, int idingreso, int idarticulo,
            decimal precio_compra, decimal precio_venta, int stock_inicial, int stock_actual,
            DateTime fecha_produccion, DateTime fecha_vencimiento)
        {
            this.Iddetalle_ingreso = iddetalle_ingreso;
            this.Idingreso = idingreso;
            this.Idarticulo = idarticulo;
            this.Precio_compra = precio_compra;
            this.Precio_venta = precio_venta;
            this.Stock_inicial = stock_inicial;
            this.Stock_actual = stock_actual;
            this.Fecha_produccion = fecha_produccion;
            this.Fecha_vencimiento = fecha_vencimiento;
        }
        //Metodo Insertar
        public string Insertar(DDetalle_Ingreso Detalle_ingreso, ref SqlConnection SqlCon,
            ref SqlTransaction SqlTra)
        {
            string rpta = "";
            try
            {
                //Establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "spinsertar_detalle_ingreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIddetalle_ingreso = new SqlParameter();
                ParIddetalle_ingreso.ParameterName = "@iddetalle_ingreso";
                ParIddetalle_ingreso.SqlDbType = SqlDbType.Int;
                ParIddetalle_ingreso.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIddetalle_ingreso);

                SqlParameter ParIdingreso = new SqlParameter();
                ParIdingreso.ParameterName = "@idingreso";
                ParIdingreso.SqlDbType = SqlDbType.Int;
                ParIdingreso.Value = Detalle_ingreso.Idingreso;
                SqlCmd.Parameters.Add(ParIdingreso);

                SqlParameter ParIdarticulo = new SqlParameter();
                ParIdarticulo.ParameterName = "@idarticulo";
                ParIdarticulo.SqlDbType = SqlDbType.Int;
                ParIdarticulo.Value = Detalle_ingreso.Idarticulo;
                SqlCmd.Parameters.Add(ParIdarticulo);

                SqlParameter ParPrecio_compra = new SqlParameter();
                ParPrecio_compra.ParameterName = "@precio_compra";
                ParPrecio_compra.SqlDbType = SqlDbType.Money;
                ParPrecio_compra.Value = Detalle_ingreso.Precio_compra;
                SqlCmd.Parameters.Add(ParPrecio_compra);

                SqlParameter ParPrecio_venta = new SqlParameter();
                ParPrecio_venta.ParameterName = "@precio_venta";
                ParPrecio_venta.SqlDbType = SqlDbType.Money;
                ParPrecio_venta.Value = Detalle_ingreso.Precio_venta;
                SqlCmd.Parameters.Add(ParPrecio_venta);

                SqlParameter ParStock_inicial = new SqlParameter();
                ParStock_inicial.ParameterName = "@stock_inicial";
                ParStock_inicial.SqlDbType = SqlDbType.Int;
                ParStock_inicial.Value = Detalle_ingreso.Stock_inicial;
                SqlCmd.Parameters.Add(ParStock_inicial);

                SqlParameter ParStock_actual = new SqlParameter();
                ParStock_actual.ParameterName = "@stock_actual";
                ParStock_actual.SqlDbType = SqlDbType.Int;
                ParStock_actual.Value = Detalle_ingreso.Stock_actual;
                SqlCmd.Parameters.Add(ParStock_actual);

                SqlParameter ParFecha_produccion = new SqlParameter();
                ParFecha_produccion.ParameterName = "@fecha_produccion";
                ParFecha_produccion.SqlDbType = SqlDbType.Date;
                ParFecha_produccion.Value = Detalle_ingreso.Fecha_produccion;
                SqlCmd.Parameters.Add(ParFecha_produccion);

                SqlParameter ParFecha_vencimiento = new SqlParameter();
                ParFecha_vencimiento.ParameterName = "@fecha_vencimiento";
                ParFecha_vencimiento.SqlDbType = SqlDbType.Date;
                ParFecha_vencimiento.Value = Detalle_ingreso.Fecha_vencimiento;
                SqlCmd.Parameters.Add(ParFecha_vencimiento);
                //Ejecutamos el comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO SE INGRESO EL REGISTRO";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }
    }
}
