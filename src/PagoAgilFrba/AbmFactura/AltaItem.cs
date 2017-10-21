using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmFactura
{
    public partial class AltaItem : Form
    {
        AltaFactura formPadre;

        public AltaItem(AltaFactura form)
        {
            InitializeComponent();
            this.formPadre = form;
        }

        private void txtCancelar_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void txtAgregar_Click(object sender, EventArgs e)
        {

            if(txtMonto.Text == "" || txtCantidad.Text == "")
            {
                MessageBox.Show("Debe completar todos los campos", "Error", MessageBoxButtons.OK);
                return;
            }

            var monto = Int32.Parse(txtMonto.Text);
            var cantidad = Int32.Parse(txtCantidad.Text);

            formPadre.agregarItem(monto, cantidad);
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

        private void AltaItem_Load(object sender, EventArgs e)
        {
            txtCantidad.KeyPress += new KeyPressEventHandler(keypressed);
            txtMonto.KeyPress += new KeyPressEventHandler(keypressed);
        }
    }
}
