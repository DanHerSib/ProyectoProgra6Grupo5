using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApp.Pages.Producto
{
    public class EditModel : PageModel
    {
        private readonly IProductoService productoService;
        private readonly ICategoriaService categoriaService;
        public EditModel(IProductoService productoService, ICategoriaService categoriaService)
        {
            this.productoService = productoService;
            this.categoriaService = categoriaService;
        }

        [BindProperty]
        [FromBody]
        public ProductoEntity Entity { get; set; } = new ProductoEntity();

        public IEnumerable<CategoriaEntity> CategoriaLista { get; set; } = new List<CategoriaEntity>();
        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }
        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await productoService.GetById(new() { IdProducto = id });
                }
                CategoriaLista = await categoriaService.GetLista();
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
                if (Entity.IdProducto.HasValue)
                {
                    result = await productoService.Update(Entity);
                }
                else
                {
                    result = await productoService.Create(Entity);
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