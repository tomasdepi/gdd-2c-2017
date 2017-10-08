namespace PagoAgilFrba.AbmRol
{
    partial class EditarRol
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardarCambios = new System.Windows.Forms.Button();
            this.cbHabilitado = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gridFuncionalidades = new System.Windows.Forms.DataGridView();
            this.check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.funcionalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridFuncionalidades)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(163, 324);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardarCambios
            // 
            this.btnGuardarCambios.Location = new System.Drawing.Point(15, 324);
            this.btnGuardarCambios.Name = "btnGuardarCambios";
            this.btnGuardarCambios.Size = new System.Drawing.Size(111, 23);
            this.btnGuardarCambios.TabIndex = 1;
            this.btnGuardarCambios.Text = "Guardar Cambios";
            this.btnGuardarCambios.UseVisualStyleBackColor = true;
            this.btnGuardarCambios.Click += new System.EventHandler(this.btnGuardarCambios_Click);
            // 
            // cbHabilitado
            // 
            this.cbHabilitado.FormattingEnabled = true;
            this.cbHabilitado.Location = new System.Drawing.Point(128, 17);
            this.cbHabilitado.Name = "cbHabilitado";
            this.cbHabilitado.Size = new System.Drawing.Size(121, 21);
            this.cbHabilitado.TabIndex = 2;
            this.cbHabilitado.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Rol Habilitado:";
            // 
            // gridFuncionalidades
            // 
            this.gridFuncionalidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFuncionalidades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.check,
            this.funcionalidad});
            this.gridFuncionalidades.Location = new System.Drawing.Point(11, 52);
            this.gridFuncionalidades.Name = "gridFuncionalidades";
            this.gridFuncionalidades.Size = new System.Drawing.Size(261, 266);
            this.gridFuncionalidades.TabIndex = 4;
            // 
            // check
            // 
            this.check.HeaderText = "Check";
            this.check.Name = "check";
            this.check.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.check.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // funcionalidad
            // 
            this.funcionalidad.HeaderText = "Funcionalidad";
            this.funcionalidad.Name = "funcionalidad";
            // 
            // EditarRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 359);
            this.Controls.Add(this.gridFuncionalidades);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbHabilitado);
            this.Controls.Add(this.btnGuardarCambios);
            this.Controls.Add(this.btnCancelar);
            this.Name = "EditarRol";
            this.Text = "EditarRol";
            this.Load += new System.EventHandler(this.EditarRol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridFuncionalidades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardarCambios;
        private System.Windows.Forms.ComboBox cbHabilitado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gridFuncionalidades;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check;
        private System.Windows.Forms.DataGridViewTextBoxColumn funcionalidad;
    }
}