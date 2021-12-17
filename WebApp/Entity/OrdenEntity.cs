using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class OrdenEntity
    {
        public OrdenEntity()
        {
            Produc = Produc ?? new ProductoEntity();
        }
        public int? IdOrden { get; set; }
        public int? IdProducto { get; set; }
        public virtual ProductoEntity Produc { get; set; }
        public int? CantidadProducto { get; set; }
        public string Estado { get; set; }
    }
}
