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
    public partial class BuscadorRendicion : Form
    {
        BuscadorEntidad buscador;
        RepoRendicion repo;

        public BuscadorRendicion(BuscadorEntidad buscador)
        {
            InitializeComponent();
            this.repo = new RepoRendicion();
            this.buscador = buscador;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSeleccionar_Click(object sender, EventArgs e)
        {
            BuscadorEntidad buscador = new BuscadorEntidad();
            buscador.lanzarBuscadorEmpresa();
            txtCuitEmpresa.Text = buscador.cuit;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            if(txtCuitEmpresa.Text.ToString() == "")
            {
                MessageBox.Show("Debe seleccionar una empresa.", "Alerta", MessageBoxButtons.OK);
                return;
            }

            List<Entities.Rendicion> rendiciones = repo.buscarRendiciones(txtCuitEmpresa.Text);

            gridRendiciones.Rows.Clear();

            foreach(Entities.Rendicion rend in rendiciones)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewTextBoxCell id = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cuit = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell fecha = new DataGridViewTextBoxCell();
                id.Value = rend.id;
                cuit.Value = rend.empresa;
                fecha.Value = rend.fecha;
                row.Cells.Add(id);
                row.Cells.Add(cuit);
                row.Cells.Add(fecha);

                gridRendiciones.Rows.Add(row);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (gridRendiciones.SelectedRows.Count <= 0)
                return;

            buscador.idRendicion = Int32.Parse(gridRendiciones.SelectedRows[0].Cells[0].Value.ToString());

            this.Close();
        }

        private void BuscadorRendicion_Load(object sender, EventArgs e)
        {
            gridRendiciones.MultiSelect = false;
            gridRendiciones.AllowUserToAddRows = false;
        }
    }
}
