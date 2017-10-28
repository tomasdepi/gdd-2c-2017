using PagoAgilFrba.AbmFactura;
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

namespace PagoAgilFrba.AbmCliente
{
    public partial class ListadoClientes : Form
    {
        RepoCliente repo;
        
        public ListadoClientes()
        {
            InitializeComponent();
            this.repo = new RepoCliente();
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var nombre = txtNombre.Text;
            var apellido = txtApellido.Text;
            var dni = txtDni.Text;

            gridListadoClientes.Rows.Clear();

            List<Cliente> clientes = repo.getClientes(dni, nombre, apellido);

            foreach(Cliente clie in clientes)
            {
                DataGridViewRow row = new DataGridViewRow();

                DataGridViewTextBoxCell nombreCell = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell apellidoCell = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell mailCell = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell direccionCell = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell dniCell = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell habilitadoCell = new DataGridViewTextBoxCell();
                nombreCell.Value = clie.nombre;
                apellidoCell.Value = clie.apellido;
                mailCell.Value = clie.mail;
                direccionCell.Value = clie.direccion;
                dniCell.Value = clie.dni;
                habilitadoCell.Value = clie.habilitado ? "Si" : "No";
                row.Cells.Add(dniCell);
                row.Cells.Add(nombreCell);
                row.Cells.Add(apellidoCell);
                row.Cells.Add(mailCell);
                row.Cells.Add(direccionCell);
                row.Cells.Add(habilitadoCell);

                gridListadoClientes.Rows.Add(row);
            }
        }

        private void txtCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListadoClientes_Load(object sender, EventArgs e)
        {
            gridListadoClientes.MultiSelect = false;
        }

        private void txtHabilitar_Click(object sender, EventArgs e)
        {
            if (gridListadoClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccion a un cliente", "Error", MessageBoxButtons.OK);
                return;
            }

            int dni = (int)gridListadoClientes.SelectedRows[0].Cells[0].Value;
            bool habilitado = gridListadoClientes.SelectedRows[0].Cells[5].Value.ToString() == "Si" ? true : false;

            repo.setHabilitacionCliente(dni, habilitado);

            if(habilitado)
            {
                gridListadoClientes.SelectedRows[0].Cells[5].Value = "No";
                repo.setHabilitacionCliente(dni, false);
            }
            else
            {
                gridListadoClientes.SelectedRows[0].Cells[5].Value = "Si";
                repo.setHabilitacionCliente(dni, true);
            }

            MessageBox.Show("Cambio exitoso.", "Actualizado", MessageBoxButtons.OK);
        }

        private void txtEditar_Click(object sender, EventArgs e)
        {
            if (gridListadoClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccion a un cliente", "Error", MessageBoxButtons.OK);
                return;
            }

            int dni = (int)gridListadoClientes.SelectedRows[0].Cells[0].Value;

            var editarCliente = new EditarCliente(dni) { StartPosition = FormStartPosition.CenterParent };
            editarCliente.ShowDialog();
        }

        private void btnAltaCliente_Click(object sender, EventArgs e)
        {
            var altaCliente = new AltaCliente() { StartPosition = FormStartPosition.CenterParent };
            altaCliente.ShowDialog();
        }
    }
}
