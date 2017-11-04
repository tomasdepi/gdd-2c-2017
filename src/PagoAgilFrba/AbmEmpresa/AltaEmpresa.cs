using PagoAgilFrba.Entities;
using PagoAgilFrba.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmEmpresa
{
    public partial class AltaEmpresa : Form
    {
        private RepoEmpresa repo;

        public AltaEmpresa()
        {
            InitializeComponent();
            this.repo = new RepoEmpresa();
        }

        private void txtCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AltaEmpresa_Load(object sender, EventArgs e)
        {
            dateFechaRend.Format = DateTimePickerFormat.Custom;
            dateFechaRend.CustomFormat = "yyyyy-MM-dd";
            
            txtCuit.KeyPress += new KeyPressEventHandler(cuitValidation);
            
        }

        private void alertNotAllFieldsCompleted()
        {
            MessageBox.Show("Debe completar todos los campos.", "Error", MessageBoxButtons.OK);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Empresa empr = new Empresa();
            if (txtCuit.Text == "") { alertNotAllFieldsCompleted(); return; } else empr.cuit = txtCuit.Text;
            if (txtDireccion.Text == "") { alertNotAllFieldsCompleted(); return; } else empr.direccion = txtDireccion.Text;
            if (txtNombre.Text == "") { alertNotAllFieldsCompleted(); return; } else empr.nombre = txtNombre.Text;
            if (txtRubro.Text == "") { alertNotAllFieldsCompleted(); return; } else empr.rubro = txtRubro.Text;
            if (dateFechaRend.Text == "") { alertNotAllFieldsCompleted(); return; } else empr.fechaRendicion = dateFechaRend.Value.Date;

            if (repo.validarExistencia(empr.cuit))
            {
                MessageBox.Show("Ya existe una empresa con ese cuit.", "Error", MessageBoxButtons.OK);
                return;
            }
            else
            {
                repo.altaEmpresa(empr);
                MessageBox.Show("Empresa creada con éxito.", "Alta Empresa", MessageBoxButtons.OK);
                this.Close();
            }

           
        }

        private void onlyNumbers(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void cuitValidation(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
        }

    }
}
