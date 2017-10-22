namespace PagoAgilFrba.Rendicion
{
    partial class RendicionPago
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
            this.dateFechaRendicion = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblComision = new System.Windows.Forms.Label();
            this.upDownPorcentajeComision = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCantFacturas = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEmpresa = new System.Windows.Forms.TextBox();
            this.btnSelectEmpresa = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lblImporteTotal = new System.Windows.Forms.Label();
            this.gridFacturas = new System.Windows.Forms.DataGridView();
            this.numFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBuscarFacturas = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.upDownPorcentajeComision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFacturas)).BeginInit();
            this.SuspendLayout();
            // 
            // dateFechaRendicion
            // 
            this.dateFechaRendicion.Location = new System.Drawing.Point(137, 15);
            this.dateFechaRendicion.Name = "dateFechaRendicion";
            this.dateFechaRendicion.Size = new System.Drawing.Size(200, 20);
            this.dateFechaRendicion.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha Rendicion:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Comision:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Porcentaje Comision:";
            // 
            // lblComision
            // 
            this.lblComision.AutoSize = true;
            this.lblComision.Location = new System.Drawing.Point(134, 52);
            this.lblComision.Name = "lblComision";
            this.lblComision.Size = new System.Drawing.Size(16, 13);
            this.lblComision.TabIndex = 4;
            this.lblComision.Text = "---";
            // 
            // upDownPorcentajeComision
            // 
            this.upDownPorcentajeComision.Location = new System.Drawing.Point(137, 83);
            this.upDownPorcentajeComision.Name = "upDownPorcentajeComision";
            this.upDownPorcentajeComision.Size = new System.Drawing.Size(120, 20);
            this.upDownPorcentajeComision.TabIndex = 5;
            this.upDownPorcentajeComision.ValueChanged += new System.EventHandler(this.upDownPorcentajeComision_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Cantidad Facturas:";
            // 
            // lblCantFacturas
            // 
            this.lblCantFacturas.AutoSize = true;
            this.lblCantFacturas.Location = new System.Drawing.Point(134, 120);
            this.lblCantFacturas.Name = "lblCantFacturas";
            this.lblCantFacturas.Size = new System.Drawing.Size(16, 13);
            this.lblCantFacturas.TabIndex = 7;
            this.lblCantFacturas.Text = "---";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Empresa:";
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.Location = new System.Drawing.Point(131, 153);
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.ReadOnly = true;
            this.txtEmpresa.Size = new System.Drawing.Size(100, 20);
            this.txtEmpresa.TabIndex = 9;
            // 
            // btnSelectEmpresa
            // 
            this.btnSelectEmpresa.Location = new System.Drawing.Point(237, 151);
            this.btnSelectEmpresa.Name = "btnSelectEmpresa";
            this.btnSelectEmpresa.Size = new System.Drawing.Size(75, 23);
            this.btnSelectEmpresa.TabIndex = 10;
            this.btnSelectEmpresa.Text = "Seleccionar";
            this.btnSelectEmpresa.UseVisualStyleBackColor = true;
            this.btnSelectEmpresa.Click += new System.EventHandler(this.btnSelectEmpresa_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Importe Total:";
            // 
            // lblImporteTotal
            // 
            this.lblImporteTotal.AutoSize = true;
            this.lblImporteTotal.Location = new System.Drawing.Point(128, 193);
            this.lblImporteTotal.Name = "lblImporteTotal";
            this.lblImporteTotal.Size = new System.Drawing.Size(35, 13);
            this.lblImporteTotal.TabIndex = 12;
            this.lblImporteTotal.Text = "label7";
            // 
            // gridFacturas
            // 
            this.gridFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFacturas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numFactura,
            this.importe});
            this.gridFacturas.Location = new System.Drawing.Point(381, 12);
            this.gridFacturas.Name = "gridFacturas";
            this.gridFacturas.Size = new System.Drawing.Size(253, 211);
            this.gridFacturas.TabIndex = 13;
            // 
            // numFactura
            // 
            this.numFactura.HeaderText = "Numero Factura";
            this.numFactura.Name = "numFactura";
            this.numFactura.ReadOnly = true;
            // 
            // importe
            // 
            this.importe.HeaderText = "Importe";
            this.importe.Name = "importe";
            this.importe.ReadOnly = true;
            // 
            // btnBuscarFacturas
            // 
            this.btnBuscarFacturas.Location = new System.Drawing.Point(436, 256);
            this.btnBuscarFacturas.Name = "btnBuscarFacturas";
            this.btnBuscarFacturas.Size = new System.Drawing.Size(184, 23);
            this.btnBuscarFacturas.TabIndex = 14;
            this.btnBuscarFacturas.Text = "Buscar Facturas para el Mes";
            this.btnBuscarFacturas.UseVisualStyleBackColor = true;
            this.btnBuscarFacturas.Click += new System.EventHandler(this.btnBuscarFacturas_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(23, 256);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(185, 23);
            this.btnAceptar.TabIndex = 15;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(231, 256);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(184, 23);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // RendicionPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 295);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnBuscarFacturas);
            this.Controls.Add(this.gridFacturas);
            this.Controls.Add(this.lblImporteTotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSelectEmpresa);
            this.Controls.Add(this.txtEmpresa);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblCantFacturas);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.upDownPorcentajeComision);
            this.Controls.Add(this.lblComision);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateFechaRendicion);
            this.Name = "RendicionPago";
            this.Text = "Rendicion Facturas";
            ((System.ComponentModel.ISupportInitialize)(this.upDownPorcentajeComision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFacturas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateFechaRendicion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblComision;
        private System.Windows.Forms.NumericUpDown upDownPorcentajeComision;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCantFacturas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEmpresa;
        private System.Windows.Forms.Button btnSelectEmpresa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblImporteTotal;
        private System.Windows.Forms.DataGridView gridFacturas;
        private System.Windows.Forms.DataGridViewTextBoxColumn numFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn importe;
        private System.Windows.Forms.Button btnBuscarFacturas;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}