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
    public partial class EditarSucursal : Form
    {
        int codPostal;
        RepoSucursal repo;

        public EditarSucursal(int codPostal)
        {
            InitializeComponent();
            this.codPostal = codPostal;
            this.repo = new RepoSucursal();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditarSucursal_Load(object sender, EventArgs e)
        {
            lblCodPostal.Text = this.codPostal.ToString();

            Sucursal sucursal = repo.getSucursal(this.codPostal);

            txtDireccion.Text = sucursal.direccion;
            txtNombre.Text = sucursal.nombre;
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            Sucursal sucursal = new Sucursal();

            if (txtNombre.Text == "") { alertNotAllFieldsCompleted(); return; } else sucursal.nombre = txtNombre.Text;
            if (txtDireccion.Text == "") { alertNotAllFieldsCompleted(); return; } else sucursal.direccion = txtDireccion.Text;

            sucursal.codigoPostal = this.codPostal;

            repo.updateSucursal(sucursal);
            MessageBox.Show("Cambios guardados Exitosamente, Cargue la grilla nuevamente para visualizar los cambios", "Alta Exitosa", MessageBoxButtons.OK);
            this.Close();
        
        }

        private void alertNotAllFieldsCompleted()
        {
            MessageBox.Show("Debe completar todos los campos.", "Error", MessageBoxButtons.OK);
        }
    }
}
