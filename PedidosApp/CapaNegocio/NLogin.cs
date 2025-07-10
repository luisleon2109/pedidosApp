using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NLogin
    {
        public static DataTable Ingresar(string usuario, string password)
        {
            DLogin Obj = new DLogin();
            Obj.Usuario = usuario;
            Obj.Password = password;
            return Obj.Ingresar(Obj);
        }
    }
}
