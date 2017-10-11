using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Entities
{
    public class Cliente
    {  
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int telefono { get; set; }
        public int dni { get; set; }
        public string mail { get; set; }
        public string direccion { get; set; }
        public string codigoPostal { get; set; }
        public string fechaNac { get; set; }
        public bool habilitado { get; set; }
    }
}
