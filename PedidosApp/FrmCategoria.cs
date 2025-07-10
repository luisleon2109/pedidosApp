using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PedidosApp
{
    public partial class FrmCategoria : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public FrmCategoria()
        {
            InitializeComponent();
            ttMensaje.SetToolTip(txtNombre,"Ingrese el nombre de la Categoria");
            txtIdCategoria.Enabled = false;
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Pedidos App", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Mostrar Mensaje de error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Pedidos App", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void Mostrar()
        {
            this.dataListado.DataSource = NCategoria.Mostrar();
            //this.OcultarColumnas();
            this.lblTotal.Text = "Registros encontrados: " + Convert.ToString(dataListado.Rows.Count);
            this.tabControl1.SelectedIndex = 0;
        }

        //Habilitar Botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.BtnEditar.Enabled = false;
                this.BtnCancelar.Enabled = true;

            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.BtnEditar.Enabled = true;
                this.BtnCancelar.Enabled = false;
            }
        }
        //Habilitar los control del formulario
        private void Habilitar(bool valor)
        {
            this.txtIdCategoria.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
        }
        private void Limpiar()
        {
            this.txtIdCategoria.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
        }
        private void OcultarColumnas()
        {
            if (this.dataListado.Rows.Count > 0)
            {
                this.dataListado.Columns[0].Visible = false;
                this.dataListado.Columns[1].Visible = false;

            }
        }
        //Metodo BuscarNombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NCategoria.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            this.lblTotal.Text = "Registros encontrados: ";
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.txtIdCategoria.ReadOnly = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtDescripcion.Text == string.Empty || this.txtNombre.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, seran remarcados");
                    errorIcono.SetError(txtIdCategoria, "Ingrese un valor");
                    errorIcono.SetError(txtNombre, "Ingrese el nombre de la categoria");
                    errorIcono.SetError(txtDescripcion, "Ingrese una descripcion");
                }
                else
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();

                    if (this.IsNuevo)
                    {
                        rpta = NCategoria.Insertar(txtNombre.Text.Trim().ToUpper(),
                            txtDescripcion.Text.Trim());
                    }
                    else
                    {
                        rpta = NCategoria.Editar(Convert.ToInt32(txtIdCategoria.Text),
                            txtNombre.Text.Trim().ToUpper(), txtDescripcion.Text.Trim());
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo) { MensajeOk("se guardo el registro"); }
                        else { MensajeOk("se actualizo el registro"); }
                    }
                    else
                    {
                        MensajeError(rpta);
                    }
                    IsNuevo = false;
                    IsEditar = false;
                    Botones();
                    Limpiar();
                    Mostrar();
                
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            this.Habilitar(false);
            Mostrar();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (txtIdCategoria.Text.Equals(""))
            {
                IsEditar = true;
                Botones();
                Habilitar(true);
            }
            else
            {
                MensajeError("Debe seleccioanr primero el registro para modificar");
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            IsNuevo = false;
            IsEditar = false;
            Botones();
            Limpiar();
            Habilitar(false);
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            txtIdCategoria.Text = Convert.ToString(dataListado.CurrentRow.Cells["idcategoria"].Value);
            txtNombre.Text = Convert.ToString(dataListado.CurrentRow.Cells["nombre"].Value);
            txtDescripcion.Text = Convert.ToString(dataListado.CurrentRow.Cells["descripcion"].Value);
            tabControl1.SelectedIndex = 1;
            IsEditar = true;
            Botones();
            Habilitar(true);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                dataListado.Columns[0].Visible = true;
            }
            else
            {
                dataListado.Columns[0].Visible = false;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Esta seguro de borrar los registros", "Pedidos App",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string rpta = "";
                    //foreach (DataGridViewRow row in dataListado.Rows)
                    //{
                    //    if (Convert.ToBoolean(row.Cells[0].Value))
                    //    {
                    //        Codigo = Convert.ToString(row.Cells[0].Value);
                    //        rpta = NCategoria.Eliminar(Convert.ToInt32(Codigo));

                    //        if (rpta.Equals("OK"))
                    //            MensajeOk("Se borraron los registros");
                    //        else
                    //            MensajeError(rpta);
                    //    }
                    //}
                    Codigo = dataListado.CurrentRow.Cells[1].Value.ToString();
                    //MessageBox.Show(Codigo);
                    rpta = NCategoria.Eliminar(Convert.ToInt32(Codigo));
                    if (rpta.Equals("OK"))
                    {
                        MensajeOk("Se borraron los registros");
                    }
                    else { MensajeError(rpta); }
                    Mostrar();


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }
    }
}
