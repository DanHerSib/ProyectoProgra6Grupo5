using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WBL;
using Entity;
namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService productoService;

        public ProductoController(IProductoService productoService)
        {
            this.productoService = productoService;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductoEntity>> Get()
        {
            try
            {
                return await productoService.Get();
            }
            catch (Exception ex)
            {
                return new List<ProductoEntity>();
            }
        }

        [HttpGet("{id}")]
        public async Task<ProductoEntity> Get(int id)
        {
            try
            {
                return await productoService.GetById(new ProductoEntity { IdProducto = id });
            }
            catch (Exception ex)
            {

                return new ProductoEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }
        }

        [HttpPost]
        public async Task<DBEntity> Create(ProductoEntity entity)
        {
            try
            {
                return await productoService.Create(entity);
            }
            catch (Exception ex)
            {
                return new DBEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }
        }

        [HttpPut]
        public async Task<DBEntity> Update(ProductoEntity entity)
        {
            try
            {
                return await productoService.Update(entity);
            }
            catch (Exception ex)
            {
                return new DBEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }
        }

        [HttpDelete("{id}")]
        public async Task<DBEntity> Delete(int id)
        {
            try
            {
                return await productoService.Delete(new ProductoEntity() { IdProducto = id });
            }
            catch (Exception ex)
            {
                return new DBEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }
        }
    }
}