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
            Client = Client ?? new ClienteEntity();
            Det = Det ?? new DetalleEntity();
        }

        public int? IdPedido { get; set; }
        public int? IdCliente { get; set; }
        public virtual ClienteEntity Client { get; set; }
        public DateTime FechaPedido { get; set; } = DateTime.Now;
        public virtual DetalleEntity Det { get; set; }
    }
}