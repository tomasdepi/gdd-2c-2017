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

namespace PagoAgilFrba
{
    public partial class Menu : Form
    {
        string username;
        RepoLogin repo;

        public Menu(string username)
        {
            InitializeComponent();
            this.username = username;
            this.repo = new RepoLogin();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            lblUsername.Text = this.username;
            List<Sucursal> sucursales = repo.getSucursalesDeUsuario(username);

            foreach (Sucursal suc in sucursales)
            {
                comboSucursales.Items.Add(suc.nombre);
            }
        }
    }
}
