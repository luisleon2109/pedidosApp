using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Windows.Media;
using System.Windows.Navigation;
using FontAwesome.Sharp;
using PedidosApp;

namespace PedidosApp
{
    public partial class FrmPrincipal : Form
    {
        //Declaramos campos
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        public string Idtrabajador;
        public string Apellidos;
        public string Nombre;
        public string Acceso;
        //Constructor
        
        public FrmPrincipal()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7,60);
            panelMenu.Controls.Add(leftBorderBtn);
            //Codigo para quitar la barra de titulo del formulario
            this.Text=String.Empty;
            this.ControlBox = false;
            //Para reducir el parpadeo
            this.DoubleBuffered = true;
            //Para evitar perder la barra de windows al maximizar
            //codificamos oslo hasta el area de trabajo
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

        }

        //Estructura para almacenar colores
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172,126,241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
            public static Color color7 = Color.FromArgb(24, 161, 251);
            public static Color color8 = Color.FromArgb(24, 161, 251);
            public static Color color9 = Color.FromArgb(24, 161, 251);
        }
        //Metodos
        private void ActivateButton(object senderBtn, Color color)
        {
            if(senderBtn != null)
            {
                DisableButton();
                //Boton
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign=ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Borde izquierdo del boton
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //Icon del formulario hijo actual
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
                //Titulo del formulario hijo actual
                lblTitleChildForm.Text = currentBtn.Text;



            }
        }
        private void DisableButton()
        {
            if(currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
        //Creamos formulario hijo y mostramos el titulo en la barra de titulo
        private void OpenChildForm(Form childForm)
        {
            try
            {


                if (currentChildForm != null)
                {
                    //Abrimos solo un formulario
                    currentChildForm.Close();

                }
                currentChildForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                panelDesktop.Controls.Add(childForm);
                childForm.Show();
                lblTitleChildForm.Text = childForm.Text;
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
}



        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            //OpenChildForm(new Dashboard());
        }

        private void btnArticulos_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(FrmArticulo.GetInstancia());
            //OpenChildForm(new FrmArticulo());
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm(new FrmCategoria());
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            //OpenChildForm(new FrmCliente());
        }

        private void btnIngresos_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            OpenChildForm(FrmIngreso.GetInstancia());
        }

        private void btnPresentacion_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            OpenChildForm(new FrmPresentacion());
        }

        private void btnProovedores_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color7);
            OpenChildForm(new FrmProveedor());
        }

        private void btnTrabajadores_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color8);
            OpenChildForm(new FrmTrabajador());
        }


        //private void btnVentas_Click(object sender, EventArgs e)
        //{
        //    ActivateButton(sender, RGBColors.color9);
        //    //OpenChildForm(FrmVenta.GetInstancia());
        //}
        private void btnHome_Click(object sender, EventArgs e)
        {
            //currentChildForm.Close();
            Reset();

        }
        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.MediumPurple;
            lblTitleChildForm.Text = "Inicio";
        }
        //Codigo para arrastrar el formulario en importar libreria system
        //Runtime.IteropServices
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTittleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Maximized;
        }

        private void btnMinimized_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
