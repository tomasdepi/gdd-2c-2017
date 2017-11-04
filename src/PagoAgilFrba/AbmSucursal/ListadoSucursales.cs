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

namespace PagoAgilFrba.AbmSucursal
{
    public partial class ListadoSucursales : Form
    {

        RepoSucursal repo;

        public ListadoSucursales()
        {
            InitializeComponent();
            this.repo = new RepoSucursal();
        }

        private void ListadoSucursales_Load(object sender, EventArgs e)
        {
            gridSucursales.MultiSelect = false;
            gridSucursales.AllowUserToAddRows = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var codPostal = txtCodPostal.Text;
            var nombre = txtNombre.Text;

            List<Sucursal> sucursales = repo.getSucursales(codPostal, nombre);

            gridSucursales.Rows.Clear();

            foreach(Sucursal suc in sucursales)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewTextBoxCell codPostalCell = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell nombreCell = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell direccionCell = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell habilitadoCell = new DataGridViewTextBoxCell();

                codPostalCell.Value = suc.codigoPostal;
                nombreCell.Value = suc.nombre;
                direccionCell.Value = suc.direccion;
                habilitadoCell.Value = suc.habilitado ? "Si" : "No";

                row.Cells.Add(codPostalCell);
                row.Cells.Add(nombreCell);
                row.Cells.Add(direccionCell);
                row.Cells.Add(habilitadoCell);

                gridSucursales.Rows.Add(row);
            }
        }

        private void btnEditarSucursal_Click(object sender, EventArgs e)
        {
            if (gridSucursales.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una sucursal", "Alerta", MessageBoxButtons.OK);
                return;
            }

            int codPostal = Int32.Parse(gridSucursales.SelectedRows[0].Cells[0].Value.ToString());

            var editarSucursal = new EditarSucursal(codPostal) { StartPosition = FormStartPosition.CenterParent };
            editarSucursal.ShowDialog();
        }

        private void btnAltaSucursal_Click(object sender, EventArgs e)
        {
            var altaSucursal = new AltaSucursal() { StartPosition = FormStartPosition.CenterParent };
            altaSucursal.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (gridSucursales.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una sucursal", "Alerta", MessageBoxButtons.OK);
                return;
            }

            var codPostal = gridSucursales.SelectedRows[0].Cells[0].Value.ToString();
            var habilitacion = gridSucursales.SelectedRows[0].Cells[3].Value.ToString() == "Si" ? true : false;

            if (habilitacion)
            {
                repo.setHabilitacion(Int32.Parse(codPostal), false);
                gridSucursales.SelectedRows[0].Cells[3].Value = "No";
            }
            else
            {
                repo.setHabilitacion(Int32.Parse(codPostal), true);
                gridSucursales.SelectedRows[0].Cells[3].Value = "Si";
            }
        }

        private void btnLimpiarTabla_Click(object sender, EventArgs e)
        {
            gridSucursales.Rows.Clear();
        }
    }
}
