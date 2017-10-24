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
            txtFactura.Text = buscador.numFactura.ToString();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Entities.Devolucion devolucion = new Entities.Devolucion();
            devolucion.motivo = txtMotivo.Text;
            devolucion.idEntidad = Int32.Parse(txtFactura.Text);
            devolucion.tipoEntidad = "Factura";
            devolucion.fecha = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]);

            repo.altaDevolucion(devolucion);

            MessageBox.Show("Devolucion realizada con exito", "Exito", MessageBoxButtons.OK);

            txtMotivo.Text = "";
            txtFactura.Text = "";
         
        }
    }
}
