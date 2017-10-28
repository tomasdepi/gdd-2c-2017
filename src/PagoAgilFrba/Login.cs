using PagoAgilFrba.Properties;
using PagoAgilFrba.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba
{
    public partial class Login : Form
    {
        RepoLogin repo;

        public Login()
        {
            InitializeComponent();
            this.repo = new RepoLogin();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.CargarConfiguracionFecha();
        }

        private void CargarConfiguracionFecha()
        {
           Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
           config.AppSettings.Settings.Add("FechaSistema", Resources.FechaSistema);
           config.Save(ConfigurationSaveMode.Modified);
           ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);

        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {

            if(txtPassword.Text == "" || txtUsuario.Text == "")
            {
                MessageBox.Show("Complete todos los campos", "Alerta", MessageBoxButtons.OK);
                return;
            }

            var loginResult = repo.validarUsuario(txtUsuario.Text, txtPassword.Text);

            switch (loginResult)
            {
                case 0: //supera intentos fallidos
                    MessageBox.Show("Supero los intentos fallidos, cuenta bloqueada, contacte a un administrador", "Alerta", MessageBoxButtons.OK);
                    break;
                case 2: 
                    MessageBox.Show("Usuario o Password incorrecto", "Alerta", MessageBoxButtons.OK);
                    break;
                case 1:
                    break;

            }
        }
    }
}
