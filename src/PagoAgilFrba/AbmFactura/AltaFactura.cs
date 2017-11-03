using PagoAgilFrba.Entities;
using PagoAgilFrba.Repository;
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

namespace PagoAgilFrba.AbmFactura
{
    public partial class AltaFactura: Form
    {
        RepoFactura repo;

        public AltaFactura()
        {
            InitializeComponent();
            repo = new RepoFactura();
        }

        private void txtCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void txtAceptar_Click(object sender, EventArgs e)
        {
            if(gridItems.Rows.Count <= 0)
            {
                MessageBox.Show("Debe agregar al menos un item", "Error", MessageBoxButtons.OK);
                return;
            }

            Factura fact = new Factura();
            List <ItemFactura> items = new List<ItemFactura>();
            fact.numero = Int32.Parse(txtNumFactura.Text);
            fact.cliente = Int32.Parse(txtCliente.Text);
            fact.empresa = txtEmpresa.Text;
            fact.alta = dateAlta.Value.Date;
            fact.vencimiento = dateVencimiento.Value.Date;

            foreach(DataGridViewRow row in gridItems.Rows)
            {
                if (row.IsNewRow) continue;

                ItemFactura i = new ItemFactura();
                i.cantidad = Int32.Parse(row.Cells[0].Value.ToString());
                i.monto = Int32.Parse(row.Cells[1].Value.ToString());
                i.numFactura = fact.numero;
                items.Add(i);
            }

            repo.altaFactura(fact);
            repo.altaItems(items);
            MessageBox.Show("Factura cargada con exito", "Exito", MessageBoxButtons.OK);
            this.Close();
        }

        private void AltaFactura_Load(object sender, EventArgs e)
        {
            txtMonto.KeyPress += onlyNumbers;
            txtCantidad.KeyPress += onlyNumbers;
            gridItems.AllowUserToAddRows = false;
        }

        private void onlyNumbers(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btnSelectCliente_Click(object sender, EventArgs e)
        {
            BuscadorEntidad buscador = new BuscadorEntidad();
            buscador.lanzarBuscadorCliente();
            txtCliente.Text = buscador.dni.ToString();
        }

        private void txtNumFactura_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSelectEmpesa_Click(object sender, EventArgs e)
        {
            BuscadorEntidad buscador = new BuscadorEntidad();
            buscador.lanzarBuscadorEmpresa();
            txtEmpresa.Text = buscador.cuit.ToString();
        }
    }
}
