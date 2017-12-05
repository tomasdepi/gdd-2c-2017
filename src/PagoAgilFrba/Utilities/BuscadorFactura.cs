using PagoAgilFrba.Entities;
using PagoAgilFrba.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
            int paga = comboPago.SelectedIndex;

            List<Factura> facturas = repo.getFacturas(numFactura, cliente, paga);

            DateTime fechaSistema;

            try
            {
                fechaSistema = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"].ToString());
            }catch
            {
                fechaSistema = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistemaProvicional"].ToString());
            }

            foreach (Factura fact in facturas)
            {
                DataGridViewTextBoxCell cellNumFactura = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cellEmpresa = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cellCliente = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cellImporte = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cellPagada = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cellVencida = new DataGridViewTextBoxCell();
                cellCliente.Value = fact.cliente;
                cellNumFactura.Value = fact.numero;
                cellEmpresa.Value = fact.empresa;
                cellImporte.Value = fact.importe;
                cellPagada.Value = fact.pagada ? "Si" : "No";
                if (!fact.pagada)
                    cellVencida.Value = fact.vencida ? "Si" : "No";
                else
                    cellVencida.Value = "-";

                DataGridViewRow row = new DataGridViewRow();
                row.Cells.Add(cellNumFactura);
                row.Cells.Add(cellEmpresa);
                row.Cells.Add(cellCliente);
                row.Cells.Add(cellImporte);
                row.Cells.Add(cellPagada);
                row.Cells.Add(cellVencida);

                gridFacturas.Rows.Add(row);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (gridFacturas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione la fila de la factura que desea.", "Error", MessageBoxButtons.OK);
                return;
            }

            int numFactura = Int32.Parse(gridFacturas.SelectedRows[0].Cells[0].Value.ToString());
            int importe = Int32.Parse(gridFacturas.SelectedRows[0].Cells[3].Value.ToString());
            Factura fact = new Factura();
            fact.importe = importe;
            fact.numero = numFactura;
            fact.pagada = gridFacturas.SelectedRows[0].Cells[4].Value.ToString() == "Si" ? true : false;
            fact.vencida = gridFacturas.SelectedRows[0].Cells[5].Value.ToString() == "Si" ? true : false;
            buscador.factura = fact;

            this.Close();
        }

        private void BuscadorFactura_Load(object sender, EventArgs e)
        {
            gridFacturas.AllowUserToAddRows = false;
            gridFacturas.MultiSelect = false;
            comboPago.SelectedIndex = 0;
        }
    }
}
