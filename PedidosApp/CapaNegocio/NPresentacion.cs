using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NPresentacion
    {
        //Metodo Insertar que llama al Insertar de la clase DPresentacion de la CapaDatos
        public static string Insertar(string nombre ,string descripcion)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            return Obj.Insertar(Obj);
        }
        //Metodo Editar que llama al metodo Editar de la clase DPresentacion de la CapaDatos
        public static string Editar(int idpresentacion, string nombre, string descripcion)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.Idpresentacion = idpresentacion;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            return Obj.Editar(Obj);
        }
        //Metodo Eliminar que llama al metodo Eliminar de la clase DArticulo de la CapaDatos
        public static string Eliminar(int idpresentacion)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.Idpresentacion = idpresentacion;
            return Obj.Eliminar(Obj);
        }
        //Metodo Mostrar que llama al metodo Mostrar de la clase DArticulo de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DPresentacion().Mostrar();
        }
        //Metodo BuscarNombre que llama al metodo BuscarNombre de la clase DArticulo de la CapaDatos
        public static DataTable BuscarNombre(string textobuscar)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }

    }
}
