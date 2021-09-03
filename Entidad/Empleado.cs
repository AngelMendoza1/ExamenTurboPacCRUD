using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Empleado
    {
        public int  idEmpleado { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public bool Activo { get; set; }
        public decimal Salario { get; set; }

        public List<object> Empleados { get; set; }
    }
}
