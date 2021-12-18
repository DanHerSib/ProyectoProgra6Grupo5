using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ClienteEntity
    {
        public int? Cedula { get; set; }
        public string NombreCliente { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Telefono { get; set; }
    }
}
