using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApp.Pages.Categoria
{
    public class EditModel : PageModel
    {
        private readonly ICategoriaService categoriaService;
        public EditModel(ICategoriaService categoriaService)
        {
            this.categoriaService = categoriaService;
        }

        public CategoriaEntity Entity { get; set; } = new CategoriaEntity();

        public int? id { get; set; }
        public async Task<IActionResult> OnGet()
        {
            try
            {
              
                if (id.HasValue)
                {
                    Entity = await categoriaService.GetById(new() { IdCategoria = id });
                }
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
                if (Entity.IdCategoria.HasValue)
                {
                    result = await categoriaService.Update(Entity);
                }
                else
                {
                    result = await categoriaService.Create(Entity);
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