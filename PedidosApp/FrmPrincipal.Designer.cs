using System.Data.Common;

namespace PedidosApp
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMenu = new System.Windows.Forms.Panel();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.btnTrabajadores = new FontAwesome.Sharp.IconButton();
            this.btnProovedores = new FontAwesome.Sharp.IconButton();
            this.btnPresentacion = new FontAwesome.Sharp.IconButton();
            this.btnIngresos = new FontAwesome.Sharp.IconButton();
            this.btnClientes = new FontAwesome.Sharp.IconButton();
            this.btnCategorias = new FontAwesome.Sharp.IconButton();
            this.btnArticulos = new FontAwesome.Sharp.IconButton();
            this.btnDashboard = new FontAwesome.Sharp.IconButton();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.PictureBox();
            this.panelTittleBar = new System.Windows.Forms.Panel();
            this.btnMinimized = new FontAwesome.Sharp.IconButton();
            this.btnMaximize = new FontAwesome.Sharp.IconButton();
            this.btnExit = new FontAwesome.Sharp.IconButton();
            this.lblTitleChildForm = new System.Windows.Forms.Label();
            this.iconCurrentChildForm = new FontAwesome.Sharp.IconPictureBox();
            this.panelShadow = new System.Windows.Forms.Panel();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).BeginInit();
            this.panelTittleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panelMenu.Controls.Add(this.iconButton1);
            this.panelMenu.Controls.Add(this.btnTrabajadores);
            this.panelMenu.Controls.Add(this.btnProovedores);
            this.panelMenu.Controls.Add(this.btnPresentacion);
            this.panelMenu.Controls.Add(this.btnIngresos);
            this.panelMenu.Controls.Add(this.btnClientes);
            this.panelMenu.Controls.Add(this.btnCategorias);
            this.panelMenu.Controls.Add(this.btnArticulos);
            this.panelMenu.Controls.Add(this.btnDashboard);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(4);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(300, 853);
            this.panelMenu.TabIndex = 0;
            // 
            // iconButton1
            // 
            this.iconButton1.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton1.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.PersonChalkboard;
            this.iconButton1.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.Location = new System.Drawing.Point(0, 770);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(300, 75);
            this.iconButton1.TabIndex = 9;
            this.iconButton1.Text = "Trabajadores";
            this.iconButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = true;
            // 
            // btnTrabajadores
            // 
            this.btnTrabajadores.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTrabajadores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrabajadores.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrabajadores.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnTrabajadores.IconChar = FontAwesome.Sharp.IconChar.PersonChalkboard;
            this.btnTrabajadores.IconColor = System.Drawing.Color.Gainsboro;
            this.btnTrabajadores.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTrabajadores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTrabajadores.Location = new System.Drawing.Point(0, 695);
            this.btnTrabajadores.Name = "btnTrabajadores";
            this.btnTrabajadores.Size = new System.Drawing.Size(300, 75);
            this.btnTrabajadores.TabIndex = 8;
            this.btnTrabajadores.Text = "Trabajadores";
            this.btnTrabajadores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTrabajadores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTrabajadores.UseVisualStyleBackColor = true;
            this.btnTrabajadores.Click += new System.EventHandler(this.btnTrabajadores_Click);
            // 
            // btnProovedores
            // 
            this.btnProovedores.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProovedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProovedores.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProovedores.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnProovedores.IconChar = FontAwesome.Sharp.IconChar.StoreAltSlash;
            this.btnProovedores.IconColor = System.Drawing.Color.Gainsboro;
            this.btnProovedores.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnProovedores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProovedores.Location = new System.Drawing.Point(0, 620);
            this.btnProovedores.Name = "btnProovedores";
            this.btnProovedores.Size = new System.Drawing.Size(300, 75);
            this.btnProovedores.TabIndex = 7;
            this.btnProovedores.Text = "Proovedores";
            this.btnProovedores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProovedores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProovedores.UseVisualStyleBackColor = true;
            this.btnProovedores.Click += new System.EventHandler(this.btnProovedores_Click);
            // 
            // btnPresentacion
            // 
            this.btnPresentacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPresentacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPresentacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPresentacion.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnPresentacion.IconChar = FontAwesome.Sharp.IconChar.Weight;
            this.btnPresentacion.IconColor = System.Drawing.Color.Gainsboro;
            this.btnPresentacion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPresentacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPresentacion.Location = new System.Drawing.Point(0, 545);
            this.btnPresentacion.Name = "btnPresentacion";
            this.btnPresentacion.Size = new System.Drawing.Size(300, 75);
            this.btnPresentacion.TabIndex = 6;
            this.btnPresentacion.Text = "Presentacion Articulos";
            this.btnPresentacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPresentacion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPresentacion.UseVisualStyleBackColor = true;
            this.btnPresentacion.Click += new System.EventHandler(this.btnPresentacion_Click);
            // 
            // btnIngresos
            // 
            this.btnIngresos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnIngresos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresos.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnIngresos.IconChar = FontAwesome.Sharp.IconChar.Shopware;
            this.btnIngresos.IconColor = System.Drawing.Color.Gainsboro;
            this.btnIngresos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnIngresos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIngresos.Location = new System.Drawing.Point(0, 470);
            this.btnIngresos.Name = "btnIngresos";
            this.btnIngresos.Size = new System.Drawing.Size(300, 75);
            this.btnIngresos.TabIndex = 5;
            this.btnIngresos.Text = "Ingresos Almacen";
            this.btnIngresos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIngresos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIngresos.UseVisualStyleBackColor = true;
            this.btnIngresos.Click += new System.EventHandler(this.btnIngresos_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientes.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnClientes.IconChar = FontAwesome.Sharp.IconChar.ContactBook;
            this.btnClientes.IconColor = System.Drawing.Color.Gainsboro;
            this.btnClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.Location = new System.Drawing.Point(0, 395);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(300, 75);
            this.btnClientes.TabIndex = 4;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnCategorias
            // 
            this.btnCategorias.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCategorias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategorias.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategorias.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCategorias.IconChar = FontAwesome.Sharp.IconChar.CubesStacked;
            this.btnCategorias.IconColor = System.Drawing.Color.Gainsboro;
            this.btnCategorias.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCategorias.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategorias.Location = new System.Drawing.Point(0, 320);
            this.btnCategorias.Name = "btnCategorias";
            this.btnCategorias.Size = new System.Drawing.Size(300, 75);
            this.btnCategorias.TabIndex = 3;
            this.btnCategorias.Text = "Categorias";
            this.btnCategorias.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategorias.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCategorias.UseVisualStyleBackColor = true;
            this.btnCategorias.Click += new System.EventHandler(this.btnCategorias_Click);
            // 
            // btnArticulos
            // 
            this.btnArticulos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnArticulos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArticulos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArticulos.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnArticulos.IconChar = FontAwesome.Sharp.IconChar.Tags;
            this.btnArticulos.IconColor = System.Drawing.Color.Gainsboro;
            this.btnArticulos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnArticulos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnArticulos.Location = new System.Drawing.Point(0, 245);
            this.btnArticulos.Name = "btnArticulos";
            this.btnArticulos.Size = new System.Drawing.Size(300, 75);
            this.btnArticulos.TabIndex = 2;
            this.btnArticulos.Text = "Articulos";
            this.btnArticulos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnArticulos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnArticulos.UseVisualStyleBackColor = true;
            this.btnArticulos.Click += new System.EventHandler(this.btnArticulos_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnDashboard.IconChar = FontAwesome.Sharp.IconChar.ChartBar;
            this.btnDashboard.IconColor = System.Drawing.Color.Gainsboro;
            this.btnDashboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(0, 170);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(300, 75);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.btnHome);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(300, 170);
            this.panelLogo.TabIndex = 0;
            // 
            // btnHome
            // 
            this.btnHome.Image = global::PedidosApp.Properties.Resources._296280812;
            this.btnHome.Location = new System.Drawing.Point(63, 5);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(170, 165);
            this.btnHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnHome.TabIndex = 0;
            this.btnHome.TabStop = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // panelTittleBar
            // 
            this.panelTittleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.panelTittleBar.Controls.Add(this.btnMinimized);
            this.panelTittleBar.Controls.Add(this.btnMaximize);
            this.panelTittleBar.Controls.Add(this.btnExit);
            this.panelTittleBar.Controls.Add(this.lblTitleChildForm);
            this.panelTittleBar.Controls.Add(this.iconCurrentChildForm);
            this.panelTittleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTittleBar.Location = new System.Drawing.Point(300, 0);
            this.panelTittleBar.Name = "panelTittleBar";
            this.panelTittleBar.Size = new System.Drawing.Size(978, 90);
            this.panelTittleBar.TabIndex = 1;
            this.panelTittleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTittleBar_MouseDown);
            // 
            // btnMinimized
            // 
            this.btnMinimized.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimized.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimized.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnMinimized.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.btnMinimized.IconColor = System.Drawing.Color.Gainsboro;
            this.btnMinimized.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMinimized.IconSize = 40;
            this.btnMinimized.Location = new System.Drawing.Point(834, 12);
            this.btnMinimized.Name = "btnMinimized";
            this.btnMinimized.Size = new System.Drawing.Size(40, 28);
            this.btnMinimized.TabIndex = 4;
            this.btnMinimized.UseVisualStyleBackColor = true;
            this.btnMinimized.Click += new System.EventHandler(this.btnMinimized_Click);
            // 
            // btnMaximize
            // 
            this.btnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximize.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnMaximize.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            this.btnMaximize.IconColor = System.Drawing.Color.Gainsboro;
            this.btnMaximize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMaximize.IconSize = 40;
            this.btnMaximize.Location = new System.Drawing.Point(880, 12);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(40, 28);
            this.btnMaximize.TabIndex = 3;
            this.btnMaximize.UseVisualStyleBackColor = true;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnExit.IconChar = FontAwesome.Sharp.IconChar.Remove;
            this.btnExit.IconColor = System.Drawing.Color.Gainsboro;
            this.btnExit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExit.IconSize = 40;
            this.btnExit.Location = new System.Drawing.Point(926, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(40, 28);
            this.btnExit.TabIndex = 2;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblTitleChildForm
            // 
            this.lblTitleChildForm.AutoSize = true;
            this.lblTitleChildForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleChildForm.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblTitleChildForm.Location = new System.Drawing.Point(101, 28);
            this.lblTitleChildForm.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.lblTitleChildForm.Name = "lblTitleChildForm";
            this.lblTitleChildForm.Size = new System.Drawing.Size(57, 25);
            this.lblTitleChildForm.TabIndex = 1;
            this.lblTitleChildForm.Text = "Inicio";
            // 
            // iconCurrentChildForm
            // 
            this.iconCurrentChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.iconCurrentChildForm.ForeColor = System.Drawing.Color.MediumPurple;
            this.iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.House;
            this.iconCurrentChildForm.IconColor = System.Drawing.Color.MediumPurple;
            this.iconCurrentChildForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconCurrentChildForm.IconSize = 40;
            this.iconCurrentChildForm.Location = new System.Drawing.Point(38, 28);
            this.iconCurrentChildForm.Name = "iconCurrentChildForm";
            this.iconCurrentChildForm.Size = new System.Drawing.Size(43, 40);
            this.iconCurrentChildForm.TabIndex = 0;
            this.iconCurrentChildForm.TabStop = false;
            // 
            // panelShadow
            // 
            this.panelShadow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(24)))), ((int)(((byte)(58)))));
            this.panelShadow.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelShadow.Location = new System.Drawing.Point(300, 90);
            this.panelShadow.Name = "panelShadow";
            this.panelShadow.Size = new System.Drawing.Size(978, 11);
            this.panelShadow.TabIndex = 2;
            // 
            // panelDesktop
            // 
            this.panelDesktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(300, 101);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(978, 752);
            this.panelDesktop.TabIndex = 3;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 853);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelShadow);
            this.Controls.Add(this.panelTittleBar);
            this.Controls.Add(this.panelMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPrincipal";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).EndInit();
            this.panelTittleBar.ResumeLayout(false);
            this.panelTittleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private FontAwesome.Sharp.IconButton btnDashboard;
        private System.Windows.Forms.Panel panelLogo;
        private FontAwesome.Sharp.IconButton btnTrabajadores;
        private FontAwesome.Sharp.IconButton btnProovedores;
        private FontAwesome.Sharp.IconButton btnPresentacion;
        private FontAwesome.Sharp.IconButton btnIngresos;
        private FontAwesome.Sharp.IconButton btnClientes;
        private FontAwesome.Sharp.IconButton btnCategorias;
        private FontAwesome.Sharp.IconButton btnArticulos;
        private System.Windows.Forms.PictureBox btnHome;
        private System.Windows.Forms.Panel panelTittleBar;
        private System.Windows.Forms.Panel panelShadow;
        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.Label lblTitleChildForm;
        private FontAwesome.Sharp.IconPictureBox iconCurrentChildForm;
        private FontAwesome.Sharp.IconButton btnMinimized;
        private FontAwesome.Sharp.IconButton btnMaximize;
        private FontAwesome.Sharp.IconButton btnExit;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}