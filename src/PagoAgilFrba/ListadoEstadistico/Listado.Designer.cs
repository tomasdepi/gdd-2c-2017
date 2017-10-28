namespace PagoAgilFrba.ListadoEstadistico
{
    partial class Listado
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
            this.label2 = new System.Windows.Forms.Label();
            this.numericAnio = new System.Windows.Forms.NumericUpDown();
            this.comboTrimestre = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboTipoListado = new System.Windows.Forms.ComboBox();
            this.btnGenerarListado = new System.Windows.Forms.Button();
            this.Cancelar = new System.Windows.Forms.Button();
            this.gridListado = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.numericAnio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridListado)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Año:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Trimestre:";
            // 
            // numericAnio
            // 
            this.numericAnio.Location = new System.Drawing.Point(84, 12);
            this.numericAnio.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.numericAnio.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numericAnio.Name = "numericAnio";
            this.numericAnio.Size = new System.Drawing.Size(120, 20);
            this.numericAnio.TabIndex = 3;
            this.numericAnio.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // comboTrimestre
            // 
            this.comboTrimestre.FormattingEnabled = true;
            this.comboTrimestre.Items.AddRange(new object[] {
            "1 Enero - Febrero - Marzo ",
            "2 Abril - Mayo - Junio",
            "3 Julio - Agosto - Septiembre",
            "4 Octubre - Noviembre - Diciembre"});
            this.comboTrimestre.Location = new System.Drawing.Point(84, 45);
            this.comboTrimestre.Name = "comboTrimestre";
            this.comboTrimestre.Size = new System.Drawing.Size(192, 21);
            this.comboTrimestre.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tipo Listado:";
            // 
            // comboTipoListado
            // 
            this.comboTipoListado.FormattingEnabled = true;
            this.comboTipoListado.Items.AddRange(new object[] {
            "Porcentaje mayor de facturas cobradas por empresa",
            "Empresas con mayor monto rendido",
            "Clientes con mas pagos",
            "Clientes con mayor porcentaje de facturas pagadas"});
            this.comboTipoListado.Location = new System.Drawing.Point(28, 104);
            this.comboTipoListado.Name = "comboTipoListado";
            this.comboTipoListado.Size = new System.Drawing.Size(248, 21);
            this.comboTipoListado.TabIndex = 6;
            // 
            // btnGenerarListado
            // 
            this.btnGenerarListado.Location = new System.Drawing.Point(63, 155);
            this.btnGenerarListado.Name = "btnGenerarListado";
            this.btnGenerarListado.Size = new System.Drawing.Size(141, 23);
            this.btnGenerarListado.TabIndex = 7;
            this.btnGenerarListado.Text = "Generar Listado";
            this.btnGenerarListado.UseVisualStyleBackColor = true;
            this.btnGenerarListado.Click += new System.EventHandler(this.btnGenerarListado_Click);
            // 
            // Cancelar
            // 
            this.Cancelar.Location = new System.Drawing.Point(62, 184);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(142, 23);
            this.Cancelar.TabIndex = 8;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = true;
            this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // gridListado
            // 
            this.gridListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridListado.Location = new System.Drawing.Point(302, 12);
            this.gridListado.Name = "gridListado";
            this.gridListado.Size = new System.Drawing.Size(413, 232);
            this.gridListado.TabIndex = 9;
            // 
            // Listado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 256);
            this.Controls.Add(this.gridListado);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.btnGenerarListado);
            this.Controls.Add(this.comboTipoListado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboTrimestre);
            this.Controls.Add(this.numericAnio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Listado";
            this.Text = "Listado Estadistico";
            this.Load += new System.EventHandler(this.Listado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericAnio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridListado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericAnio;
        private System.Windows.Forms.ComboBox comboTrimestre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboTipoListado;
        private System.Windows.Forms.Button btnGenerarListado;
        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.DataGridView gridListado;
    }
}