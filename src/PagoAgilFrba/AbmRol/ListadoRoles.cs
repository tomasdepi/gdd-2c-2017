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
        RepoRol repo;
        List<Rol> roles;
        public ListadoRoles()
        {
            InitializeComponent();
        }

        private void ListadoRoles_Load(object sender, EventArgs e)
        {
            gridViewRoles.AllowUserToAddRows = false;
            repo = new RepoRol();
            cargarRoles();

        }

        private void cargarRoles()
        {
            
            roles = repo.getRoles();

            foreach (Rol rol in roles)
            {
                agregarRol(rol.id, rol.nombre, rol.habilitado);
            }
        }

        public void agregarRol(int id, string rol, bool hab)
        {
            DataGridViewRow row = new DataGridViewRow();
            DataGridViewCell nombre = new DataGridViewTextBoxCell();
            DataGridViewCell habilitado = new DataGridViewTextBoxCell();

            nombre.Value = rol;
            habilitado.Value = hab ? "Si" : "No";

            row.Cells.Add(nombre);
            row.Cells.Add(habilitado);

            nombre.ReadOnly = true;
            habilitado.ReadOnly = true;

            gridViewRoles.Rows.Add(row);
        }

        public void listAddRol(int id, string nombre, bool habilitado)
        {
            Rol rol = new Rol();
            rol.id = id; rol.nombre = nombre; rol.habilitado = habilitado;
            roles.Add(rol);
        }

        private void btnAgregarRol_Click(object sender, EventArgs e)
        {
            var agregarRol = new AgregarRol(this) { StartPosition = FormStartPosition.CenterParent };
            agregarRol.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int index = gridViewRoles.CurrentRow.Index;
            Rol rol = roles[index];
            var editarRol = new EditarRol(rol, this) { StartPosition = FormStartPosition.CenterParent };
            editarRol.ShowDialog();
        }

        public void actualizarHabilitado(int rolId)
        {
            int rowIndex = roles.FindIndex(x => x.id == rolId);
            DataGridViewRow row = gridViewRoles.Rows[rowIndex];
            if ((string)row.Cells[1].Value == "Si")
                row.Cells[1].Value = "No";
            else
                row.Cells[1].Value = "Si";
        }
    }
}
