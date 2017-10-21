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
    public partial class ListadoFacturas : Form
    {

        RepoFactura repo;

        public ListadoFacturas()
        {
            InitializeComponent();
            repo = new RepoFactura();
        }

        private void ListadoFacturas_Load(object sender, EventArgs e)
        {
            gridFacturas.MultiSelect = false;
        }

        private void txtCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            gridFacturas.Rows.Clear();
        }

        private void btbAgregarFactura_Click(object sender, EventArgs e)
        {
            var agregarFactura = new AltaFactura() { StartPosition = FormStartPosition.CenterParent };
            agregarFactura.ShowDialog();
        }

        private void btnEditarFactura_Click(object sender, EventArgs e)
        {
            bool estaPaga = gridFacturas.SelectedRows[0].Cells[3].Value.ToString() == "Si";
            if (estaPaga)
            {
                MessageBox.Show("Esa Factura ya esta paga, no puede modificarse", "Error", MessageBoxButtons.OK);
                return;
            }
            else
            {
                DataGridViewRow row = gridFacturas.SelectedRows[0];
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string cliente = txtCliente.Text;
            string numFactura = txtNumFactura.Text;
            int pago = comboPago.SelectedIndex;

            List<Factura> facturas = repo.getFacturas(numFactura, cliente, pago);

            foreach(Factura fact in facturas)
            {
                DataGridViewTextBoxCell cellNumFactura = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cellEmpresa = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cellCliente = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cellPagado = new DataGridViewTextBoxCell();
                cellCliente.Value = fact.cliente;
                cellNumFactura.Value = fact.numero;
                cellEmpresa.Value = fact.empresa;
                cellPagado.Value = fact.pagada;

                DataGridViewRow row = new DataGridViewRow();
                row.Cells.Add(cellNumFactura);
                row.Cells.Add(cellEmpresa);
                row.Cells.Add(cellCliente);
                row.Cells.Add(cellPagado);

                gridFacturas.Rows.Add(row);
            }

        }
    }
}
