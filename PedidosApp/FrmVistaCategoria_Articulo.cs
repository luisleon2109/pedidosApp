using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace PedidosApp
{
    public partial class FrmVistaCategoria_Articulo : Form
    {
        public FrmVistaCategoria_Articulo()
        {
            InitializeComponent();
        }

        //Metodo Mostrar
        private void Mostrar()
        {
            dataListado.DataSource = NCategoria.Mostrar();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        //Metodo BuscarNombre
        private void BuscarNombre()
        {
            dataListado.DataSource = NCategoria.BuscarNombre(txtBuscar.Text);
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Metodo

        private void FrmVistaCategoria_Articulo_Load(object sender, EventArgs e)
        {
            Mostrar();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarNombre();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarNombre();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            FrmArticulo form = FrmArticulo.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(dataListado.CurrentRow.Cells["idcategoria"].Value);
            par2 = Convert.ToString(dataListado.CurrentRow.Cells["nombre"].Value);
            form.setCategoria(par1, par2);
            Hide();
        }
    }
}
