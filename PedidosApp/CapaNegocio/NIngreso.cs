using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NIngreso
    {
        public static string Insertar(int idtrabajador, int idproveedor, DateTime fecha,
            string tipo_comprobante, string serie, string correlativo, decimal igv,
            string estado, DataTable dtDetalles)
        {
            DIngreso Obj = new DIngreso();
            Obj.Idtrabajador = idtrabajador;
            Obj.Idproveedor = idproveedor;
            Obj.Fecha = fecha;
            Obj.Tipo_comprobante = tipo_comprobante;
            Obj.Serie = serie;
            Obj.Correlativo = correlativo;
            Obj.Iva = igv;
            Obj.Estado = estado;
            List<DDetalle_Ingreso> detalles = new List<DDetalle_Ingreso>();
            foreach (DataRow row in dtDetalles.Rows)
            {
                DDetalle_Ingreso detalle = new DDetalle_Ingreso();
                detalle.Idarticulo = Convert.ToInt32(row["idarticulo"].ToString());
                detalle.Precio_compra = Convert.ToDecimal(row["precio_compra"].ToString());
                detalle.Precio_venta = Convert.ToDecimal(row["precio_venta"].ToString());
                detalle.Stock_inicial = Convert.ToInt32(row["stock_inicial"].ToString());
                detalle.Fecha_produccion = Convert.ToDateTime(row["fecha_produccion"].ToString());
                detalle.Fecha_vencimiento = Convert.ToDateTime(row["fecha_vencimiento"].ToString());
                detalles.Add(detalle);
            }
            return Obj.Insertar(Obj, detalles);
        }
        //Metodo Anular ingreso
        public static string Anular(int idingreso)
        {
            DIngreso Obj = new DIngreso();
            Obj.Idingreso = idingreso;
            return Obj.Anular(Obj);
        }
        //Metodo Mostrar que llama al metodo Mostrar de la clase DIngreso de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DIngreso().Mostrar();
        }
        //Metodo Buscar Fecha que llama al metodo BuscarFecha de la clase DIngreso de la CapaDatos
        public static DataTable BuscarFechas(string textobuscar1, string textobuscar2)
        {
            DIngreso Obj = new DIngreso();
            return Obj.BuscarFechas(textobuscar1, textobuscar2);
        }
        //Metodo mostrar detalle
        public static DataTable MostrarDetalle(string textobuscar)
        {
            DIngreso Obj = new DIngreso();
            return Obj.MostrarDetalle(textobuscar);
        }
    }
}
