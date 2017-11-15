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

namespace PagoAgilFrba.AbmCliente
{
    public partial class EditarCliente : Form
    {
        int dni;
        RepoCliente repo;
        Cliente clienteSinModificar;

        public EditarCliente(int dni)
        {
            InitializeComponent();
            this.dni = dni;
            this.repo = new RepoCliente();
            this.clienteSinModificar = new Cliente();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditarCliente_Load(object sender, EventArgs e)
        {
            txtDni.Text = this.dni.ToString();

            dateFechaNac.Format = DateTimePickerFormat.Custom;
            dateFechaNac.CustomFormat = "yyyy-MM-dd";

            clienteSinModificar = repo.getCliente(this.dni);
            txtApellido.Text = clienteSinModificar.apellido;
            txtNombre.Text = clienteSinModificar.nombre;
            txtDireccion.Text = clienteSinModificar.direccion;
            txtCodigoPostal.Text = clienteSinModificar.codigoPostal;
            txtTelefono.Text = clienteSinModificar.telefono.ToString();
            dateFechaNac.Value = clienteSinModificar.fechaNac;
            txtMail.Text = clienteSinModificar.mail;

            txtDni.KeyPress += new KeyPressEventHandler(keypressed);
            txtTelefono.KeyPress += new KeyPressEventHandler(keypressed);
            txtCodigoPostal.KeyPress += new KeyPressEventHandler(keypressed);
        }

        private void txtGuardar_Click(object sender, EventArgs e)
        {
            Cliente clie = new Cliente();
            if (txtNombre.Text == "") { alertNotAllFieldsCompleted(); return; } else clie.nombre = txtNombre.Text;
            if (txtApellido.Text == "") { alertNotAllFieldsCompleted(); return; } else clie.apellido = txtApellido.Text;
            if (txtTelefono.Text == "") { alertNotAllFieldsCompleted(); return; } else clie.telefono = Int32.Parse(txtTelefono.Text);
            if (txtDireccion.Text == "") { alertNotAllFieldsCompleted(); return; } else clie.direccion = txtDireccion.Text;
            if (txtDni.Text == "") { alertNotAllFieldsCompleted(); return; } else clie.dni = Int32.Parse(txtDni.Text);
            if (txtCodigoPostal.Text == "") { alertNotAllFieldsCompleted(); return; } else clie.codigoPostal = txtCodigoPostal.Text;
            if (dateFechaNac.Text == "") { alertNotAllFieldsCompleted(); return; } else clie.fechaNac = dateFechaNac.Value.Date;
            if (txtMail.Text == "") { alertNotAllFieldsCompleted(); return; } else clie.mail = txtMail.Text;
            if (!verificarMail(txtMail.Text))
            {
                MessageBox.Show("El mail ingresado no es valido", "Error", MessageBoxButtons.OK);
                return;
            }

            if (!clienteSinModificar.mail.Equals(clie.mail) && repo.checkExistingMail(clie.mail))
            {
                MessageBox.Show("Ya existe un usuario con ese Mail.", "Alerta", MessageBoxButtons.OK);
                return;
            }

            repo.updateCliente(clie);

            MessageBox.Show("Cliente Actualizado con exito.", "Alta Cliente", MessageBoxButtons.OK);
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

        private bool verificarMail(string txtMail)
        {
            try
            {
                MailAddress m = new MailAddress(txtMail);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }


        }

        private void txtDni_Click(object sender, EventArgs e)
        {

        }
    }
}