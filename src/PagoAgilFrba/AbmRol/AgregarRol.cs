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
    public partial class AgregarRol : Form
    {
        List<Funcionalidad> funcs;
        ListadoRoles padre;

        public AgregarRol(ListadoRoles formPadre)
        {
            this.padre = formPadre;
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
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

            if(txtNombreRol.Text == "")
            {
                MessageBox.Show("Debe ingresar un nombre para el rol", "Error", MessageBoxButtons.OK);
                return;
            }

            if(funcsAAgregar.Count() == 0)
            {
                MessageBox.Show("Debe seleccionar al menos una funcionalidad", "Error", MessageBoxButtons.OK);
            }
            else
            {
                int idRol = new RepoRol().guardarNuevoRol(txtNombreRol.Text, funcsAAgregar);
                MessageBox.Show("Rol creado con exito", "Nuevo Rol", MessageBoxButtons.OK);
                padre.agregarRol(idRol, txtNombreRol.Text, true);
                padre.listAddRol(idRol, txtNombreRol.Text, true);
                this.Close();
            }
               
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cargarFuncionalidades()
        {
            RepoRol repo = new RepoRol();
            funcs = repo.getFuncionalidades();

            foreach (Funcionalidad func in funcs)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewCell check = new DataGridViewCheckBoxCell();
                DataGridViewCell nombre = new DataGridViewTextBoxCell();

                nombre.Value = func.nombre;

                row.Cells.Add(check);
                row.Cells.Add(nombre);

                nombre.ReadOnly = true;

                gridFuncionalidades.Rows.Add(row);
            }
        }

        private void AgregarRol_Load(object sender, EventArgs e)
        {
            cargarFuncionalidades();
            gridFuncionalidades.MultiSelect = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
