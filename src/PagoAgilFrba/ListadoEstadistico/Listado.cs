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

namespace PagoAgilFrba.ListadoEstadistico
{
    public partial class Listado : Form
    {
        RepoListado repo;

        public Listado()
        {
            InitializeComponent();
            repo = new RepoListado();
        }

        private void Listado_Load(object sender, EventArgs e)
        {
            comboTrimestre.SelectedIndex = 0;
            comboTipoListado.SelectedIndex = 0;
          
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {

        }

        private void btnGenerarListado_Click(object sender, EventArgs e)
        {
            var anio = Int32.Parse(numericAnio.Value.ToString());
            var trimestre = comboTrimestre.SelectedIndex + 1;

            gridListado.Columns.Clear();

            switch (comboTipoListado.SelectedIndex)
            {
                case 0: //facturas cobradas por empresa
                    gridListado.Columns.Add("empresa", "Empresa");
                    gridListado.Columns.Add("porcentaje", "Porcentaje");

                    List<Empresa> empresasConMasFacturas = repo.porcentajeFacturasCobradasEmpresa(anio, trimestre);

                    foreach (Empresa emp in empresasConMasFacturas)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        DataGridViewTextBoxCell cuit = new DataGridViewTextBoxCell();
                        DataGridViewTextBoxCell porcentaje = new DataGridViewTextBoxCell();
                        cuit.Value = emp.cuit;
                        porcentaje.Value = emp.id;
                        row.Cells.Add(cuit);
                        row.Cells.Add(porcentaje);
                        gridListado.Rows.Add(row);

                    }

                    break;
                case 1: //empresas con mayor monto rendido
                    gridListado.Columns.Add("empresa", "Empresa");
                    gridListado.Columns.Add("nombre", "Nombre");
                    gridListado.Columns.Add("direccion", "Direccion");
                    gridListado.Columns.Add("total", "Total");

                    List < Empresa > empresasMayorMonto = repo.empresasMayorMontoRendido(anio, trimestre);

                    foreach(Empresa emp in empresasMayorMonto)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        DataGridViewTextBoxCell cuit = new DataGridViewTextBoxCell();
                        DataGridViewTextBoxCell nombre = new DataGridViewTextBoxCell();
                        DataGridViewTextBoxCell direccion = new DataGridViewTextBoxCell();
                        DataGridViewTextBoxCell porcentaje = new DataGridViewTextBoxCell();
                        cuit.Value = emp.cuit;
                        nombre.Value = emp.nombre;
                        direccion.Value = emp.direccion;
                        porcentaje.Value = emp.id;
                        row.Cells.Add(cuit);
                        row.Cells.Add(nombre);
                        row.Cells.Add(direccion);
                        row.Cells.Add(porcentaje);
                        gridListado.Rows.Add(row);
                 
                    }

                    break;
                case 2: //clientes con mas pagos
                    gridListado.Columns.Add("cliente", "Cliente");
                    gridListado.Columns.Add("mail", "Mail");
                    gridListado.Columns.Add("direccion", "Direccion");
                    gridListado.Columns.Add("cantPagos", "Cantidad Pagos");

                    List<Cliente> clientesConMasPagos = repo.clientesMasPagos(anio, trimestre);

                    foreach (Cliente clie in clientesConMasPagos)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        DataGridViewTextBoxCell dni = new DataGridViewTextBoxCell();
                        DataGridViewTextBoxCell mail = new DataGridViewTextBoxCell();
                        DataGridViewTextBoxCell direccion = new DataGridViewTextBoxCell();
                        DataGridViewTextBoxCell cantPagos = new DataGridViewTextBoxCell();
                        dni.Value = clie.dni;
                        mail.Value = clie.mail;
                        direccion.Value = clie.direccion;
                        cantPagos.Value = clie.pagos;
                        row.Cells.Add(dni);
                        row.Cells.Add(mail);
                        row.Cells.Add(direccion);
                        row.Cells.Add(cantPagos);
                        gridListado.Rows.Add(row);

                    }


                    break;
                case 3: //clientes con mayot porcentaje de facturas rendidas
                    gridListado.Columns.Add("cliente", "Cliente");
                    gridListado.Columns.Add("porcentaje", "Porcentaje");

                    List<Cliente> clientesConMasFacturasRendidas = repo.clientesMasPagos(anio, trimestre);

                    foreach (Cliente clie in clientesConMasFacturasRendidas)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        DataGridViewTextBoxCell dni = new DataGridViewTextBoxCell();
                        DataGridViewTextBoxCell porcentaje = new DataGridViewTextBoxCell();
                        dni.Value = clie.dni;
                        porcentaje.Value = clie.pagos;
                        row.Cells.Add(dni);
                        row.Cells.Add(porcentaje);
                        gridListado.Rows.Add(row);

                    }

                    break;
            }

        }
    }
}
