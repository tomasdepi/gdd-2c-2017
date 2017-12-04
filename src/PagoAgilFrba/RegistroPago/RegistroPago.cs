using PagoAgilFrba.Entities;
using PagoAgilFrba.Repository;
using PagoAgilFrba.Utilities;
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

namespace PagoAgilFrba.RegistroPago
{
    public partial class RegistroPago : Form
    {
        RepoPago repo;
        int sucursal;
        List<Factura> facturas_a_pagar;

        public RegistroPago(int sucursal)
        {
            InitializeComponent();
            this.repo = new RepoPago();
            this.sucursal = sucursal;
            this.facturas_a_pagar = new List<Factura>();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarFactura_Click(object sender, EventArgs e)
        {
            BuscadorEntidad buscador = new BuscadorEntidad();
            buscador.lanzarBuscadorFactura();
            Factura factura = buscador.factura;

            if (factura.pagada)
            {
                MessageBox.Show("Esa factura ya esta pagada", "Alerta", MessageBoxButtons.OK);
                return;
            }

            if (factura.vencida)
            {
                MessageBox.Show("Esa factura esta vencida. No puede ser pagada.", "Alerta", MessageBoxButtons.OK);
                return;
            }

            if(facturas_a_pagar.Exists( f => f.numero == factura.numero))
            {
                MessageBox.Show("Esa factura ya esta seleccionada", "Error", MessageBoxButtons.OK);
                return;
            }

            facturas_a_pagar.Add(factura);

            this.gridAgregarFactura(factura.numero, factura.importe);
        }

        private void btnSelectCliente_Click(object sender, EventArgs e)
        {
            BuscadorEntidad buscador = new BuscadorEntidad();
            buscador.lanzarBuscadorCliente();
            setCliente(buscador.dni.ToString());
        }

        public void setCliente(string dni)
        {
            txtCliente.Text = dni;
        }

        private void comboFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboFormaPago.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminarFactura_Click(object sender, EventArgs e)
        {
            if (gridFacturas.SelectedRows.Count <= 0)
                return;

            DataGridViewRow row = gridFacturas.SelectedRows[0];
            int importe = Int32.Parse(gridFacturas.SelectedRows[0].Cells[1].Value.ToString());
            var numFactura = Int32.Parse(gridFacturas.SelectedRows[0].Cells[0].Value.ToString());
            facturas_a_pagar.RemoveAll(f => f.numero == numFactura);
            gridFacturas.Rows.Remove(row);

            int importeTotal = Int32.Parse(lblImporteTotal.Text) - importe;
            lblImporteTotal.Text = importeTotal.ToString();
        }

        private void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            if(txtCliente.Text == "")
            {
                MessageBox.Show("Debe seleccionar un cliente.", "Alerta", MessageBoxButtons.OK);
                return;
            }

            if (gridFacturas.Rows.Count == 0)
            {
                MessageBox.Show("Debe haber al menos una factura para pagars.", "Alerta", MessageBoxButtons.OK);
                return;
            }

            Pago pago = new Pago();
            pago.cliente = Int32.Parse(txtCliente.Text);
            pago.importeTotal = Int32.Parse(lblImporteTotal.Text);
            pago.sucursal = Int32.Parse(lblSucursal.Text);
            pago.fecha = Convert.ToDateTime(ConfigurationManager.AppSettings["fechaSistema"]);
            pago.formaPago = comboFormaPago.Items[comboFormaPago.SelectedIndex].ToString();

            var pagoId = repo.altaPago(pago);

            //registro cada factura en la tabla intermedia
            List<int> numFacturas = new List<int>();
            foreach (DataGridViewRow row in gridFacturas.Rows)
            {
                var num = Int32.Parse(row.Cells[0].Value.ToString());
                numFacturas.Add(num);
            }

            repo.altaFacturasPago(pagoId, numFacturas);

            gridFacturas.Rows.Clear();
            lblImporteTotal.Text = "0";
            txtCliente.Text = "";
            MessageBox.Show("Pago realizado con exito", "Exito", MessageBoxButtons.OK);
        }

        private void gridAgregarFactura(int numFactura, int importe)
        {
            if (numFactura == 0) return;

            DataGridViewRow row = new DataGridViewRow();
            DataGridViewTextBoxCell numFacturaCell = new DataGridViewTextBoxCell();
            DataGridViewTextBoxCell importeCell = new DataGridViewTextBoxCell();
            numFacturaCell.Value = numFactura.ToString();
            importeCell.Value = importe.ToString();
            row.Cells.Add(numFacturaCell);
            row.Cells.Add(importeCell);

            gridFacturas.Rows.Add(row);

            this.updateImporteTotal(importe);
        }

        private void updateImporteTotal(int importe)
        {
            int importeTotal = Int32.Parse(lblImporteTotal.Text) + importe;
            lblImporteTotal.Text = importeTotal.ToString();
        }

        private void RegistroPago_Load(object sender, EventArgs e)
        {
            lblSucursal.Text = this.sucursal.ToString();
            comboFormaPago.SelectedIndex = 0;
            gridFacturas.AllowUserToAddRows = false;
        }
    }
}
