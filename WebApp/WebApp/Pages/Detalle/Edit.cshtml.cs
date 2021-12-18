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
        public EditModel(IDetalleService detalleService, IProductoService productoService)
        {
            this.detalleService = detalleService;
            this.productoService = productoService;
        }

        [BindProperty]
        [FromBody]
        public DetalleEntity Entity { get; set; } = new DetalleEntity();

        public IEnumerable<ProductoEntity> ProductoLista { get; set; } = new List<ProductoEntity>();
        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }
        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await detalleService.GetById(new() { IdPedido = id });
                }
                ProductoLista = await productoService.GetLista();
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