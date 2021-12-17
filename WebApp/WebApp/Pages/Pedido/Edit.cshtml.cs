using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApp.Pages.Pedido
{
    public class EditModel : PageModel
    {
        private readonly IPedidoService pedidoService;
        private readonly IProductoService productoService;
        private readonly IClienteService clienteService;
        public EditModel(IPedidoService pedidoService, IProductoService productoService, IClienteService clienteService)
        {
            this.pedidoService = pedidoService;
            this.productoService = productoService;
            this.clienteService = clienteService;
        }

        [BindProperty]
        [FromBody]
        public PedidoEntity Entity { get; set; } = new PedidoEntity();

        public IEnumerable<ProductoEntity> ProductoLista { get; set; } = new List<ProductoEntity>();
        [BindProperty(SupportsGet = true)]
        public IEnumerable<ClienteEntity> ClienteLista { get; set; } = new List<ClienteEntity>();
        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }
        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await pedidoService.GetById(new() { IdPedido = id });
                }
                ProductoLista = await productoService.GetLista();
                ClienteLista = await clienteService.GetLista();
                return Page();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                var result = new DBEntity();
                if (Entity.IdPedido.HasValue)
                {
                    result = await pedidoService.Update(Entity);
                }
                else
                {
                    result = await pedidoService.Create(Entity);
                }
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }
        }
    }
}