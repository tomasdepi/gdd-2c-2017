using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Entities
{
    public class Rendicion
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public int cantFacturas { get; set; }
        public int importeComision { get; set; }
        public string empresa { get; set; }
        public int porcentComision { get; set; }
        public int totalRendicion { get; set; }

    }
}
