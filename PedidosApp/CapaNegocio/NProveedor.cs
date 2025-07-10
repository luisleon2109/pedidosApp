using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NProveedor
    {
        //Metodo Insertar que llama al Insertar de la clase DProveedor de la CapaDatos
        public static string Insertar(string razon_social,
            string sector_comercial,string tipo_documento,string num_documento, string direccion,
            string telefono, string email, string url)
        {
            DProveedor Obj = new DProveedor();
            Obj.Razon_Social = razon_social;
            Obj.Sector_Comercial = sector_comercial;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Email = email;
            Obj.Telefono = telefono;
            Obj.Url = url;
            return Obj.Insertar(Obj);
        }
        //Metodo Editar que llama al metodo Editar de la clase DProveedor de la CapaDatos
        public static string Editar(int idproveedor, string razonsocial,
            string sectorcomercial, string tipodocumento, string nrodocumento, string direccion,
             string telefono, string email, string enlace)
        {
            DProveedor Obj = new DProveedor();
            Obj.Idproveedor = idproveedor;
            Obj.Razon_Social = razonsocial;
            Obj.Sector_Comercial = sectorcomercial;
            Obj.Tipo_Documento = tipodocumento;
            Obj.Num_Documento = nrodocumento;
            Obj.Direccion = direccion;
            Obj.Email = email;
            Obj.Telefono = telefono;
            Obj.Url = enlace;
            return Obj.Editar(Obj);
        }
        //Metodo Eliminar que llama al metodo Eliminar de la clase DProveedor de la CapaDatos
        public static string Eliminar(int idproveedor)
        {
            DProveedor Obj = new DProveedor();
            Obj.Idproveedor = idproveedor;
            return Obj.Eliminar(Obj);
        }
        public static DataTable BuscarProveedor(string textobuscar)
        {
            DProveedor Obj = new DProveedor();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarProveedor(Obj);
        }






        //Metodo Mostrar que llama al metodo Mostrar de la clase DProveedor de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DProveedor().Mostrar();
        }

        // Método BuscarRazonSocial que llama al método BuscarRazonSocial de la clase DProveedor de la CapaDatos
        public static DataTable BuscarRazon_Social(string textoBuscar)
        {
            DProveedor Obj = new DProveedor();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarRazon_Social(Obj.TextoBuscar);
        }

        // Método BuscarNumDocumento que llama al método BuscarNumDocumento de la clase DProveedor de la CapaDatos
        public static DataTable BuscarNum_Documento(string textoBuscar)
        {
            DProveedor Obj = new DProveedor();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarNum_Documento(Obj.TextoBuscar);
        }

    }
}
