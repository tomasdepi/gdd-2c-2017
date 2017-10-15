using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Entities
{
    public class Empresa
    {
        public int id { get; set; }
        public string cuit { get; set; }
        public string nombre { get; set; }
        public string direccion  { get; set; }
        public string rubro  { get; set; }
        public DateTime fechaRendicion  { get; set; }
        public bool habilitado { get; set; }
    }
}
