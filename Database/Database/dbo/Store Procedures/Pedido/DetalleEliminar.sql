CREATE PROCEDURE [dbo].[DetalleEliminar]
 @IdPedido int
AS BEGIN
SET NOCOUNT ON
  BEGIN TRANSACTION TRASA
    BEGIN TRY
	--Devolver producto--
			DECLARE @DevolverCantidad int =(SELECT Cantidad FROM dbo.PedidoDetalle);
			DECLARE @IdProducto int =(SELECT IdProducto FROM dbo.PedidoDetalle);
			DECLARE @Cantidad_Disponible int =(SELECT Cantidad_Disponible FROM dbo.Producto);
			--Update Products--
			UPDATE dbo.Producto SET 
			Cantidad_Disponible = @Cantidad_Disponible + @DevolverCantidad
			WHERE 
			dbo.Producto.IdProducto=@IdProducto
			--Delete detail--
            DELETE FROM dbo.PedidoDetalle WHERE dbo.PedidoDetalle.IdPedido=@IdPedido
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