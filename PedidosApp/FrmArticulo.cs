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
using CapaNegocio;

namespace PedidosApp
{
    public partial class FrmArticulo : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        private static FrmArticulo _Instancia;

        public static FrmArticulo GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmArticulo();

            }
            return _Instancia;
        }

        public void setCategoria(string idcategoria, string nombre)
        {
            this.txtIdcategoria.Text = idcategoria;
            this.txtCategoria.Text = nombre;
        }
        public FrmArticulo()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el nombre del Articulo");
            this.ttMensaje.SetToolTip(this.pxImagen, "Seleccion la imagen del Articulo");
            this.ttMensaje.SetToolTip(this.txtCategoria, "Seleccione la categoria del Articulo");
            this.ttMensaje.SetToolTip(this.cbIdpresentacion, "Seleccione la presentacion del Articulo");

            this.txtIdcategoria.Visible = false;
            this.txtCategoria.ReadOnly = true;
            this.LlenarComboPresentacion();

        }
        //Mostrar Mensaje de confirmacion
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Pedidos App", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Mostrar Mensaje de error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Pedidos App", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //Limpiar todos los controles del formulario
        private void Limpiar()
        {
            this.txtCodigo.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtIdcategoria.Text = string.Empty;
            this.txtCategoria.Text = string.Empty;
            this.txtIdarticulo.Text = string.Empty;
            this.pxImagen.Image = global::PedidosApp.Properties.Resources.file;
        }
        //Habilitar los control del formulario
        private void Habilitar(bool valor)
        {
            this.txtCodigo.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
            this.btnBuscarCategoria.Enabled = valor;
            this.cbIdpresentacion.Enabled = valor;
            this.btnCargar.Enabled = valor;
            this.btnLimpiar.Enabled = valor;
            this.txtIdcategoria.ReadOnly = !valor;
            this.txtCategoria.ReadOnly = !valor;
            this.txtIdarticulo.ReadOnly = !valor;
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
        //Metodo para ocultar columnas
        private void OcultarColumnas()
        {
            if(this.dataListado.Rows.Count > 0)
            {
                this.dataListado.Columns[0].Visible = false;
                this.dataListado.Columns[1].Visible = false;
                this.dataListado.Columns[5].Visible = false;
                this.dataListado.Columns[6].Visible = false;
                this.dataListado.Columns[8].Visible = false;

            }
        }
        //Metodo mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NArticulo.Mostrar();
            this.OcultarColumnas();
            this.lblTotal.Text = "Registros encontrados: " + Convert.ToString(dataListado.Rows.Count);
            this.tabControl1.SelectedIndex = 0;
        }
        //Metodo BuscarNombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NArticulo.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            this.lblTotal.Text = "Registros encontrados: " + Convert.ToString(dataListado.Rows.Count);
        }
        //Poblar la lista de presentaciones
        private void LlenarComboPresentacion()
        {
            cbIdpresentacion.DataSource = NPresentacion.Mostrar();
            cbIdpresentacion.ValueMember = "idpresentacion";
            cbIdpresentacion.DisplayMember = "nombre";

        }

        private void FrmArticulo_Load(object sender, EventArgs e)
        {
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();


        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pxImagen.Image = Image.FromFile(dialog.FileName);

            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.pxImagen.SizeMode =PictureBoxSizeMode.StretchImage;
            this.pxImagen.Image = global::PedidosApp.Properties.Resources.file;
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtCodigo.Focus();
            this.txtIdarticulo.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string rpta = "";
            //    if(this.txtCodigo.Text == string.Empty || this.txtNombre.Text == String.Empty)
            //    {
            //        MensajeError("Falta ingresar algunos datos, seran remarcados");
            //        errorIcono.SetError(txtCodigo, "Ingrese un valor");
            //        errorIcono.SetError(txtNombre, "Ingrese el nombre del articulo");
            //        errorIcono.SetError(txtCategoria, "Seleccione una categoria");
            //    }
            //    else
            //    {
            //        System.IO.MemoryStream ms = new System.IO.MemoryStream();
            //        this.pxImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            //        byte[] imagen = ms.GetBuffer();
            //        if (this.IsNuevo)
            //        {
            //            rpta = NArticulo.Insertar(txtCodigo.Text, txtNombre.Text.Trim().ToUpper(), 
            //                txtDescripcion.Text.Trim(), imagen, Convert.ToInt32(txtIdcategoria.Text), 
            //                Convert.ToInt32(cbIdpresentacion.SelectedValue));
            //        }
            //        else
            //        {
            //            rpta = NArticulo.Editar(Convert.ToInt32(txtIdarticulo.Text),txtCodigo.Text, 
            //                txtNombre.Text.Trim().ToUpper(),txtDescripcion.Text.Trim(), imagen, Convert.ToInt32(txtIdcategoria.Text),
            //                Convert.ToInt32(cbIdpresentacion.SelectedValue));
            //        }
            //        if (rpta.Equals("OK"))
            //        {
            //            if (this.IsNuevo)
            //                MensajeOk("Se guardo el registro");                        
            //            else 
            //                MensajeOk("Se actualizo el registro");
            //        }
            //        else
            //        {
            //            MensajeError(rpta);
            //        }
            //        IsNuevo = false;
            //        IsEditar = false;
            //        Botones();
            //        Limpiar();
            //        Mostrar();

            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message + ex.StackTrace);
            //}
            try
            {
                string rpta = "";
                if (this.txtCodigo.Text == string.Empty || this.txtNombre.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, seran remarcados");
                    errorIcono.SetError(txtCodigo, "Ingrese un valor");
                    errorIcono.SetError(txtNombre, "Ingrese el nombre del articulo");
                    errorIcono.SetError(txtCategoria, "Seleccione una categoria");
                }
                else
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    this.pxImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] imagen = ms.GetBuffer();
                    if (this.IsNuevo)
                    {
                        rpta = NArticulo.Insertar(txtCodigo.Text, txtNombre.Text.Trim().ToUpper(),
                            txtDescripcion.Text.Trim(), imagen, Convert.ToInt32(txtIdcategoria.Text),
                            Convert.ToInt32(cbIdpresentacion.SelectedValue));
                    }
                    else
                    {
                        rpta = NArticulo.Editar(Convert.ToInt32(txtIdarticulo.Text), txtCodigo.Text,
                            txtNombre.Text.Trim().ToUpper(), txtDescripcion.Text.Trim(), imagen,
                            Convert.ToInt32(txtIdcategoria.Text), Convert.ToInt32(cbIdpresentacion.SelectedValue));
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

        private void BtnEditar_Click(object sender, EventArgs e)
        {
 
            
                IsEditar = true;
                Botones();
                Habilitar(true);
            

        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            IsNuevo =false;
            IsEditar=false;
            Botones();
            Limpiar();
            Habilitar(false);
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            txtIdarticulo.Text = Convert.ToString(dataListado.CurrentRow.Cells["idarticulo"].Value);
            txtCodigo.Text = Convert.ToString(dataListado.CurrentRow.Cells["codigo"].Value);
            txtNombre.Text = Convert.ToString(dataListado.CurrentRow.Cells["nombre"].Value);
            txtDescripcion.Text = Convert.ToString(dataListado.CurrentRow.Cells["descripcion"].Value);
            byte[] imagenBuffer = (byte[])dataListado.CurrentRow.Cells["imagen"].Value;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);

            pxImagen.Image = Image.FromStream(ms);
            pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            txtIdcategoria.Text = Convert.ToString(dataListado.CurrentRow.Cells["idcategoria"].Value);
            txtCategoria.Text = Convert.ToString(dataListado.CurrentRow.Cells["categoria"].Value);
            cbIdpresentacion.SelectedValue = Convert.ToString(dataListado.CurrentRow.Cells["idpresentacion"].Value);
            tabControl1.SelectedIndex = 1;
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
                            rpta = NArticulo.Eliminar(Convert.ToInt32(Codigo));
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //Reportes.FrmStockArticulos frm = new Reportes.FrmStockArticulos();
            //frm.Texto = txtBuscar.Text;
            //frm.ShowDialog();
        }

        private void FrmArticulo_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;

        }

        private void btnBuscarCategoria_Click(object sender, EventArgs e)
        {
            FrmVistaCategoria_Articulo form = new FrmVistaCategoria_Articulo();
            form.ShowDialog();
        }

        private void cbIdpresentacion_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        //private void btnNuevo_Click_1(object sender, EventArgs e)
        //{
        //    this.IsNuevo = true;
        //    this.IsEditar = false;
        //    this.Botones();
        //    this.Limpiar();
        //    this.Habilitar(true);
        //    this.txtCodigo.Focus();
        //}
    }
}
