using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PedidosApp
{
    public partial class FrmPresentacion : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        public FrmPresentacion()
        {
            InitializeComponent();
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
            this.dataListado.DataSource = NPresentacion.Mostrar();
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
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;

            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }
        //Habilitar los control del formulario
        private void Habilitar(bool valor)
        {
            this.txtIdPresentacion.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
        }
        private void Limpiar()
        {
            this.txtIdPresentacion.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtDescripcion.Text == string.Empty || this.txtNombre.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, seran remarcados");
                    //errorIcono.SetError(txtCodigo, "Ingrese un valor");
                    //errorIcono.SetError(txtNombre, "Ingrese el nombre del articulo");
                    //errorIcono.SetError(txtCategoria, "Seleccione una categoria");
                }
                else
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();

                    if (this.IsNuevo)
                    {
                        rpta = NPresentacion.Insertar(txtNombre.Text.Trim().ToUpper(),
                            txtDescripcion.Text.Trim());
                    }
                    else
                    {
                        rpta = NPresentacion.Editar(Convert.ToInt32(txtIdPresentacion.Text),
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

        private void FrmPresentacion_Load(object sender, EventArgs e)
        {
            this.Habilitar(false);
            Mostrar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.txtIdPresentacion.ReadOnly = true;
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            txtIdPresentacion.Text = Convert.ToString(dataListado.CurrentRow.Cells["idpresentacion"].Value);
            txtNombre.Text = Convert.ToString(dataListado.CurrentRow.Cells["nombre"].Value);
            txtDescripcion.Text = Convert.ToString(dataListado.CurrentRow.Cells["descripcion"].Value);
            tabControl1.SelectedIndex = 1;
            IsEditar = true;
            Botones();
            Habilitar(true);
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (txtIdPresentacion.Text.Equals(""))
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

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }
    }
}
