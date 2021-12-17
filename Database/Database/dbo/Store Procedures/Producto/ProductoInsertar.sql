CREATE PROCEDURE [dbo].[ProductoInsertar]
	
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
	
	INSERT INTO dbo.Producto
	(
	IdCategoria,
	NombreProducto,
	Precio,
	Cantidad_Disponible,
	Caracteristicas,
	Estado
	)
	VALUES
	(
	@IdCategoria,
	@NombreProducto,
	@Precio,
	@Cantidad_Disponible,
	@Caracteristicas,
	@Estado
	)

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