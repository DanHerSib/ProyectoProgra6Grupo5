using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;

namespace WebApp.Pages.Detalle
{
    public class GridModel : PageModel
    {
        private readonly IDetalleService detalleService;
        public GridModel(IDetalleService detalleService)
        {
            this.detalleService = detalleService;
        }

        public IEnumerable<DetalleEntity> GridList { get; set; } = new List<DetalleEntity>();
        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await detalleService.Get();
                return Page();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        public async Task<IActionResult> OnDeleteEliminar(int id)
        {
            try
            {
                var result = await detalleService.Delete(new() { IdPedido = id });
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }
        }
    }
}
