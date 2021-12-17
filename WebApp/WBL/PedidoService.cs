using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WBL
{
    public interface IPedidoService
    {
        Task<DBEntity> Create(PedidoEntity entity);
        Task<DBEntity> Delete(PedidoEntity entity);
        Task<IEnumerable<PedidoEntity>> Get();
        Task<PedidoEntity> GetById(PedidoEntity entity);
        Task<DBEntity> Update(PedidoEntity entity);
        Task<IEnumerable<PedidoEntity>> GetLista();
    }
    public class PedidoService : IPedidoService
    {
        private readonly IDataAccess sql;
        public PedidoService(IDataAccess _sql)
        {
            sql = _sql;
        }
        #region MetodosCrud
        //Metodo Get
        public async Task<IEnumerable<PedidoEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<PedidoEntity, ProductoEntity>("dbo.PedidoObtener", "IdPedido, IdProducto, IdCliente");
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Metodo Get Lista
        public async Task<IEnumerable<PedidoEntity>> GetLista()
        {
            try
            {
                var result = sql.QueryAsync<PedidoEntity>("PedidoLista");
                return await result;
            }
            catch (Exception EX)
            {
                throw;
            }
        }
        //Metodo GetById
        public async Task<PedidoEntity> GetById(PedidoEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<PedidoEntity>("dbo.PedidoObtener", new
                { entity.IdPedido });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Metodo Create
        public async Task<DBEntity> Create(PedidoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.PedidoInsertar", new
                {
                    entity.IdCliente,
                    entity.FechaPedido,
                    entity.IdProducto,
                    entity.Cantidad,
                    entity.SubTotal,
                    entity.Envio,
                    entity.IVA,
                    entity.Total
                });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Metodo Update
        public async Task<DBEntity> Update(PedidoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.PedidoActualizar", new
                {
                    entity.IdPedido,
                    entity.IdCliente,
                    entity.FechaPedido,
                    entity.IdProducto,
                    entity.Cantidad,
                    entity.SubTotal,
                    entity.Envio,
                    entity.IVA,
                    entity.Total
                });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Metodo Delete
        public async Task<DBEntity> Delete(PedidoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.PedidoEliminar", new
                {
                    entity.IdPedido,
                });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}