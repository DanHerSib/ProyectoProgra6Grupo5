using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ClienteEntity :DBEntity
    {
        public int? Cedula { get; set; }
        public string NombreCliente { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public DateTime Fecha_Nacimiento { get; set; } = DateTime.Now;
        public string Telefono { get; set; }
    }
}
