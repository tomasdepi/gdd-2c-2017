namespace PagoAgilFrba.AbmFactura
{
    partial class AltaFactura
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
            this.txtCancelar = new System.Windows.Forms.Button();
            this.txtAceptar = new System.Windows.Forms.Button();
            this.btnAgregarItem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNumFactura = new System.Windows.Forms.TextBox();
            this.dateVencimiento = new System.Windows.Forms.DateTimePicker();
            this.gridItems = new System.Windows.Forms.DataGridView();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEmpresa = new System.Windows.Forms.TextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.btnSelectCliente = new System.Windows.Forms.Button();
            this.btnSelectEmpesa = new System.Windows.Forms.Button();
            this.dateAlta = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCancelar
            // 
            this.txtCancelar.Location = new System.Drawing.Point(83, 264);
            this.txtCancelar.Name = "txtCancelar";
            this.txtCancelar.Size = new System.Drawing.Size(139, 23);
            this.txtCancelar.TabIndex = 0;
            this.txtCancelar.Text = "Cancelar";
            this.txtCancelar.UseVisualStyleBackColor = true;
            this.txtCancelar.Click += new System.EventHandler(this.txtCancelar_Click);
            // 
            // txtAceptar
            // 
            this.txtAceptar.Location = new System.Drawing.Point(83, 235);
            this.txtAceptar.Name = "txtAceptar";
            this.txtAceptar.Size = new System.Drawing.Size(139, 23);
            this.txtAceptar.TabIndex = 1;
            this.txtAceptar.Text = "Aceptar";
            this.txtAceptar.UseVisualStyleBackColor = true;
            this.txtAceptar.Click += new System.EventHandler(this.txtAceptar_Click);
            // 
            // btnAgregarItem
            // 
            this.btnAgregarItem.Location = new System.Drawing.Point(415, 280);
            this.btnAgregarItem.Name = "btnAgregarItem";
            this.btnAgregarItem.Size = new System.Drawing.Size(124, 23);
            this.btnAgregarItem.TabIndex = 2;
            this.btnAgregarItem.Text = "Agregar Item";
            this.btnAgregarItem.UseVisualStyleBackColor = true;
            this.btnAgregarItem.Click += new System.EventHandler(this.btnAgregarItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cliente:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Empresa:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Numero Factura:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Fecha Alta:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Fecha Vencimiento:";
            // 
            // txtNumFactura
            // 
            this.txtNumFactura.Location = new System.Drawing.Point(119, 96);
            this.txtNumFactura.Name = "txtNumFactura";
            this.txtNumFactura.Size = new System.Drawing.Size(200, 20);
            this.txtNumFactura.TabIndex = 10;
            this.txtNumFactura.TextChanged += new System.EventHandler(this.txtNumFactura_TextChanged);
            // 
            // dateVencimiento
            // 
            this.dateVencimiento.Location = new System.Drawing.Point(119, 166);
            this.dateVencimiento.Name = "dateVencimiento";
            this.dateVencimiento.Size = new System.Drawing.Size(200, 20);
            this.dateVencimiento.TabIndex = 12;
            // 
            // gridItems
            // 
            this.gridItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cantidad,
            this.monto});
            this.gridItems.Location = new System.Drawing.Point(351, 20);
            this.gridItems.Name = "gridItems";
            this.gridItems.Size = new System.Drawing.Size(260, 181);
            this.gridItems.TabIndex = 13;
            // 
            // cantidad
            // 
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            // 
            // monto
            // 
            this.monto.HeaderText = "Monto";
            this.monto.Name = "monto";
            this.monto.ReadOnly = true;
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(466, 213);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(100, 20);
            this.txtMonto.TabIndex = 14;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(466, 242);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(100, 20);
            this.txtCantidad.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(393, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Cantidad:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(393, 245);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Monto:";
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.Location = new System.Drawing.Point(119, 57);
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.ReadOnly = true;
            this.txtEmpresa.Size = new System.Drawing.Size(103, 20);
            this.txtEmpresa.TabIndex = 9;
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(119, 20);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(103, 20);
            this.txtCliente.TabIndex = 8;
            // 
            // btnSelectCliente
            // 
            this.btnSelectCliente.Location = new System.Drawing.Point(244, 18);
            this.btnSelectCliente.Name = "btnSelectCliente";
            this.btnSelectCliente.Size = new System.Drawing.Size(75, 23);
            this.btnSelectCliente.TabIndex = 18;
            this.btnSelectCliente.Text = "Seleccionar";
            this.btnSelectCliente.UseVisualStyleBackColor = true;
            this.btnSelectCliente.Click += new System.EventHandler(this.btnSelectCliente_Click);
            // 
            // btnSelectEmpesa
            // 
            this.btnSelectEmpesa.Location = new System.Drawing.Point(244, 55);
            this.btnSelectEmpesa.Name = "btnSelectEmpesa";
            this.btnSelectEmpesa.Size = new System.Drawing.Size(75, 23);
            this.btnSelectEmpesa.TabIndex = 19;
            this.btnSelectEmpesa.Text = "Seleccionar";
            this.btnSelectEmpesa.UseVisualStyleBackColor = true;
            this.btnSelectEmpesa.Click += new System.EventHandler(this.btnSelectEmpesa_Click);
            // 
            // dateAlta
            // 
            this.dateAlta.AutoSize = true;
            this.dateAlta.Location = new System.Drawing.Point(116, 136);
            this.dateAlta.Name = "dateAlta";
            this.dateAlta.Size = new System.Drawing.Size(35, 13);
            this.dateAlta.TabIndex = 20;
            this.dateAlta.Text = "label8";
            // 
            // AltaFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 316);
            this.Controls.Add(this.dateAlta);
            this.Controls.Add(this.btnSelectEmpesa);
            this.Controls.Add(this.btnSelectCliente);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.gridItems);
            this.Controls.Add(this.dateVencimiento);
            this.Controls.Add(this.txtNumFactura);
            this.Controls.Add(this.txtEmpresa);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAgregarItem);
            this.Controls.Add(this.txtAceptar);
            this.Controls.Add(this.txtCancelar);
            this.Name = "AltaFactura";
            this.Text = "Alta Factura";
            this.Load += new System.EventHandler(this.AltaFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button txtCancelar;
        private System.Windows.Forms.Button txtAceptar;
        private System.Windows.Forms.Button btnAgregarItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNumFactura;
        private System.Windows.Forms.DateTimePicker dateVencimiento;
        private System.Windows.Forms.DataGridView gridItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn monto;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEmpresa;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Button btnSelectCliente;
        private System.Windows.Forms.Button btnSelectEmpesa;
        private System.Windows.Forms.Label dateAlta;
    }
}