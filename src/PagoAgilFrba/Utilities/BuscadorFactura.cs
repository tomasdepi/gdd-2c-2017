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

namespace PagoAgilFrba.Utilities
{
    public partial class BuscadorFactura : Form
    {
        RepoFactura repo;
        BuscadorEntidad buscador;

        public BuscadorFactura(BuscadorEntidad buscador)
        {
            InitializeComponent();
            this.repo = new RepoFactura();
            this.buscador = buscador;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            gridFacturas.Rows.Clear();

            string cliente = txtDniCliente.Text;
            string numFactura = txtNumFactura.Text;

            List<Factura> facturas = repo.getFacturas(numFactura, cliente, 1);

            foreach (Factura fact in facturas)
            {
                DataGridViewTextBoxCell cellNumFactura = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cellEmpresa = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cellCliente = new DataGridViewTextBoxCell();
                cellCliente.Value = fact.cliente;
                cellNumFactura.Value = fact.numero;
                cellEmpresa.Value = fact.empresa;

                DataGridViewRow row = new DataGridViewRow();
                row.Cells.Add(cellNumFactura);
                row.Cells.Add(cellEmpresa);
                row.Cells.Add(cellCliente);

                gridFacturas.Rows.Add(row);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (gridFacturas.SelectedRows.Count <= 0)
                return;

            int numFactura = Int32.Parse(gridFacturas.SelectedRows[0].Cells[0].Value.ToString());
            buscador.numFactura = numFactura;

            this.Close();
        }
    }
}
