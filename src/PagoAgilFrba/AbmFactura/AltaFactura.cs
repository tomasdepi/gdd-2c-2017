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
        }

        private void btnAgregarItem_Click(object sender, EventArgs e)
        {
            AltaItem altaItem = new AltaItem(this);
            altaItem.ShowDialog();
        }

        private void txtAceptar_Click(object sender, EventArgs e)
        {
            Factura fact = new Factura();
            List <ItemFactura> items = new List<ItemFactura>();
            fact.numero = Int32.Parse(txtNumFactura.Text);
            fact.cliente = Int32.Parse(txtCliente.Text);
            fact.empresa = txtEmpresa.Text;
            fact.alta = dateAlta.Value.Date;
            fact.vencimiento = dateVencimiento.Value.Date;

            foreach(DataGridViewRow row in gridItems.Rows)
            {
                ItemFactura i = new ItemFactura();
                i.cantidad = Int32.Parse(row.Cells[0].Value.ToString());
                i.monto = Int32.Parse(row.Cells[1].Value.ToString());
                items.Add(i);
            }

            repo.altaFactura(fact, items);
            MessageBox.Show("Factura cargada con exito", "Exito", MessageBoxButtons.OK);
        }
    }
}
