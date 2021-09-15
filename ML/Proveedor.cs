using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Proveedor
    {
        public int IdProveedor { get; set; }
        public string Nombre { get; set; }
        public decimal ApellidoPaterno { get; set; }
        public int ApellidoMaterno { get; set; }
        public int Telefono { get; set; }

        public List<object> Proveedors { get; set; }
    }
}
