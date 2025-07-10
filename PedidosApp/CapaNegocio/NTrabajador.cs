using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NTrabajador
    {
        //Metodo Insertar que llama al Insertar de la clase DTrabajador de la CapaDatos
        public static string Insertar(string nombre, string apellido,
            string sexo, DateTime fecha_Nac, string num_documento, string direccion,
            string telefono, string email, string acceso, string usuario, string password, string textobuscar)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.Nombre = nombre;
            Obj.Apellidos = apellido;
            Obj.Sexo = sexo;
            Obj.Fecha_Nac = fecha_Nac;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Acceso = acceso;
            Obj.Usuario = usuario;
            Obj.Password = password;
            Obj.TextoBuscar = textobuscar;
            return Obj.Insertar(Obj);
        }
        //Metodo Editar que llama al metodo Editar de la clase DTrabajador de la CapaDatos
        public static string Editar(int idtrabajador, string nombre, string apellido,
           string sexo, DateTime fecha_Nac, string num_documento, string direccion,
           string telefono, string email, string acceso, string usuario, string password, string textobuscar)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.Idtrabajador = idtrabajador;
            Obj.Nombre = nombre;
            Obj.Apellidos = apellido;
            Obj.Sexo = sexo;
            Obj.Fecha_Nac = fecha_Nac;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Acceso = acceso;
            Obj.Usuario = usuario;
            Obj.Password = password;
            Obj.TextoBuscar = textobuscar;
            return Obj.Editar(Obj);
        }
        //Metodo Eliminar que llama al metodo Eliminar de la clase DTrabajador de la CapaDatos
        public static string Eliminar(int idtrabajador)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.Idtrabajador = idtrabajador;
            return Obj.Eliminar(Obj);
        }
        public static DataTable BuscarNum_Documento(string textobuscar)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNum_Documento(Obj.TextoBuscar);
        }

        public static DataTable Mostrar()
        {
            return new DTrabajador().Mostrar();
        }

        //public static DataTable Buscartrabajador_apellidos(string textobuscar)
        //{
        //    DTrabajador Obj = new DTrabajador();
        //    Obj.TextoBuscar = textobuscar;
        //    return Obj.Buscartrabajador_apellidos(Obj.TextoBuscar);
        //}
    }
}
