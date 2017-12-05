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

namespace PagoAgilFrba.Devolucion
{
    public partial class DevolucionFactura : Form
    {
        RepoDevolucion repo;

        public DevolucionFactura()
        {
            InitializeComponent();
            repo = new RepoDevolucion();
        }

        private void DevolucionFactura_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSeleccionarFactura_Click(object sender, EventArgs e)
        {
            BuscadorEntidad buscador = new BuscadorEntidad();
            buscador.lanzarBuscadorFactura();

            if (!(buscador.factura.numero.ToString() == "0"))
                if(buscador.factura.pagada == false)
                    MessageBox.Show("No puede devolver una factura que no esta pagada.","Alerta", MessageBoxButtons.OK);
                else
                    txtFactura.Text = buscador.factura.numero.ToString();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtFactura.Text == "" || txtMotivo.Text == "")
            {
                MessageBox.Show("Debe ingresar todos los campos.", "Alerta", MessageBoxButtons.OK);
                return;
            }

            Entities.Devolucion devolucion = new Entities.Devolucion();
            devolucion.motivo = txtMotivo.Text;
            devolucion.idEntidad = Int32.Parse(txtFactura.Text);
            devolucion.tipoEntidad = "Factura";
            try { 
                devolucion.fecha = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]);
            }
            catch
            {
                devolucion.fecha = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistemaProvisional"]);
            }

            repo.altaDevolucion(devolucion);

            MessageBox.Show("Devolucion realizada con exito", "Exito", MessageBoxButtons.OK);

            txtMotivo.Text = "";
            txtFactura.Text = "";
         
        }
    }
}
