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
using System.Windows.Media;

namespace PedidosApp
{
    public partial class FrmProveedor : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        public FrmProveedor()
        {
            InitializeComponent();
            Mostrar();
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
            this.dataListado.DataSource = NProveedor.Mostrar();
            this.OcultarColumnas();
            this.lblTotal.Text = "Registros encontrados: " + Convert.ToString(dataListado.Rows.Count);
            this.tabControl1.SelectedIndex = 0;
        }

        private void OcultarColumnas()
        {
            if (this.dataListado.Rows.Count > 0)
            {
                this.dataListado.Columns[0].Visible = false;
                this.dataListado.Columns[1].Visible = false;

            }
        }
        private void BuscarProveedor()
        {
            this.dataListado.DataSource = NProveedor.BuscarProveedor(this.txtBuscar.Text);
            this.OcultarColumnas();
            this.lblTotal.Text = "Registros encontrados: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void BuscarRazon_Social()
        {
            this.dataListado.DataSource = NProveedor.BuscarRazon_Social(this.txtBuscar.Text);
            this.OcultarColumnas();
            this.lblTotal.Text = "Registros encontrados: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void BuscarNum_Documento()
        {
            this.dataListado.DataSource = NProveedor.BuscarNum_Documento(this.txtBuscar.Text);
            this.OcultarColumnas();
            this.lblTotal.Text = "Registros encontrados: " + Convert.ToString(dataListado.Rows.Count);
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
            this.txtIdProveedor.ReadOnly = !valor;
            this.txtRazonSocial.ReadOnly = !valor;
            this.cbxSectorComercial.Enabled = valor;
            this.txtNroDocumento.ReadOnly = !valor;
            this.cbxTipoDocumento.Enabled = valor;
            this.txtDireccion.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
            this.txtTelefonos.ReadOnly = !valor;
            this.txtEnlace.ReadOnly = !valor;
        }
        private void Limpiar()
        {
            this.txtIdProveedor.Text = String.Empty;
            this.txtRazonSocial.Text = String.Empty;
            this.cbxSectorComercial.Text = String.Empty;
            this.cbxTipoDocumento.Text = String.Empty;
            this.txtNroDocumento.Text = String.Empty;
            this.txtDireccion.Text = String.Empty;
            this.txtEmail.Text = String.Empty;
            this.txtTelefonos.Text = String.Empty;
            this.txtEnlace.Text = String.Empty;
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.txtIdProveedor.ReadOnly = true;
        }

        private void FrmProveedor_Load(object sender, EventArgs e)
        {
            Habilitar(false);
            Botones();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            Botones();
            Limpiar();
            Habilitar(false);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtRazonSocial.Text == string.Empty || this.cbxSectorComercial.Text== string.Empty
                    || this.cbxTipoDocumento.Text==string.Empty|| this.txtNroDocumento.Text == string.Empty || this.txtDireccion.Text == string.Empty||this.txtEmail.Text==string.Empty
                    || this.txtTelefonos.Text == string.Empty||this.txtEnlace.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, seran remarcados");
                    errorIcono.SetError(this.txtRazonSocial, "Ingrese el nombre de la compañia");
                    errorIcono.SetError(this.txtDireccion, "Ingrese una direccion");
                    errorIcono.SetError(this.cbxSectorComercial, "Ingrese el sector comercial");
                    errorIcono.SetError(this.cbxTipoDocumento, "Ingrese el tipo de documento");
                    errorIcono.SetError(this.txtNroDocumento, "Ingrese el numero de documento");
                    errorIcono.SetError(this.txtEnlace, "Ingrese un enlace");
                    errorIcono.SetError(this.txtEmail, "Ingrese un correo electronico");
                    errorIcono.SetError(this.txtTelefonos, "Ingrese un nro de telefono");
                }
                else
                {

                    if (this.IsNuevo)
                    {
                        rpta = NProveedor.Insertar(this.txtRazonSocial.Text.Trim().ToUpper(),
                            cbxSectorComercial.Text.Trim().ToUpper(), cbxTipoDocumento.Text.Trim().ToUpper(),txtNroDocumento.Text, txtDireccion.Text.Trim().ToUpper(),
                            txtTelefonos.Text, txtEmail.Text.Trim().ToLower(), txtEnlace.Text.Trim());
                    }
                    else
                    {
                        rpta = NProveedor.Editar(Convert.ToInt32(txtIdProveedor.Text),
                            txtRazonSocial.Text.Trim().ToUpper(), cbxSectorComercial.Text.Trim(), cbxTipoDocumento.Text.Trim().ToUpper(), 
                            txtNroDocumento.Text, txtDireccion.Text.Trim().ToUpper(),
                             txtTelefonos.Text, txtEmail.Text.Trim().ToLower(), txtEnlace.Text.Trim());
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

        private void ttMensaje_Popup(object sender, PopupEventArgs e)
        {

        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            try
            {


                txtIdProveedor.Text = Convert.ToString(dataListado.CurrentRow.Cells["idproveedor"].Value);
                txtRazonSocial.Text = Convert.ToString(dataListado.CurrentRow.Cells["razon_social"].Value);
                cbxSectorComercial.Text = Convert.ToString(dataListado.CurrentRow.Cells["sector_comercial"].Value);
                cbxTipoDocumento.Text = Convert.ToString(dataListado.CurrentRow.Cells["tipo_documento"].Value);
                txtNroDocumento.Text = Convert.ToString(dataListado.CurrentRow.Cells["num_documento"].Value);
                txtDireccion.Text = Convert.ToString(dataListado.CurrentRow.Cells["direccion"].Value);
                txtEmail.Text = Convert.ToString(dataListado.CurrentRow.Cells["email"].Value);
                txtTelefonos.Text = Convert.ToString(dataListado.CurrentRow.Cells["telefono"].Value);
                txtEnlace.Text = Convert.ToString(dataListado.CurrentRow.Cells["url"].Value);

                tabControl1.SelectedIndex = 1;
                IsNuevo = false;
                IsEditar = true;
                Botones();
                Habilitar(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtIdProveedor.Text.Equals(""))
            {
                IsNuevo = false;
                IsEditar = true;
                Botones();
                Habilitar(true);
            }
            else
            {
                MensajeError("Debe seleccioanr primero el registro para modificar");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbxFiltro.Text == "RAZON SOCIAL")
                BuscarRazon_Social();
            else if (cbxFiltro.Text == "DOCUMENTO")
                BuscarNum_Documento();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Esta seguro de borrar los registros?", "Pedidos App",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string rpta = "";
                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            rpta = NProveedor.Eliminar(Convert.ToInt32(Codigo));
                            if (rpta.Equals("OK"))
                            {
                                MensajeOk("Se borraron los registros");
                            }
                            else { MensajeError(rpta); }
                        }
                    }

                    //Codigo = dataListado.CurrentRow.Cells[1].Value.ToString();
                    ////MessageBox.Show(Codigo);
                    //rpta = NProveedor.Eliminar(Convert.ToInt32(Codigo));
                    //if (rpta.Equals("OK"))
                    //{
                    //    MensajeOk("Se borraron los registros");
                    //}
                    //else { MensajeError(rpta); }
                    Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

            
            if (cbxFiltro.Text == "RAZON SOCIAL")
                BuscarRazon_Social();
            else if (cbxFiltro.Text == "DOCUMENTO")
                BuscarNum_Documento();


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
