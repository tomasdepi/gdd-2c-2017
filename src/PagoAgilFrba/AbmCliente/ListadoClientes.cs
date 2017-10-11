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
            gridListadoClientes.Rows.Clear();
            var nombre = txtNombre.Text;
            var apellido = txtApellido.Text;
            int dni = int.Parse(txtDni.Text);

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
                habilitadoCell.Value = clie.habilitado;
                row.Cells.Add(nombreCell);
                row.Cells.Add(apellidoCell);
                row.Cells.Add(mailCell);
                row.Cells.Add(direccionCell);
                row.Cells.Add(dniCell);
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
            int dni = (int)gridListadoClientes.SelectedRows[0].Cells[0].Value;
            int habilitado = (int)gridListadoClientes.SelectedRows[0].Cells[5].Value;

            if(habilitado == 1)
            {
                gridListadoClientes.SelectedRows[0].Cells[5].Value = 0;
                repo.setHabilitacionCliente(dni, false);
            }
            else
            {
                gridListadoClientes.SelectedRows[0].Cells[5].Value = 1;
                repo.setHabilitacionCliente(dni, true);
            }
        }

        private void txtEditar_Click(object sender, EventArgs e)
        {
            int dni = (int)gridListadoClientes.SelectedRows[0].Cells[0].Value;
        }
    }
}
