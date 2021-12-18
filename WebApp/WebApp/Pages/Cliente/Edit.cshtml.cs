using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;
using WBL;

namespace WebApp.Pages.Cliente
{
    public class EditModel : PageModel
    {
        private readonly IClienteService clienteService;
        public EditModel(IClienteService ClienteService)
        {
            this.clienteService = ClienteService;
        }

        [BindProperty]
        [FromBody]

        public ClienteEntity Entity { get; set; } = new ClienteEntity();

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await clienteService.GetById(new() { Cedula = id });
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
                if (Entity.Cedula.HasValue)
                {
                    result = await clienteService.Update(Entity);
                }
                else
                {
                    result = await clienteService.Create(Entity);
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
