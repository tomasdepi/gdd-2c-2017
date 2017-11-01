using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Entities
{
    public class Factura
    {
        public int cliente { get; set; }
        public int numero { get; set; }
        public DateTime alta { get; set; }
        public DateTime vencimiento { get; set; }
        public string empresa { get; set; }
        public bool pagada { get; set; }
        public int importe { get; set; }
        public bool vencida { get; set; }
    }
}
