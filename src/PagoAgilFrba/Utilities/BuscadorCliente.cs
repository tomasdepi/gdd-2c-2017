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

namespace PagoAgilFrba.Utilities
{
    public partial class BuscadorCliente : Form
    {

        RepoCliente repo;
        BuscadorEntidad padre;

        public BuscadorCliente(BuscadorEntidad padre)
        {
            InitializeComponent();
            repo = new RepoCliente();
            this.padre = padre;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
 
            var nombre = txtNombre.Text;
            var apellido = txtApellido.Text;
            var dni = txtDni.Text;

            gridListadoClientes.Rows.Clear();

            List<Cliente> clientes = repo.getClientes(dni, nombre, apellido);

            foreach (Cliente clie in clientes)
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            var habilitado = gridListadoClientes.SelectedRows[0].Cells[0].Value.ToString();

            if(habilitado == "No")
            {
                MessageBox.Show("Ese usuario no esta habilitado", "Error", MessageBoxButtons.OK);
                return;
            }

            var dni = gridListadoClientes.SelectedRows[0].Cells[0].Value.ToString();

            this.padre.dni = Int32.Parse(dni);
                

            this.Close();
        }

        private void BuscadorCliente_Load(object sender, EventArgs e)
        {
            gridListadoClientes.MultiSelect = false;
            gridListadoClientes.AllowUserToAddRows = false;
        }
    }
}
