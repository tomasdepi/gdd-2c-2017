namespace PagoAgilFrba.RegistroPago
{
    partial class RegistroPago
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
            this.btnAgregarFactura = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.gridFacturas = new System.Windows.Forms.DataGridView();
            this.numFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRegistrarPago = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.btnSelectCliente = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboFormaPago = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblImporteTotal = new System.Windows.Forms.Label();
            this.btnEliminarFactura = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSucursal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridFacturas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAgregarFactura
            // 
            this.btnAgregarFactura.Location = new System.Drawing.Point(483, 250);
            this.btnAgregarFactura.Name = "btnAgregarFactura";
            this.btnAgregarFactura.Size = new System.Drawing.Size(114, 23);
            this.btnAgregarFactura.TabIndex = 0;
            this.btnAgregarFactura.Text = "Agregar Factura";
            this.btnAgregarFactura.UseVisualStyleBackColor = true;
            this.btnAgregarFactura.Click += new System.EventHandler(this.btnAgregarFactura_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(95, 320);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(106, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // gridFacturas
            // 
            this.gridFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFacturas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numFactura,
            this.importe});
            this.gridFacturas.Location = new System.Drawing.Point(328, 14);
            this.gridFacturas.Name = "gridFacturas";
            this.gridFacturas.Size = new System.Drawing.Size(269, 230);
            this.gridFacturas.TabIndex = 2;
            // 
            // numFactura
            // 
            this.numFactura.HeaderText = "Num Factura";
            this.numFactura.Name = "numFactura";
            this.numFactura.ReadOnly = true;
            // 
            // importe
            // 
            this.importe.HeaderText = "Importe";
            this.importe.Name = "importe";
            this.importe.ReadOnly = true;
            // 
            // btnRegistrarPago
            // 
            this.btnRegistrarPago.Location = new System.Drawing.Point(65, 194);
            this.btnRegistrarPago.Name = "btnRegistrarPago";
            this.btnRegistrarPago.Size = new System.Drawing.Size(161, 23);
            this.btnRegistrarPago.TabIndex = 3;
            this.btnRegistrarPago.Text = "Registrar Pago";
            this.btnRegistrarPago.UseVisualStyleBackColor = true;
            this.btnRegistrarPago.Click += new System.EventHandler(this.btnRegistrarPago_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Cliente:";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(85, 16);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(141, 20);
            this.txtCliente.TabIndex = 5;
            // 
            // btnSelectCliente
            // 
            this.btnSelectCliente.Location = new System.Drawing.Point(232, 14);
            this.btnSelectCliente.Name = "btnSelectCliente";
            this.btnSelectCliente.Size = new System.Drawing.Size(75, 23);
            this.btnSelectCliente.TabIndex = 6;
            this.btnSelectCliente.Text = "Seleccionar";
            this.btnSelectCliente.UseVisualStyleBackColor = true;
            this.btnSelectCliente.Click += new System.EventHandler(this.btnSelectCliente_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Forma Pago:";
            // 
            // comboFormaPago
            // 
            this.comboFormaPago.FormattingEnabled = true;
            this.comboFormaPago.Items.AddRange(new object[] {
            "Efectivo",
            "Cheque",
            "Tarjeta Debito",
            "Tarjeta Credito"});
            this.comboFormaPago.Location = new System.Drawing.Point(85, 58);
            this.comboFormaPago.Name = "comboFormaPago";
            this.comboFormaPago.Size = new System.Drawing.Size(141, 21);
            this.comboFormaPago.TabIndex = 8;
            this.comboFormaPago.SelectedIndexChanged += new System.EventHandler(this.comboFormaPago_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(65, 223);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(161, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Importe Total:";
            // 
            // lblImporteTotal
            // 
            this.lblImporteTotal.AutoSize = true;
            this.lblImporteTotal.Location = new System.Drawing.Point(91, 103);
            this.lblImporteTotal.Name = "lblImporteTotal";
            this.lblImporteTotal.Size = new System.Drawing.Size(13, 13);
            this.lblImporteTotal.TabIndex = 11;
            this.lblImporteTotal.Text = "0";
            // 
            // btnEliminarFactura
            // 
            this.btnEliminarFactura.Location = new System.Drawing.Point(328, 250);
            this.btnEliminarFactura.Name = "btnEliminarFactura";
            this.btnEliminarFactura.Size = new System.Drawing.Size(114, 23);
            this.btnEliminarFactura.TabIndex = 12;
            this.btnEliminarFactura.Text = "Eliminar Factura";
            this.btnEliminarFactura.UseVisualStyleBackColor = true;
            this.btnEliminarFactura.Click += new System.EventHandler(this.btnEliminarFactura_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Sucursal:";
            // 
            // lblSucursal
            // 
            this.lblSucursal.AutoSize = true;
            this.lblSucursal.Location = new System.Drawing.Point(82, 138);
            this.lblSucursal.Name = "lblSucursal";
            this.lblSucursal.Size = new System.Drawing.Size(35, 13);
            this.lblSucursal.TabIndex = 14;
            this.lblSucursal.Text = "label5";
            // 
            // RegistroPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 293);
            this.Controls.Add(this.lblSucursal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnEliminarFactura);
            this.Controls.Add(this.lblImporteTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.comboFormaPago);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSelectCliente);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRegistrarPago);
            this.Controls.Add(this.gridFacturas);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAgregarFactura);
            this.Name = "RegistroPago";
            this.Text = "RegistroPago";
            this.Load += new System.EventHandler(this.RegistroPago_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridFacturas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgregarFactura;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridView gridFacturas;
        private System.Windows.Forms.DataGridViewTextBoxColumn numFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn importe;
        private System.Windows.Forms.Button btnRegistrarPago;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Button btnSelectCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboFormaPago;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblImporteTotal;
        private System.Windows.Forms.Button btnEliminarFactura;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSucursal;
    }
}