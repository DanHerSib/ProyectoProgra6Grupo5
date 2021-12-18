CREATE PROCEDURE [dbo].[DetalleInsertar]
	@IdPedido int,  
	@IdProducto int,
    @Cantidad int,
	@Envio float
AS BEGIN
SET NOCOUNT ON
  BEGIN TRANSACTION TRASA
  --Validate quantity available
  DECLARE @Cantidad_Disponible int = (SELECT Cantidad_Disponible FROM dbo.Producto WHERE IdProducto=@IdProducto);
  IF(@Cantidad<=@Cantidad_Disponible)
    BEGIN TRY	
	INSERT INTO dbo.PedidoDetalle
	(IdPedido, IdProducto, Cantidad, Envio)
	VALUES
	(@IdPedido, @IdProducto, @Cantidad, @Envio)
	--Update Products--
	UPDATE dbo.Producto SET 
			Cantidad_Disponible = @Cantidad_Disponible - @Cantidad
			WHERE 
			dbo.Producto.IdProducto=@IdProducto
  COMMIT TRANSACTION TRASA
  SELECT 0 AS CodeError, '' AS MsgError
  END TRY 
  BEGIN CATCH
   SELECT 
         ERROR_NUMBER() AS CodeError,
		 ERROR_MESSAGE() AS MsgError
   ROLLBACK TRANSACTION TRASA
   END CATCH
   ELSE BEGIN
		SELECT -1 AS CodeError, 'La cantidad ingresada no esta disponible!' AS MsgError
   END
 END