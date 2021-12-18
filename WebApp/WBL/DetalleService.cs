using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WBL
{
    public interface IDetalleService
    {
        Task<DBEntity> Create(DetalleEntity entity);
        Task<DBEntity> Delete(DetalleEntity entity);
        Task<IEnumerable<DetalleEntity>> Get();
        Task<DetalleEntity> GetById(DetalleEntity entity);
        Task<DBEntity> Update(DetalleEntity entity);
        Task<IEnumerable<DetalleEntity>> GetLista();
    }
    public class DetalleService : IDetalleService
    {
        private readonly IDataAccess sql;
        public DetalleService(IDataAccess _sql)
        {
            sql = _sql;
        }
        #region MetodosCrud
        //Metodo Get
        public async Task<IEnumerable<DetalleEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<DetalleEntity, ProductoEntity>("dbo.DetalleObtener","IdDetalle, IdProducto");
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Metodo Get Lista
        public async Task<IEnumerable<DetalleEntity>> GetLista()
        {
            try
            {
                var result = sql.QueryAsync<DetalleEntity>("DetalleLista");
                return await result;
            }
            catch (Exception EX)
            {
                throw;
            }
        }
        //Metodo GetById
        public async Task<DetalleEntity> GetById(DetalleEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<DetalleEntity>("dbo.DetalleObtener", new
                { entity.IdDetalle });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Metodo Create
        public async Task<DBEntity> Create(DetalleEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.DetalleInsertar", new
                {
                    entity.Ped.IdPedido,
                    entity.IdProducto,
                    entity.Cantidad,
                    entity.Envio
                });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Metodo Update
        public async Task<DBEntity> Update(DetalleEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.DetalleActualizar", new
                {
                    entity.IdDetalle,
                    entity.Ped.IdPedido,
                    entity.IdProducto,
                    entity.Cantidad,
                    entity.Envio
                });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Metodo Delete
        public async Task<DBEntity> Delete(DetalleEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.DetalleEliminar", new
                {
                    entity.IdDetalle,
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