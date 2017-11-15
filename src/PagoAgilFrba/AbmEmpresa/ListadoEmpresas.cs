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

namespace PagoAgilFrba.AbmEmpresa
{
    public partial class ListadoEmpresas : Form
    {
        RepoEmpresa repo;
        List<Empresa> empresas;

        public ListadoEmpresas()
        {
            InitializeComponent();
            this.repo = new RepoEmpresa();
            this.empresas = new List<Empresa>();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
            var nombre = txtNombre.Text;
            var cuit = txtCuit.Text;
            var rubro = txtRubro.Text;

            gridListadoEmpresas.Rows.Clear();

            this.empresas = repo.getEmpresas(cuit, nombre);

            foreach(Empresa empr in empresas)
            {
                DataGridViewRow row = new DataGridViewRow();
                
                 DataGridViewTextBoxCell cuitCell = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell nombreCell = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell direccionCell = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell rubroCell = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell habilitadoCell = new DataGridViewTextBoxCell();
                
                cuitCell.Value = empr.cuit;
                nombreCell.Value = empr.nombre;
                direccionCell.Value = empr.direccion;
                rubroCell.Value = empr.rubro;
                habilitadoCell.Value = empr.habilitado ? "Sí" : "No";
                
                row.Cells.Add(cuitCell);
                row.Cells.Add(nombreCell);
                row.Cells.Add(direccionCell);
                row.Cells.Add(rubroCell);
                row.Cells.Add(habilitadoCell);

                gridListadoEmpresas.Rows.Add(row);
           }
        }

        private void txtCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListadoEmpresas_Load(object sender, EventArgs e)
        {
            gridListadoEmpresas.MultiSelect = false;
            gridListadoEmpresas.AllowUserToAddRows = false;
        }

        private void txtHabilitar_Click(object sender, EventArgs e)
        {
            if (gridListadoEmpresas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una empresa", "Error", MessageBoxButtons.OK);
                return;
            }

            var cuit = gridListadoEmpresas.SelectedRows[0].Cells[0].Value.ToString();
            int id = empresas.Find(emp => emp.cuit == cuit).id;
            bool habilitado = gridListadoEmpresas.SelectedRows[0].Cells[4].Value.ToString() == "Sí" ? true : false;
            
            
            if (habilitado)
            {

                if (repo.validarTodasFacturasRendidas(cuit))
                {
                    MessageBox.Show("Esa empresa tiene facturas no rendidas. No puede deshabilitarse.", "Error", MessageBoxButtons.OK);
                    return;
                }

                gridListadoEmpresas.SelectedRows[0].Cells[4].Value = "No";
                repo.setHabilitacionEmpresa(id, false);
            }
            else
            {
                gridListadoEmpresas.SelectedRows[0].Cells[4].Value = "Sí";
                repo.setHabilitacionEmpresa(id, true);
            }

            MessageBox.Show("Cambio exitoso.", "Actualizado", MessageBoxButtons.OK);
        }

        private void txtEditar_Click(object sender, EventArgs e)
        {
            if (gridListadoEmpresas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una empresa", "Error", MessageBoxButtons.OK);
                return;
            }

            var cuit = gridListadoEmpresas.SelectedRows[0].Cells[0].Value.ToString();
            int id = empresas.Find(emp => emp.cuit == cuit).id;

            var editarEmpresa = new EditarEmpresa(id) { StartPosition = FormStartPosition.CenterParent };
            editarEmpresa.ShowDialog();
        }

        private void btnAltaEmpresa_Click(object sender, EventArgs e)
        {
            var altaEmpresa = new AltaEmpresa() { StartPosition = FormStartPosition.CenterParent };
            altaEmpresa.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
