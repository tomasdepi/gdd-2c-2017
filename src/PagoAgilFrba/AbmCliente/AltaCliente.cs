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
    public partial class AltaCliente : Form
    {
        private RepoCliente repo;

        public AltaCliente()
        {
            InitializeComponent();
            this.repo = new RepoCliente();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AltaCliente_Load(object sender, EventArgs e)
        {
            dateFechaNac.Format = DateTimePickerFormat.Custom;
            dateFechaNac.CustomFormat = "yyyyy-MM-dd";

            txtDni.KeyPress += new KeyPressEventHandler(keypressed);
            txtTelefono.KeyPress += new KeyPressEventHandler(keypressed);
            txtCodigoPostal.KeyPress += new KeyPressEventHandler(keypressed);
        }

        private void alertNotAllFieldsCompleted()
        {
            MessageBox.Show("Debe completar todos los campos.", "Error", MessageBoxButtons.OK);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
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
            if (!verificarMail(txtMail.Text)) {
                MessageBox.Show("El mail ingresado no es valido", "Error", MessageBoxButtons.OK);
                return; }

            repo.altaCliente(clie);

            MessageBox.Show("Cliente creado con exito.", "Alta Cliente", MessageBoxButtons.OK);
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
    }
}
