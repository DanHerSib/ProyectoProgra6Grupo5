using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class PedidoEntity
    {
        public PedidoEntity()
        {
            Produc = Produc ?? new ProductoEntity();
            Client = Client ?? new ClienteEntity();
        }

        public int? IdPedido { get; set; }
        public int? IdCliente { get; set; }
        public virtual ClienteEntity Client { get; set; }
        public DateTime FechaPedido { get; set; }
        public int? IdProducto { get; set; }
        public virtual ProductoEntity Produc { get; set; }
        public int? Cantidad { get; set; }
        public float SubTotal { get; set; }
        public float Envio { get; set; }
        public float IVA { get; set; }
        public float Total { get; set; }
    }
}