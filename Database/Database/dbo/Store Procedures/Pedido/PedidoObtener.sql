CREATE PROCEDURE [dbo].[PedidoObtener]
      @IdPedido int= NULL
AS BEGIN
  SET NOCOUNT ON

  SELECT 
     PE.IdPedido, PE.IdCliente, PE.FechaPedido, DE.IdProducto,
     DE.Cantidad, PR.Precio AS PrecioUnitario, (DE.Cantidad * PR.Precio) AS PrecioTotal, 
     DE.Envio, DE.Envio +(DE.Cantidad * PR.Precio) AS SubTotal,
     DE.Envio +((DE.Cantidad * PR.Precio)*0.13) AS IVA, 
     (DE.Envio +(DE.Cantidad * PR.Precio)+(DE.Envio +((DE.Cantidad * PR.Precio)*0.13))) AS Total,
     --Producto--
     PR.IdProducto, PR.IdCategoria, PR.NombreProducto, 
     PR.Cantidad_Disponible, PR.Caracteristicas, PR.Estado,
     --Cliente--
     C.Cedula, C.NombreCliente, C.Apellidos, C.Direccion,
     C.Fecha_Nacimiento, C.Telefono
     --Joins--
    FROM dbo.Pedido PE
    INNER JOIN dbo.PedidoDetalle DE
        ON PE.IdPedido = DE.IdPedido
    INNER JOIN dbo.Producto PR
       ON DE.IdProducto = PR.IdProducto
    INNER JOIN dbo.Cliente C 
       ON PE.IdCliente = C.Cedula 
    WHERE
    (@IdPedido IS NULL OR PE.IdPedido = @IdPedido)
END