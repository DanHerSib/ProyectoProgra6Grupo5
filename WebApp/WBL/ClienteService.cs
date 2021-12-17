using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface IClienteService
    {
        Task<DBEntity> Create(ClienteEntity entity);
        Task<DBEntity> Delete(ClienteEntity entity);
        Task<IEnumerable<ClienteEntity>> Get();
        Task<ClienteEntity> GetById(ClienteEntity entity);
        Task<DBEntity> Update(ClienteEntity entity);
        Task<IEnumerable<ClienteEntity>> GetLista();
    }

    public class ClienteService : IClienteService
    {
        private readonly IDataAccess sql;

        public ClienteService(IDataAccess _sql)
        {
            sql = _sql;
        }

        #region MetodosCrud
        //Metodo Get
        public async Task<IEnumerable<ClienteEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<ClienteEntity>("dbo.ClienteObtener");

                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ClienteEntity>> GetLista()
        {
            try
            {
                var result = sql.QueryAsync<ClienteEntity>("dbo.ClienteLista");
                return await result;
            }
            catch (Exception EX)
            {
                throw;
            }
        }

        //Metodo GetById
        public async Task<ClienteEntity> GetById(ClienteEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<ClienteEntity>("dbo.ClienteObtener", new
                { entity.Cedula });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo Create
        public async Task<DBEntity> Create(ClienteEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.ClienteInsertar", new
                {
                    entity.Cedula,
                    entity.NombreCliente,
                    entity.Apellidos,
                    entity.Direccion,
                    entity.Fecha_Nacimiento,
                    entity.Telefono
                });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo Update
        public async Task<DBEntity> Update(ClienteEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.ClienteActualizar", new
                {
                    entity.Cedula,
                    entity.NombreCliente,
                    entity.Apellidos,
                    entity.Direccion,
                    entity.Fecha_Nacimiento,
                    entity.Telefono
                });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo Delete
        public async Task<DBEntity> Delete(ClienteEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.ClienteEliminar", new
                {
                    entity.Cedula,
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