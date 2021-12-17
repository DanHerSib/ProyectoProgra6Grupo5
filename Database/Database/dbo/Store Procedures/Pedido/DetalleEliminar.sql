CREATE PROCEDURE [dbo].[DetalleEliminar]
 @IdPedido int,
 @IdProducto int,
 @Cantidad int
AS BEGIN
SET NOCOUNT ON
  BEGIN TRANSACTION TRASA
    BEGIN TRY
            DELETE FROM dbo.PedidoDetalle WHERE IdPedido=@IdPedido
			--Update Products--
			UPDATE dbo.Producto SET 
			Cantidad_Disponible = dbo.Producto.Cantidad_Disponible+@Cantidad
			WHERE 
			IdProducto=@IdProducto
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