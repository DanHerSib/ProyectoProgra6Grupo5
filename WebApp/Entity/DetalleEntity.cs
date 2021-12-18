using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class DetalleEntity
    {
        public DetalleEntity()
        {
            Produc = Produc ?? new ProductoEntity();
            Ped = Ped ?? new PedidoEntity();
        }

        public int? IdPedido { get; set; }
        public virtual PedidoEntity Ped { get; set; }
        public int? IdProducto { get; set; }
        public virtual ProductoEntity Produc { get; set; }
        public int? Cantidad { get; set; }
        public float Envio { get; set; }
        public float SubTotal { get; set; }
        public float IVA { get; set; }
        public float Total { get; set; }
    }
}