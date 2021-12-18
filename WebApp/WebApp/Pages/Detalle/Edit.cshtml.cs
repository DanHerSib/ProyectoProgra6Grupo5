using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApp.Pages.Detalle
{
    public class EditModel : PageModel
    {
        private readonly IDetalleService detalleService;
        private readonly IProductoService productoService;
        private readonly IPedidoService pedidoService;
        public EditModel(IDetalleService detalleService, IProductoService productoService, IPedidoService pedidoService)
        {
            this.detalleService = detalleService;
            this.productoService = productoService;
            this.pedidoService = pedidoService;
        }

        [BindProperty]
        [FromBody]
        public DetalleEntity Entity { get; set; } = new DetalleEntity();

        public IEnumerable<ProductoEntity> ProductoLista { get; set; } = new List<ProductoEntity>();
        [BindProperty(SupportsGet = true)]
        public IEnumerable<PedidoEntity> PedidoLista { get; set; } = new List<PedidoEntity>();
        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }
        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await detalleService.GetById(new() { IdDetalle = id });
                }
                ProductoLista = await productoService.GetLista();
                PedidoLista = await pedidoService.GetLista();
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
                if (Entity.IdDetalle.HasValue)
                {
                    result = await detalleService.Update(Entity);
                }
                else
                {
                    result = await detalleService.Create(Entity);
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