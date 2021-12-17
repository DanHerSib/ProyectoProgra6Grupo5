using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApp.Pages.Orden
{
    public class EditModel : PageModel
    {
        private readonly IOrdenService ordenService;
        private readonly IProductoService productoService;
        public EditModel(IOrdenService ordenService, IProductoService productoService)
        {
            this.ordenService = ordenService;
            this.productoService = productoService;
        }

        [BindProperty]
        [FromBody]
        public OrdenEntity Entity { get; set; } = new OrdenEntity();

        public IEnumerable<ProductoEntity> ProductoLista { get; set; } = new List<ProductoEntity>();
        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }
        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await ordenService.GetById(new() { IdOrden = id });
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
                if (Entity.IdOrden.HasValue)
                {
                    result = await ordenService.Update(Entity);
                }
                else
                {
                    result = await ordenService.Create(Entity);
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