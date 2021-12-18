using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WBL;

namespace WebApp.Pages.Categoria
{
    public class GridModel : PageModel
    {
        private readonly ICategoriaService categoriaService;
        public GridModel(ICategoriaService CategoriaService)
        {
            this.categoriaService = CategoriaService;
        }
        public IEnumerable<CategoriaEntity> GridList { get; set; } = new List<CategoriaEntity>();
        //Get method
        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await categoriaService.Get();
                return Page();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        //Delete Method
        public async Task<IActionResult> OnDeleteEliminar(int id)
        {
            try
            {
                var result = await categoriaService.Delete(new() { IdCategoria = id });
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }
        }
    }
}