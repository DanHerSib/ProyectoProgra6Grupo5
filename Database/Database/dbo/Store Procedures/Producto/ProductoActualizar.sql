CREATE PROCEDURE [dbo].[ProductoActualizar]
	@IdProducto int,
	@IdCategoria int,
	@NombreProducto varchar(50),
	@Precio float,
	@Cantidad_Disponible int,
	@Caracteristicas varchar(50),
	@Estado varchar(50)
AS BEGIN
SET NOCOUNT ON
BEGIN TRANSACTION TRASA
    BEGIN TRY
	UPDATE dbo.Producto SET
	IdCategoria=@IdCategoria,
	NombreProducto=@NombreProducto,
	Precio=@Precio,
	Cantidad_Disponible=@Cantidad_Disponible,
	Caracteristicas=@Caracteristicas,
	Estado=@Estado
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