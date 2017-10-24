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

        public RegistroPago()
        {
            InitializeComponent();
            this.repo = new RepoPago();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarFactura_Click(object sender, EventArgs e)
        {
            // var altaRegistroPag = new AltaRegistroPago() { StartPosition = FormStartPosition.CenterParent };
            // altaRegistroPag.ShowDialog();

            BuscadorEntidad buscador = new BuscadorEntidad();
            buscador.lanzarBuscadorFactura();
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
            int importe = Int32.Parse(gridFacturas.SelectedRows[0].Cells[0].Value.ToString());
            gridFacturas.Rows.Remove(row);

            int importeTotal = Int32.Parse(lblImporteTotal.Text) - importe;
            lblImporteTotal.Text = importeTotal.ToString();
        }

        private void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            Pago pago = new Pago();
            pago.cliente = Int32.Parse(txtCliente.Text);
            pago.importeTotal = Int32.Parse(lblImporteTotal.Text);
            pago.sucursal = Int32.Parse(lblSucursal.Text);
            pago.fecha = Convert.ToDateTime(ConfigurationManager.AppSettings["fechaSistema"]);

            repo.altaPago(pago);
        }

        private void gridAgregarFactura(int numFactura, int importe)
        {
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
    }
}
