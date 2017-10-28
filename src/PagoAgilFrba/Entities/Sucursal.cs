using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Entities
{
    public class Sucursal
    {
        public int codigoPostal { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public bool habilitado { get; set; }
    }
}
