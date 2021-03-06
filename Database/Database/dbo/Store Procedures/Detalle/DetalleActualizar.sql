CREATE PROCEDURE [dbo].[DetalleActualizar]
	@IdDetalle int,
	@IdPedido int, 
	@IdProducto int,
    @Cantidad int,
	@Envio float

AS BEGIN
SET NOCOUNT ON
  BEGIN TRANSACTION TRASA
    BEGIN TRY
	UPDATE dbo.PedidoDetalle SET 
	 IdPedido=@IdPedido,IdProducto=@IdProducto, Cantidad=@Cantidad, 
	 Envio=@Envio
	WHERE 
	       IdDetalle=@IdDetalle
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