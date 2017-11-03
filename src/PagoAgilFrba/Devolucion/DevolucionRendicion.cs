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
    public partial class DevolucionRendicion : Form
    {
        RepoDevolucion repo;

        public DevolucionRendicion()
        {
            InitializeComponent();
            this.repo = new RepoDevolucion();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Entities.Devolucion devolucion = new Entities.Devolucion();
            devolucion.motivo = txtMotivo.Text;

            if(txtMotivo.Text == "")
            {
                MessageBox.Show("Debe ingresar el motivo de la devolucion", "Alerta", MessageBoxButtons.OK);
                return;
            }

            devolucion.idEntidad = Int32.Parse(txtIdRendicion.Text);
            devolucion.tipoEntidad = "Rendicion";
            devolucion.fecha = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]);

            repo.altaDevolucion(devolucion);

            MessageBox.Show("Devolucion realizada con exito", "Exito", MessageBoxButtons.OK);

            txtMotivo.Text = "";
            txtIdRendicion.Text = "";

        }

        private void btnSeleccionarRendicion_Click(object sender, EventArgs e)
        {
            BuscadorEntidad buscador = new BuscadorEntidad();
            buscador.lanzarBuscadorRendicion();
            txtIdRendicion.Text = buscador.idRendicion.ToString();
        }
    }
}
