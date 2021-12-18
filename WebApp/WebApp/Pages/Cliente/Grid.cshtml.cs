using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;

namespace WebApp.Pages.Cliente
{
    public class GridModel : PageModel
    {
        private readonly IClienteService clienteService;
        public GridModel(IClienteService ClienteService)
        {
            this.clienteService = ClienteService;
        }

        public IEnumerable<ClienteEntity> GridList { get; set; } = new List<ClienteEntity>();
        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await clienteService.Get();
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
                var result = await clienteService.Delete(new() { Cedula = id });
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }
        }
    }
}
