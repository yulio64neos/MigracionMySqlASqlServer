using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigracionDAL.Models
{
    public class empleados
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apaterno { get; set; }
        public string amaterno { get; set; }
        public int sexo { get; set; }
        public string puesto { get; set; }
        public string correo { get; set; }
        public string celular { get; set; }
        public int estadoCivil { get; set; }
    }
}
