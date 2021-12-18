CREATE PROCEDURE [dbo].[PedidoObtener]
      @IdPedido int= NULL
AS BEGIN
  SET NOCOUNT ON

  SELECT 
  --Encabezado--
  PE.IdPedido, PE.FechaPedido,
  --Cliente--
     C.Cedula, C.NombreCliente, C.Apellidos, C.Direccion, C.Fecha_Nacimiento, C.Telefono
     --Joins--
    FROM dbo.Pedido PE
    INNER JOIN dbo.Cliente C 
       ON PE.IdCliente = C.Cedula 
    WHERE
    (@IdPedido IS NULL OR PE.IdPedido = @IdPedido)
END