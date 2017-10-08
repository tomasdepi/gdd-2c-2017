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

        public AgregarRol()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var i = 0;
            List<Funcionalidad> funcsAAgregar = new List<Funcionalidad>();
            foreach (DataGridViewRow row in gridFuncionalidades.Rows)
            {
                DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)row.Cells[0];
                if (checkbox.Selected)
                {
                    Funcionalidad f = funcs[i];
                    funcsAAgregar.Add(f);
                }
                i++;
            }

            if(funcsAAgregar.Count() == 0)
            {
                //poner message box
            }else
                new RepoRol().guardarNuevoRol(txtNombreRol.Text, funcsAAgregar);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

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
