using PagoAgilFrba.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.RegistroPago
{
    public partial class RegistroPago : Form
    {
        public RegistroPago()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarFactura_Click(object sender, EventArgs e)
        {
            var altaRegistroPag = new AltaRegistroPago() { StartPosition = FormStartPosition.CenterParent };
            altaRegistroPag.ShowDialog();
        }

        private void btnSelectCliente_Click(object sender, EventArgs e)
        {
            var selectCliente = new BuscadorCliente(this) { StartPosition = FormStartPosition.CenterParent };
            selectCliente.ShowDialog();
        }

        public void setCliente(string dni)
        {
            txtCliente.Text = dni;
        }
    }
}
