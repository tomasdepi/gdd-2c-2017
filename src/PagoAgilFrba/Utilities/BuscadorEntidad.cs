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

        public BuscadorEntidad()
        {
            this.cuit = "";
            this.dni = 0;
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

        public void formCallback()
        {

        }

    }
}
