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
    public partial class BuscadorEmpresa : Form
    {
        BuscadorEntidad buscador;
        RepoEmpresa repo;

        public BuscadorEmpresa(BuscadorEntidad buscador)
        {
            InitializeComponent();
            this.repo = new RepoEmpresa();
            this.buscador = buscador;
        }

        private void BuscadorEmpresa_Load(object sender, EventArgs e)
        {
            txtCuit.KeyPress += onlyNumbers;
        }

        private void onlyNumbers(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (gridListadoEmpresa.SelectedRows.Count <= 0) return;
            buscador.cuit = gridListadoEmpresa.SelectedRows[0].Cells[0].Value.ToString();
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            gridListadoEmpresa.Rows.Clear();

            List<Empresa> empresas = repo.getEmpresas(txtCuit.Text, txtNombre.Text);
            foreach(Empresa emp in empresas)
            {
                gridAgregarEmpresa(emp);
            }
        }

        private void gridAgregarEmpresa(Empresa e)
        {
            if (!e.habilitado) return;

            DataGridViewRow row = new DataGridViewRow();
            DataGridViewTextBoxCell cuit = new DataGridViewTextBoxCell();
            DataGridViewTextBoxCell nombre = new DataGridViewTextBoxCell();
            DataGridViewTextBoxCell rubro = new DataGridViewTextBoxCell();
            cuit.Value = e.cuit;
            nombre.Value = e.nombre;
            rubro.Value = e.rubro;
            row.Cells.Add(cuit);
            row.Cells.Add(nombre);
            row.Cells.Add(rubro);
            gridListadoEmpresa.Rows.Add(row);
        }
    }
}
