using PagoAgilFrba.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.Utilities
{
    public class BuscadorEntidad
    {
        public int dni { get; set;  }
        public string cuit { get; set; }
        public Factura factura { get; set; }
        public int idRendicion { get; set; }


        public BuscadorEntidad()
        {
            this.cuit = "";
            this.dni = 0;
            this.factura = new Factura();
            this.idRendicion = 0;
        }

        public void lanzarBuscadorCliente()
        {
            BuscadorCliente buscCliente = new BuscadorCliente(this);
            buscCliente.ShowDialog();
        }
        public void lanzarBuscadorEmpresa()
        {
            BuscadorEmpresa buscEmpresa = new BuscadorEmpresa(this);
            buscEmpresa.ShowDialog();
        }
        public void lanzarBuscadorFactura()
        {
            BuscadorFactura buscFactura = new BuscadorFactura(this);
            buscFactura.ShowDialog();
        }
        public void lanzarBuscadorRendicion()
        {
            BuscadorRendicion buscRendicion = new BuscadorRendicion(this);
            buscRendicion.ShowDialog();
        }

        public void formCallback()
        {

        }

    }
}
