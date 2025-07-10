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
    public partial class FrmTrabajador : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        public FrmTrabajador()
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
            this.dataListado.DataSource = NTrabajador.Mostrar();
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
        private void BuscarNum_Documento()
        {
            this.dataListado.DataSource = NTrabajador.BuscarNum_Documento(this.txtBuscar.Text);
            this.OcultarColumnas();
            this.lblTotal.Text = "Registros encontrados: " + Convert.ToString(dataListado.Rows.Count);
        }
        //private void  Buscartrabajador_apellidos()
        //{
        //    this.dataListado.DataSource = NTrabajador. Buscartrabajador_apellidos(this.txtBuscar.Text);
        //    this.OcultarColumnas();
        //    this.lblTotal.Text = "Registros encontrados: " + Convert.ToString(dataListado.Rows.Count);
        //}

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

        private void FrmTrabajador_Load(object sender, EventArgs e)
        {
            Mostrar();
            Habilitar(false);
            Botones();
        }
        //Habilitar los control del formulario
        private void Habilitar(bool valor)
        {
            this.txtIdtrabajador.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
            this.txtApellido.ReadOnly = !valor;
            this.dtFecha_Nac.Enabled = valor;
            this.cbxSexo.Enabled = valor;
            this.txtDireccion.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtNum_Documento.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
            this.txtUsuario.ReadOnly = !valor;
            this.txtPassword.ReadOnly = !valor;
        }
        private void Limpiar()
        {
            this.txtIdtrabajador.Text = String.Empty;
            this.txtNombre.Text = String.Empty;
            this.txtApellido.Text = String.Empty;
            this.cbxSexo.Text = String.Empty;
            this.txtPassword.Text = String.Empty;
            this.txtDireccion.Text = String.Empty;
            this.txtEmail.Text = String.Empty;
            this.txtNum_Documento.Text = String.Empty;
            this.txtAcceso.Text = String.Empty;
            this.txtPassword.Text = String.Empty;
           
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtNombre.Text == string.Empty || this.txtApellido.Text == string.Empty || this.txtNum_Documento.Text == string.Empty ||
                    this.txtDireccion.Text == string.Empty || this.txtTelefono.Text == string.Empty || this.txtEmail.Text == string.Empty ||
                    this.txtAcceso.Text == string.Empty || this.txtUsuario.Text == string.Empty || this.txtPassword.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, seran remarcados");
                    errorIcono.SetError(txtNombre, "Ingrese el nombre");
                    errorIcono.SetError(txtApellido, "Ingrese el apellido");
                    errorIcono.SetError(txtNum_Documento, "Ingrese el número de documento");
                    errorIcono.SetError(txtDireccion, "Ingrese la dirección");
                    errorIcono.SetError(txtTelefono, "Ingrese el teléfono");
                    errorIcono.SetError(txtEmail, "Ingrese el correo electrónico");
                    errorIcono.SetError(txtAcceso, "Ingrese el nivel de acceso");
                    errorIcono.SetError(txtUsuario, "Ingrese el nombre de usuario");
                    errorIcono.SetError(txtPassword, "Ingrese la contraseña");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NTrabajador.Insertar(
                            txtNombre.Text.Trim().ToUpper(),
                            txtApellido.Text.Trim().ToUpper(),
                            cbxSexo.Text.Trim().ToUpper(),
                            dtFecha_Nac.Value,
                            txtNum_Documento.Text,
                            txtDireccion.Text.Trim().ToUpper(),
                            txtTelefono.Text,
                            txtEmail.Text.Trim().ToLower(),
                            txtAcceso.Text,
                            txtUsuario.Text.Trim(),
                            txtPassword.Text,
                            txtBuscar.Text.Trim()
                        );
                    }
                    else
                    {
                        rpta = NTrabajador.Editar(
                            Convert.ToInt32(txtIdtrabajador.Text),
                            txtNombre.Text.Trim().ToUpper(),
                            txtApellido.Text.Trim().ToUpper(),
                            cbxSexo.Text.Trim().ToUpper(),
                            dtFecha_Nac.Value,
                            txtNum_Documento.Text,
                            txtDireccion.Text.Trim().ToUpper(),
                            txtTelefono.Text,
                            txtEmail.Text.Trim().ToLower(),
                            txtAcceso.Text,
                            txtUsuario.Text.Trim(),
                            txtPassword.Text,
                            txtBuscar.Text.Trim()
                        );
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo) { MensajeOk("Se guardó el registro"); }
                        else { MensajeOk("Se actualizó el registro"); }
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

        private void dataListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                txtIdtrabajador.Text = Convert.ToString(dataListado.CurrentRow.Cells["idtrabajador"].Value);
                txtNombre.Text = Convert.ToString(dataListado.CurrentRow.Cells["nombre"].Value);
                txtApellido.Text = Convert.ToString(dataListado.CurrentRow.Cells["apellidos"].Value);
                cbxSexo.Text = Convert.ToString(dataListado.CurrentRow.Cells["sexo"].Value);
                this.dtFecha_Nac.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["fecha_nac"].Value);
                txtNum_Documento.Text = Convert.ToString(dataListado.CurrentRow.Cells["num_documento"].Value);
                txtTelefono.Text = Convert.ToString(dataListado.CurrentRow.Cells["Telefono"].Value);
                txtDireccion.Text = Convert.ToString(dataListado.CurrentRow.Cells["direccion"].Value);
                txtEmail.Text = Convert.ToString(dataListado.CurrentRow.Cells["email"].Value);
                txtUsuario.Text = Convert.ToString(dataListado.CurrentRow.Cells["usuario"].Value);
                txtAcceso.Text = Convert.ToString(dataListado.CurrentRow.Cells["Acceso"].Value);
                txtPassword.Text = Convert.ToString(dataListado.CurrentRow.Cells["password"].Value);


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
            if (txtIdtrabajador.Text.Equals(""))
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.txtIdtrabajador.ReadOnly = true;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            Botones();
            Limpiar();
            Habilitar(false);
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
                            rpta = NTrabajador.Eliminar(Convert.ToInt32(Codigo));
                            if (rpta.Equals("OK"))
                            {
                                MensajeOk("Se borraron los registros");
                            }
                            else { MensajeError(rpta); }
                        }
                    }
                  
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
            this.BuscarNum_Documento();
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNum_Documento();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{

        //}

        private void ttMensaje_Popup(object sender, PopupEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
