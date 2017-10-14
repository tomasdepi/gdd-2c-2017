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
    public partial class EditarRol : Form
    {

        private Rol rol;
        private List<Funcionalidad> funcs;
        private ListadoRoles padre;

        public EditarRol(Rol rol, ListadoRoles formPadre)
        {
            this.rol = rol;
            this.padre = formPadre;
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void EditarRol_Load(object sender, EventArgs e)
        {
            cbHabilitado.Items.Add("Si");
            cbHabilitado.Items.Add("No");
            cbHabilitado.DropDownStyle = ComboBoxStyle.DropDownList;

            if (rol.habilitado)
                cbHabilitado.SelectedIndex = 0;
            else
                cbHabilitado.SelectedIndex = 1;

            funcs = new RepoRol().getFuncionalidadesDeRol(rol.nombre);

            foreach(Funcionalidad f in funcs)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewTextBoxCell nombre = new DataGridViewTextBoxCell();
                DataGridViewCheckBoxCell habilitado = new DataGridViewCheckBoxCell();

                nombre.Value = f.nombre;
                habilitado.Value = f.posee ? true : false;

                row.Cells.Add(habilitado);
                row.Cells.Add(nombre);

                nombre.ReadOnly = true;

                gridFuncionalidades.Rows.Add(row);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            RepoRol repo = new RepoRol();
            if ((cbHabilitado.SelectedIndex == 1 && rol.habilitado) || (cbHabilitado.SelectedIndex == 0 && !rol.habilitado)){
                bool h = cbHabilitado.Items[cbHabilitado.SelectedIndex].ToString() == "Si" ? true : false;
                repo.actualizarHabilitado(h, rol.id);
                padre.actualizarHabilitado(rol.id);
            }

            var i = 0;
            List<Funcionalidad> funcsAAgregar = new List<Funcionalidad>();
            foreach (DataGridViewRow row in gridFuncionalidades.Rows)
            {
                DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)row.Cells[0];
                if (Convert.ToBoolean(checkbox.Value) && i < funcs.Count)
                {
                    Funcionalidad f = funcs[i];
                    funcsAAgregar.Add(f);
                }
                i++;
            }
            repo.eliminarFuncionalidades(rol.id);
            repo.agregarFuncionalidades(rol.id, funcsAAgregar);

            MessageBox.Show("Rol actualizado con exito", "Exito", MessageBoxButtons.OK);
            this.Close();
        }
    }
}
