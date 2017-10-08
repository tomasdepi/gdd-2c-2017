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

namespace PagoAgilFrba.AbmRol
{
    public partial class ListadoRoles : Form
    {
        public ListadoRoles()
        {
            InitializeComponent();
        }

        private void ListadoRoles_Load(object sender, EventArgs e)
        {
            cargarRoles();
        }

        private void cargarRoles()
        {
            RepoRol repo = new RepoRol();
            List<Rol> roles = repo.getRoles();

            foreach (Rol rol in roles)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewCell nombre = new DataGridViewTextBoxCell();
                DataGridViewCell habilitado = new DataGridViewTextBoxCell();

                nombre.Value = rol.nombre;
                habilitado.Value = rol.habilitado ? "Si" : "No";
              
                row.Cells.Add(nombre);
                row.Cells.Add(habilitado);

                nombre.ReadOnly = true;
                habilitado.ReadOnly = true;

                gridViewRoles.Rows.Add(row);
            }
        }

        private void btnAgregarRol_Click(object sender, EventArgs e)
        {
            var agregarRol = new AgregarRol { StartPosition = FormStartPosition.CenterParent };
            agregarRol.ShowDialog();
        }
    }
}
