namespace PagoAgilFrba.AbmSucursal
{
    partial class ListadoSucursales
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
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnAltaSucursal = new System.Windows.Forms.Button();
            this.btnEditarSucursal = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodPostal = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLimpiarTabla = new System.Windows.Forms.Button();
            this.gridSucursales = new System.Windows.Forms.DataGridView();
            this.codPostal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.habilitado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSucursales)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(57, 93);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(118, 23);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnAltaSucursal
            // 
            this.btnAltaSucursal.Location = new System.Drawing.Point(23, 181);
            this.btnAltaSucursal.Name = "btnAltaSucursal";
            this.btnAltaSucursal.Size = new System.Drawing.Size(181, 23);
            this.btnAltaSucursal.TabIndex = 1;
            this.btnAltaSucursal.Text = "Alta Sucursal";
            this.btnAltaSucursal.UseVisualStyleBackColor = true;
            this.btnAltaSucursal.Click += new System.EventHandler(this.btnAltaSucursal_Click);
            // 
            // btnEditarSucursal
            // 
            this.btnEditarSucursal.Location = new System.Drawing.Point(23, 210);
            this.btnEditarSucursal.Name = "btnEditarSucursal";
            this.btnEditarSucursal.Size = new System.Drawing.Size(181, 23);
            this.btnEditarSucursal.TabIndex = 2;
            this.btnEditarSucursal.Text = "Editar Sucursal";
            this.btnEditarSucursal.UseVisualStyleBackColor = true;
            this.btnEditarSucursal.Click += new System.EventHandler(this.btnEditarSucursal_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(23, 268);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(181, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Codigo Postal:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nombre: ";
            // 
            // txtCodPostal
            // 
            this.txtCodPostal.Location = new System.Drawing.Point(89, 23);
            this.txtCodPostal.Name = "txtCodPostal";
            this.txtCodPostal.Size = new System.Drawing.Size(117, 20);
            this.txtCodPostal.TabIndex = 6;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(89, 57);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(117, 20);
            this.txtNombre.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLimpiarTabla);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCodPostal);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 162);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // btnLimpiarTabla
            // 
            this.btnLimpiarTabla.Location = new System.Drawing.Point(57, 122);
            this.btnLimpiarTabla.Name = "btnLimpiarTabla";
            this.btnLimpiarTabla.Size = new System.Drawing.Size(118, 23);
            this.btnLimpiarTabla.TabIndex = 9;
            this.btnLimpiarTabla.Text = "Limpiar Tabla";
            this.btnLimpiarTabla.UseVisualStyleBackColor = true;
            this.btnLimpiarTabla.Click += new System.EventHandler(this.btnLimpiarTabla_Click);
            // 
            // gridSucursales
            // 
            this.gridSucursales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSucursales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codPostal,
            this.nombre,
            this.direccion,
            this.habilitado});
            this.gridSucursales.Location = new System.Drawing.Point(262, 24);
            this.gridSucursales.Name = "gridSucursales";
            this.gridSucursales.Size = new System.Drawing.Size(448, 251);
            this.gridSucursales.TabIndex = 9;
            // 
            // codPostal
            // 
            this.codPostal.HeaderText = "Codigo Postal";
            this.codPostal.Name = "codPostal";
            this.codPostal.ReadOnly = true;
            // 
            // nombre
            // 
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // direccion
            // 
            this.direccion.HeaderText = "Direccion";
            this.direccion.Name = "direccion";
            this.direccion.ReadOnly = true;
            // 
            // habilitado
            // 
            this.habilitado.HeaderText = "Habilitado";
            this.habilitado.Name = "habilitado";
            this.habilitado.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 239);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(181, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Habilitar / Deshabilitar Sucursal";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ListadoSucursales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 303);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gridSucursales);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditarSucursal);
            this.Controls.Add(this.btnAltaSucursal);
            this.Name = "ListadoSucursales";
            this.Text = "Listado Sucursales";
            this.Load += new System.EventHandler(this.ListadoSucursales_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSucursales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnAltaSucursal;
        private System.Windows.Forms.Button btnEditarSucursal;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodPostal;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLimpiarTabla;
        private System.Windows.Forms.DataGridView gridSucursales;
        private System.Windows.Forms.DataGridViewTextBoxColumn codPostal;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn habilitado;
        private System.Windows.Forms.Button button1;
    }
}