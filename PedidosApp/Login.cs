using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace PedidosApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            NLogin login = new NLogin();
            DataTable dt = new DataTable();
            dt = NLogin.Ingresar(txtUsuario.Text, txtPassword.Text);
            if (dt.Rows.Count == 1)
            {
                FrmPrincipal principal = new FrmPrincipal();
                principal.Show();
                this.Hide();
                principal.FormClosed += (s, args) => this.Close();
                MessageBox.Show($"Bienvenido {txtUsuario.Text}", "Se inicio Sesion");
                
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña Incorrecta", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
