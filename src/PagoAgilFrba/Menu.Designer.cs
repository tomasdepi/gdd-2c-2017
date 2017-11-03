namespace PagoAgilFrba
{
    partial class Menu
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboSucursales = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboRol = new System.Windows.Forms.ComboBox();
            this.btnAbmCliente = new System.Windows.Forms.Button();
            this.btnAbmEmpresa = new System.Windows.Forms.Button();
            this.btnAbmSucursal = new System.Windows.Forms.Button();
            this.btnAbmFactura = new System.Windows.Forms.Button();
            this.btnPagoFactura = new System.Windows.Forms.Button();
            this.btnRendiciones = new System.Windows.Forms.Button();
            this.btnDevoluciones = new System.Windows.Forms.Button();
            this.btnListadoEstadistico = new System.Windows.Forms.Button();
            this.btnCerrarSession = new System.Windows.Forms.Button();
            this.btnAbmRol = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bienvenido";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(94, 19);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(45, 16);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sucursal:";
            // 
            // comboSucursales
            // 
            this.comboSucursales.FormattingEnabled = true;
            this.comboSucursales.Location = new System.Drawing.Point(78, 53);
            this.comboSucursales.Name = "comboSucursales";
            this.comboSucursales.Size = new System.Drawing.Size(121, 21);
            this.comboSucursales.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Rol:";
            // 
            // comboRol
            // 
            this.comboRol.FormattingEnabled = true;
            this.comboRol.Location = new System.Drawing.Point(78, 85);
            this.comboRol.Name = "comboRol";
            this.comboRol.Size = new System.Drawing.Size(121, 21);
            this.comboRol.TabIndex = 6;
            this.comboRol.SelectedIndexChanged += new System.EventHandler(this.comboRol_SelectedIndexChanged);
            // 
            // btnAbmCliente
            // 
            this.btnAbmCliente.Location = new System.Drawing.Point(45, 172);
            this.btnAbmCliente.Name = "btnAbmCliente";
            this.btnAbmCliente.Size = new System.Drawing.Size(112, 34);
            this.btnAbmCliente.TabIndex = 7;
            this.btnAbmCliente.Text = "ABM Clientes";
            this.btnAbmCliente.UseVisualStyleBackColor = true;
            this.btnAbmCliente.Click += new System.EventHandler(this.btnAbmCliente_Click);
            // 
            // btnAbmEmpresa
            // 
            this.btnAbmEmpresa.Location = new System.Drawing.Point(163, 172);
            this.btnAbmEmpresa.Name = "btnAbmEmpresa";
            this.btnAbmEmpresa.Size = new System.Drawing.Size(112, 34);
            this.btnAbmEmpresa.TabIndex = 8;
            this.btnAbmEmpresa.Text = "ABM Empresas";
            this.btnAbmEmpresa.UseVisualStyleBackColor = true;
            this.btnAbmEmpresa.Click += new System.EventHandler(this.btnAbmEmpresa_Click);
            // 
            // btnAbmSucursal
            // 
            this.btnAbmSucursal.Location = new System.Drawing.Point(45, 212);
            this.btnAbmSucursal.Name = "btnAbmSucursal";
            this.btnAbmSucursal.Size = new System.Drawing.Size(112, 34);
            this.btnAbmSucursal.TabIndex = 9;
            this.btnAbmSucursal.Text = "ABM Sucursales";
            this.btnAbmSucursal.UseVisualStyleBackColor = true;
            this.btnAbmSucursal.Click += new System.EventHandler(this.btnAbmSucursal_Click);
            // 
            // btnAbmFactura
            // 
            this.btnAbmFactura.Location = new System.Drawing.Point(163, 212);
            this.btnAbmFactura.Name = "btnAbmFactura";
            this.btnAbmFactura.Size = new System.Drawing.Size(112, 34);
            this.btnAbmFactura.TabIndex = 10;
            this.btnAbmFactura.Text = "ABM Facturas";
            this.btnAbmFactura.UseVisualStyleBackColor = true;
            this.btnAbmFactura.Click += new System.EventHandler(this.btnAbmFactura_Click);
            // 
            // btnPagoFactura
            // 
            this.btnPagoFactura.Location = new System.Drawing.Point(45, 252);
            this.btnPagoFactura.Name = "btnPagoFactura";
            this.btnPagoFactura.Size = new System.Drawing.Size(112, 34);
            this.btnPagoFactura.TabIndex = 11;
            this.btnPagoFactura.Text = "Pago Facturas";
            this.btnPagoFactura.UseVisualStyleBackColor = true;
            this.btnPagoFactura.Click += new System.EventHandler(this.btnPagoFactura_Click);
            // 
            // btnRendiciones
            // 
            this.btnRendiciones.Location = new System.Drawing.Point(163, 252);
            this.btnRendiciones.Name = "btnRendiciones";
            this.btnRendiciones.Size = new System.Drawing.Size(112, 34);
            this.btnRendiciones.TabIndex = 12;
            this.btnRendiciones.Text = "Rendiciones";
            this.btnRendiciones.UseVisualStyleBackColor = true;
            this.btnRendiciones.Click += new System.EventHandler(this.btnRendiciones_Click);
            // 
            // btnDevoluciones
            // 
            this.btnDevoluciones.Location = new System.Drawing.Point(45, 292);
            this.btnDevoluciones.Name = "btnDevoluciones";
            this.btnDevoluciones.Size = new System.Drawing.Size(112, 34);
            this.btnDevoluciones.TabIndex = 13;
            this.btnDevoluciones.Text = "Devoluciones";
            this.btnDevoluciones.UseVisualStyleBackColor = true;
            this.btnDevoluciones.Click += new System.EventHandler(this.btnDevoluciones_Click);
            // 
            // btnListadoEstadistico
            // 
            this.btnListadoEstadistico.Location = new System.Drawing.Point(163, 292);
            this.btnListadoEstadistico.Name = "btnListadoEstadistico";
            this.btnListadoEstadistico.Size = new System.Drawing.Size(112, 34);
            this.btnListadoEstadistico.TabIndex = 14;
            this.btnListadoEstadistico.Text = "Listado Estadistico";
            this.btnListadoEstadistico.UseVisualStyleBackColor = true;
            this.btnListadoEstadistico.Click += new System.EventHandler(this.btnListadoEstadistico_Click);
            // 
            // btnCerrarSession
            // 
            this.btnCerrarSession.Location = new System.Drawing.Point(205, 16);
            this.btnCerrarSession.Name = "btnCerrarSession";
            this.btnCerrarSession.Size = new System.Drawing.Size(93, 23);
            this.btnCerrarSession.TabIndex = 15;
            this.btnCerrarSession.Text = "Cerrar Sesion";
            this.btnCerrarSession.UseVisualStyleBackColor = true;
            this.btnCerrarSession.Click += new System.EventHandler(this.btnCerrarSession_Click);
            // 
            // btnAbmRol
            // 
            this.btnAbmRol.Location = new System.Drawing.Point(107, 132);
            this.btnAbmRol.Name = "btnAbmRol";
            this.btnAbmRol.Size = new System.Drawing.Size(112, 34);
            this.btnAbmRol.TabIndex = 16;
            this.btnAbmRol.Text = "ABM Roles";
            this.btnAbmRol.UseVisualStyleBackColor = true;
            this.btnAbmRol.Click += new System.EventHandler(this.btnAbmRol_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 346);
            this.Controls.Add(this.btnAbmRol);
            this.Controls.Add(this.btnCerrarSession);
            this.Controls.Add(this.btnListadoEstadistico);
            this.Controls.Add(this.btnDevoluciones);
            this.Controls.Add(this.btnRendiciones);
            this.Controls.Add(this.btnPagoFactura);
            this.Controls.Add(this.btnAbmFactura);
            this.Controls.Add(this.btnAbmSucursal);
            this.Controls.Add(this.btnAbmEmpresa);
            this.Controls.Add(this.btnAbmCliente);
            this.Controls.Add(this.comboRol);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboSucursales);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.label1);
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboSucursales;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboRol;
        private System.Windows.Forms.Button btnAbmCliente;
        private System.Windows.Forms.Button btnAbmEmpresa;
        private System.Windows.Forms.Button btnAbmSucursal;
        private System.Windows.Forms.Button btnAbmFactura;
        private System.Windows.Forms.Button btnPagoFactura;
        private System.Windows.Forms.Button btnRendiciones;
        private System.Windows.Forms.Button btnDevoluciones;
        private System.Windows.Forms.Button btnListadoEstadistico;
        private System.Windows.Forms.Button btnCerrarSession;
        private System.Windows.Forms.Button btnAbmRol;
    }
}