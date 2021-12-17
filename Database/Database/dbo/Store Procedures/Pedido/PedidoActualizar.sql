CREATE PROCEDURE [dbo].[PedidoActualizar]
	@IdPedido int, 
	@IdCliente int, 
	@FechaPedido Datetime

AS BEGIN
SET NOCOUNT ON
  BEGIN TRANSACTION TRASA
    BEGIN TRY
	UPDATE dbo.Pedido SET
	 IdCliente=@IdCliente, FechaPedido=@FechaPedido
	WHERE 
	       IdPedido=@IdPedido
	  COMMIT TRANSACTION TRASA
	  SELECT 0 AS CodeError, '' AS MsgError
  END TRY
  BEGIN CATCH
	   SELECT 
			 ERROR_NUMBER() AS CodeError,
			 ERROR_MESSAGE() AS MsgError
	   ROLLBACK TRANSACTION TRASA
   END CATCH
END