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

namespace PagoAgilFrba.AbmFactura
{
    public partial class EditarFactura : Form
    {
        int numFactura;
        RepoFactura repo;

        public EditarFactura(int numFactura)
        {
            InitializeComponent();
            this.numFactura = numFactura;
            this.repo = new RepoFactura();
        }

        private void onlyNumbers(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void EditarFactura_Load(object sender, EventArgs e)
        {
            lblNumFactura.Text = this.numFactura.ToString();

            txtMonto.KeyPress += onlyNumbers;
            txtCantidad.KeyPress += onlyNumbers;

            List<ItemFactura> items = repo.getItems(numFactura);
            foreach(ItemFactura item in items)
            {
                agregarItem(item.monto, item.cantidad);
            }

            Factura factura = repo.getFactura(this.numFactura);
            txtCliente.Text = factura.cliente.ToString();
            txtEmpresa.Text = factura.empresa;
        }

        private void txtCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminarItem_Click(object sender, EventArgs e)
        {
            if (gridItems.SelectedRows.Count <= 0)
                return;

            DataGridViewRow row = gridItems.SelectedRows[0];
            gridItems.Rows.Remove(row);
        }

        private void btnAgregarItem_Click(object sender, EventArgs e)
        {
            if (txtMonto.Text == "" || txtCantidad.Text == "")
            {
                MessageBox.Show("Debe completar todos los campos", "Error", MessageBoxButtons.OK);
                return;
            }

            var monto = Int32.Parse(txtMonto.Text);
            var cantidad = Int32.Parse(txtCantidad.Text);

            agregarItem(monto, cantidad);
        }

        public void agregarItem(int monto, int cantidad)
        {
            DataGridViewTextBoxCell cellMonto = new DataGridViewTextBoxCell();
            DataGridViewTextBoxCell cellCantidad = new DataGridViewTextBoxCell();
            cellCantidad.Value = cantidad;
            cellMonto.Value = monto;

            DataGridViewRow row = new DataGridViewRow();
            row.Cells.Add(cellMonto);
            row.Cells.Add(cellCantidad);

            gridItems.Rows.Add(row);
        }
    }
}
