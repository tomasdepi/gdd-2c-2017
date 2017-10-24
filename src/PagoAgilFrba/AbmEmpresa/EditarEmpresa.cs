using PagoAgilFrba.Entities;
using PagoAgilFrba.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmEmpresa
{
    public partial class EditarEmpresa : Form
    {
        int empresa_id;
        RepoEmpresa repo;

        public EditarEmpresa(int empresa_id)
        {
            InitializeComponent();
            this.empresa_id = empresa_id;
            this.repo = new RepoEmpresa();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditarEmpresa_Load(object sender, EventArgs e)
        {
            txtId.Text = this.empresa_id.ToString();

            dateFechaRend.Format = DateTimePickerFormat.Custom;
            dateFechaRend.CustomFormat = "yyyy-MM-dd";

            Empresa empresa = repo.getEmpresa(this.empresa_id);
            txtCuit.Text = empresa.cuit;
            txtNombre.Text = empresa.nombre;
            txtDireccion.Text = empresa.direccion;
            txtRubro.Text = empresa.rubro;
            dateFechaRend.Value = empresa.fechaRendicion;

            txtId.KeyPress += new KeyPressEventHandler(keypressed);
            txtCuit.KeyPress += new KeyPressEventHandler(keypressed);
        }

        private void txtGuardar_Click(object sender, EventArgs e)
        {
            Empresa empresa = new Empresa();
            if (txtId.Text == "") { alertNotAllFieldsCompleted(); return; } else empresa.id = Int32.Parse(txtId.Text);
            if (txtCuit.Text == "") { alertNotAllFieldsCompleted(); return; } else empresa.cuit = txtCuit.Text;
            if (txtNombre.Text == "") { alertNotAllFieldsCompleted(); return; } else empresa.nombre = txtNombre.Text;
            if (txtDireccion.Text == "") { alertNotAllFieldsCompleted(); return; } else empresa.direccion = txtDireccion.Text;
            if (txtRubro.Text == "") { alertNotAllFieldsCompleted(); return; } else empresa.rubro = txtRubro.Text;
            if (dateFechaRend.Text == "") { alertNotAllFieldsCompleted(); return; } else empresa.fechaRendicion = dateFechaRend.Value.Date;

            repo.updateEmpresa(empresa);

            MessageBox.Show("Empresa actualizada con éxito.", "Alta Empresa", MessageBoxButtons.OK);
            this.Close();

        }

        private void keypressed(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void alertNotAllFieldsCompleted()
        {
            MessageBox.Show("Debe completar todos los campos.", "Error", MessageBoxButtons.OK);
        }


    }

}
