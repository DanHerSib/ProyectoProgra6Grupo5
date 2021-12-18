using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ProductoEntity : DBEntity
    {
        public ProductoEntity()
        {
            Cat = Cat ?? new CategoriaEntity();
        }
        public int? IdProducto { get; set; }
        public int? IdCategoria { get; set; }
        public virtual CategoriaEntity Cat { get; set; }
        public string NombreProducto { get; set; }
        public float Precio { get; set; }
        public int? Cantidad_Disponible { get; set; }
        public string Caracteristicas { get; set; }
        public string Estado { get; set; }
    }
}
