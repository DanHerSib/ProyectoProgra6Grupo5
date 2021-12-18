using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WBL
{
    public interface ICategoriaService
    {
        Task<DBEntity> Create(CategoriaEntity entity);
        Task<DBEntity> Delete(CategoriaEntity entity);
        Task<IEnumerable<CategoriaEntity>> Get();
        Task<CategoriaEntity> GetById(CategoriaEntity entity);
        Task<DBEntity> Update(CategoriaEntity entity);
        Task<IEnumerable<CategoriaEntity>> GetLista();
    }
    public class CategoriaService : ICategoriaService
    {
        private readonly IDataAccess sql;
        public CategoriaService(IDataAccess _sql)
        {
            sql = _sql;
        }
        #region MetodosCrud
        //Metodo Get
        public async Task<IEnumerable<CategoriaEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<CategoriaEntity>("dbo.CategoriaObtener");
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Metodo Get Lista
        public async Task<IEnumerable<CategoriaEntity>> GetLista()
        {
            try
            {
                var result = sql.QueryAsync<CategoriaEntity>("CategoriaLista");
                return await result;
            }
            catch (Exception EX)
            {
                throw;
            }
        }
        //Metodo GetById
        public async Task<CategoriaEntity> GetById(CategoriaEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<CategoriaEntity>("dbo.CategoriaObtener", new
                { entity.IdCategoria });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Metodo Create
        public async Task<DBEntity> Create(CategoriaEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.CategoriaInsertar", new
                {
                    entity.Descripcion
                });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Metodo Update
        public async Task<DBEntity> Update(CategoriaEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.CategoriaActualizar", new
                {
                    entity.IdCategoria,
                    entity.Descripcion
                });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Metodo Delete
        public async Task<DBEntity> Delete(CategoriaEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.CategoriaEliminar", new
                {
                    entity.IdCategoria,
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