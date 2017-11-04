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

namespace PagoAgilFrba.AbmSucursal
{
    public partial class AltaSucursal : Form
    {
        RepoSucursal repo;

        public AltaSucursal()
        {
            InitializeComponent();
            this.repo = new RepoSucursal();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            Sucursal sucursal = new Sucursal();

            if (txtNombre.Text == "") { alertNotAllFieldsCompleted(); return; } else sucursal.nombre = txtNombre.Text;
            if (txtCodPostal.Text == "") { alertNotAllFieldsCompleted(); return; } else sucursal.codigoPostal = Int32.Parse(txtCodPostal.Text);
            if (txtDireccion.Text == "") { alertNotAllFieldsCompleted(); return; } else sucursal.direccion = txtNombre.Text;

            if (repo.validarExistencia(sucursal.codigoPostal))
            {
                MessageBox.Show("Ya existe una Sucursal con ese codigo Postal", "Error", MessageBoxButtons.OK);
                return;
            }
            else
            {
                repo.AltaSucursal(sucursal);
                MessageBox.Show("Alta de la Sucursal exitosa!!", "Alta Exitosa", MessageBoxButtons.OK);
                this.Close();
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AltaSucursal_Load(object sender, EventArgs e)
        {
            txtCodPostal.KeyPress += onlyNumbers;
        }

        private void onlyNumbers(object sender, KeyPressEventArgs e)
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
