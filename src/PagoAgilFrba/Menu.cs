﻿using PagoAgilFrba.AbmCliente;
using PagoAgilFrba.AbmEmpresa;
using PagoAgilFrba.AbmFactura;
using PagoAgilFrba.AbmRol;
using PagoAgilFrba.AbmSucursal;
using PagoAgilFrba.Devolucion;
using PagoAgilFrba.Entities;
using PagoAgilFrba.ListadoEstadistico;
using PagoAgilFrba.Rendicion;
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
        RepoRol repoRol;
        List<Sucursal> sucursales;
        List<Rol> roles;
        List<List<Funcionalidad>> funcionalidadesDeRoles;
        List<Button> botonesFuncionalidades;

        public Menu(string username)
        {
            InitializeComponent();
            this.username = username;
            this.repo = new RepoLogin();
            this.repoRol = new RepoRol();
            this.botonesFuncionalidades = new List<Button>();
            this.botonesFuncionalidades.Add(btnAbmRol);
            this.botonesFuncionalidades.Add(btnAbmCliente);
            this.botonesFuncionalidades.Add(btnAbmEmpresa);
            this.botonesFuncionalidades.Add(btnAbmSucursal);
            this.botonesFuncionalidades.Add(btnAbmFactura);
            this.botonesFuncionalidades.Add(btnPagoFactura);
            this.botonesFuncionalidades.Add(btnRendiciones);
            this.botonesFuncionalidades.Add(btnListadoEstadistico);
            this.botonesFuncionalidades.Add(btnDevoluciones);
            this.funcionalidadesDeRoles = new List<List<Funcionalidad>>();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            lblUsername.Text = this.username;
            sucursales = repo.getSucursalesDeUsuario(username);
            roles = repo.getRolesDeUsuario(username);

            if (sucursales.Count == 0)
            {
                MessageBox.Show("Este usurio no tiene sucursales asignadas o bien ninguna esta habilitada en este momento, no puede usar el sistema PagoAgil, la sesion se cerrara automaticamentes","Error",MessageBoxButtons.OK);
                this.Close();
                return;
            }

            if (roles.Count == 0)
            {
                MessageBox.Show("Este usurio no tiene roles asignados o bien ninguno esta habilitado en este momento, la sesion se cerrara automaticamente", "Error", MessageBoxButtons.OK);
                this.Close();
                return;
            }

            foreach (Sucursal suc in sucursales)
            {
                comboSucursales.Items.Add(suc.nombre);
            }
            foreach (Rol rol in roles)
            {
                comboRol.Items.Add(rol.nombre);
               
                List<Funcionalidad> funcs= repoRol.getFuncionalidadesDeRol(rol.nombre);
                funcionalidadesDeRoles.Add(funcs);
            }
            comboSucursales.SelectedIndex = 0;
            comboRol.SelectedIndex = 0;
            comboSucursales.DropDownStyle = ComboBoxStyle.DropDownList;
            comboRol.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnSeleccionarSucursal_Click(object sender, EventArgs e)
        {
            var rolIndex = comboRol.SelectedIndex;
            var idRol = roles.ElementAt(rolIndex).id;

            List<Funcionalidad> funcs = repo.getFuncionalidadesDeRol(idRol);

            foreach(Funcionalidad func in funcs)
            {

            }
            
        }

        private void btnAbmCliente_Click(object sender, EventArgs e)
        {
            this.Hide();
            var abmCliente = new ListadoClientes() { StartPosition = FormStartPosition.CenterParent };
            abmCliente.ShowDialog();
            this.Show();
        }

        private void btnAbmEmpresa_Click(object sender, EventArgs e)
        {
            this.Hide();
            var ambEmpresa = new ListadoEmpresas() { StartPosition = FormStartPosition.CenterParent };
            ambEmpresa.ShowDialog();
            this.Show();
        }

        private void btnAbmSucursal_Click(object sender, EventArgs e)
        {
            this.Hide();
            var abmSucursal = new ListadoSucursales() { StartPosition = FormStartPosition.CenterParent };
            abmSucursal.ShowDialog();
            this.Show();
        }

        private void btnAbmFactura_Click(object sender, EventArgs e)
        {
            this.Hide();
            var ambFactura = new ListadoFacturas() { StartPosition = FormStartPosition.CenterParent };
            ambFactura.ShowDialog();
            this.Show();
        }

        private void btnPagoFactura_Click(object sender, EventArgs e)
        {
            var sucursalIndex = comboSucursales.SelectedIndex;
            var sucursal = sucursales.ElementAt(sucursalIndex).codigoPostal;
            this.Hide();
            var registroPago = new RegistroPago.RegistroPago(sucursal) { StartPosition = FormStartPosition.CenterParent };
            registroPago.ShowDialog();
            this.Show();
        }

        private void btnRendiciones_Click(object sender, EventArgs e)
        {
            this.Hide();
            var rendicones = new RendicionPago() { StartPosition = FormStartPosition.CenterParent };
            rendicones.ShowDialog();
            this.Show();
        }

        private void btnDevoluciones_Click(object sender, EventArgs e)
        {
            var rol = comboRol.SelectedItem.ToString();
           
            this.Hide();

            if(rol == "Administrador")
            {
                var devolucionRendicion = new DevolucionRendicion() { StartPosition = FormStartPosition.CenterParent };
                devolucionRendicion.ShowDialog();
            }
            else
            {
                var devolucionFactura = new DevolucionFactura() { StartPosition = FormStartPosition.CenterParent };
                devolucionFactura.ShowDialog();
            }
      
            this.Show();
        }

        private void btnListadoEstadistico_Click(object sender, EventArgs e)
        {
            this.Hide();
            var listadoEstadistico = new Listado() { StartPosition = FormStartPosition.CenterParent };
            listadoEstadistico.ShowDialog();
            this.Show();
        }

        private void btnAbmRol_Click(object sender, EventArgs e)
        {
            this.Hide();
            var abmRoles = new ListadoRoles() { StartPosition = FormStartPosition.CenterParent };
            abmRoles.ShowDialog();
            this.Show();
        }

        private void btnCerrarSession_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void comboRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = comboRol.SelectedIndex;
            List<Funcionalidad> funcsDeRol = funcionalidadesDeRoles.ElementAt(index);
            funcsDeRol = funcsDeRol.FindAll(f => f.id != 2); //elimino el registro de usuarios 

            for (var i = 0; i < funcsDeRol.Count; i++)
            {
                Button botonMenu = botonesFuncionalidades.ElementAt(i);
                if (funcsDeRol.ElementAt(i).posee == true) botonMenu.Enabled = true; else botonMenu.Enabled = false;
            }

        }

        
    }
}
