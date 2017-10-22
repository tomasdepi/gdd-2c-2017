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

namespace PagoAgilFrba.Rendicion
{
    public partial class RendicionPago : Form
    {

        RepoRendicion repo;
        int totalRendicion;
        List<Factura> facturas;

        public RendicionPago()
        {
            InitializeComponent();
            repo = new RepoRendicion();
            this.totalRendicion = -1;
            this.facturas = new List<Factura>();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelectEmpresa_Click(object sender, EventArgs e)
        {
            BuscadorEntidad buscador = new BuscadorEntidad();
            buscador.lanzarBuscadorEmpresa();
            txtEmpresa.Text = buscador.cuit;
        }

        private void btnBuscarFacturas_Click(object sender, EventArgs e)
        {
            facturas = repo.getFacturasARendir(dateFechaRendicion.Value, txtEmpresa.Text);
            totalRendicion = 0;
            foreach(Factura factura in facturas)
            {
                gridAddFactura(factura);
                totalRendicion += factura.importe;
            }

            lblImporteTotal.Text = totalRendicion.ToString();
            lblCantFacturas.Text = facturas.Count.ToString();
            var comision = totalRendicion * Int32.Parse(upDownPorcentajeComision.Value.ToString());
            lblComision.Text = comision.ToString();

        }

        private void gridAddFactura(Factura factura)
        {
            DataGridViewRow row = new DataGridViewRow();
            DataGridViewTextBoxCell numero = new DataGridViewTextBoxCell();
            DataGridViewTextBoxCell importe = new DataGridViewTextBoxCell();
            numero.Value = factura.numero;
            importe.Value = factura.importe;
            row.Cells.Add(numero);
            row.Cells.Add(importe);

            gridFacturas.Rows.Add(row);
        }

        private void upDownPorcentajeComision_ValueChanged(object sender, EventArgs e)
        {
            if(this.totalRendicion != -1)
            {
                var comision = totalRendicion * Int32.Parse(upDownPorcentajeComision.Value.ToString());
                lblComision.Text = comision.ToString();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            if(repo.validarExistenciaRendicion(dateFechaRendicion.Value, txtEmpresa.Text))
            {
                MessageBox.Show("Ya se realizo la rendicion para ese mes y esa empresa", "Error", MessageBoxButtons.OK);
                return;
            }

            Entities.Rendicion rendicion = new Entities.Rendicion();
            rendicion.empresa = txtEmpresa.Text;
            rendicion.fecha = dateFechaRendicion.Value;
            rendicion.porcentComision = Int32.Parse(upDownPorcentajeComision.Value.ToString());
            rendicion.totalRendicion = Int32.Parse(lblImporteTotal.Text);
            rendicion.cantFacturas = Int32.Parse(lblCantFacturas.Text);
            rendicion.importeComision = Int32.Parse(lblComision.Text);

            repo.altaRendicion(rendicion);
            int idRendicion = repo.getIdRendicion(dateFechaRendicion.Value, txtEmpresa.Text);
            repo.altaFacturas(facturas, idRendicion);

            MessageBox.Show("Rendicion realizada correctamente!!", "Exito", MessageBoxButtons.OK);
            this.Close();
        }
    }
}
