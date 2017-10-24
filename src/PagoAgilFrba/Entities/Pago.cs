using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Entities
{
    public class Pago
    {
        public int id { get; set; }
        public int cliente { get; set; }
        public int importeTotal { get; set; }
        public int sucursal { get; set; }
        public DateTime fecha { get; set; }
        public string formaPago { get; set; }

    }
}
