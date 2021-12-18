CREATE PROCEDURE [dbo].[DetalleObtener]
   @IdDetalle int= NULL
AS BEGIN
  SET NOCOUNT ON

  SELECT 
  DE.IdDetalle,
  --Encabezado--
  DE.IdPedido,
     --Producto--
     PR.IdProducto, PR.NombreProducto, DE.Cantidad,
     PR.Precio AS PrecioUnitario, (DE.Cantidad * PR.Precio) AS PrecioTotal, 
     DE.Envio, DE.Envio +(DE.Cantidad * PR.Precio) AS SubTotal,
     (DE.Envio +(DE.Cantidad * PR.Precio))*0.13 AS IVA, 
     (DE.Envio +(DE.Cantidad * PR.Precio)+(DE.Envio +(DE.Cantidad * PR.Precio))*0.13) AS Total
     --Joins--
    FROM dbo.PedidoDetalle DE
    INNER JOIN dbo.Pedido PE
        ON PE.IdPedido = DE.IdPedido
    INNER JOIN dbo.Producto PR
       ON DE.IdProducto = PR.IdProducto
    WHERE
    (@IdDetalle IS NULL OR IdDetalle = @IdDetalle)
END