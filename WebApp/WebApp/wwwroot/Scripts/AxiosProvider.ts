
namespace App.AxiosProvider   {
    export const ProductoEliminar = (id) => axios.delete<DBEntity>("Producto/Grid?handler=Eliminar&id=" + id).then(({ data }) => data);
    export const ProductoGuardar = (entity) => axios.post<DBEntity>("Producto/Edit", entity).then(({ data }) => data);

    export const PedidoEliminar = (id) => axios.delete<DBEntity>("Pedido/Grid?handler=Eliminar&id=" + id).then(({ data }) => data);
    export const PedidoGuardar = (entity) => axios.post<DBEntity>("Pedido/Edit", entity).then(({ data }) => data);

    export const DetalleEliminar = (id) => axios.delete<DBEntity>("Detalle/Grid?handler=Eliminar&id=" + id).then(({ data }) => data);
    export const DetalleGuardar = (entity) => axios.post<DBEntity>("Detalle/Edit", entity).then(({ data }) => data);

    export const ClienteEliminar = (id) => axios.delete<DBEntity>("Cliente/Grid?handler=Eliminar&id=" + id).then(({ data }) => data);
    export const ClienteGuardar = (entity) => axios.post<DBEntity>("Cliente/Edit", entity).then(({ data }) => data);

    export const CategoriaEliminar = (id) => axios.delete<DBEntity>("Categoria/Grid?handler=Eliminar&id=" + id).then(({ data }) => data);
    export const CategoriaGuardar = (entity) => axios.post<DBEntity>("Categoria/Edit", entity).then(({ data }) => data);
}




