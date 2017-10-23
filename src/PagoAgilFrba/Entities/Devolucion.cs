using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Entities
{
    public class Devolucion
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public string tipoEntidad { get; set; }
        public int idEntidad { get; set; }
        public string motivo { get; set; }
    }
}
