CREATE PROCEDURE [dbo].[ProductoObtener]
	@IdProducto int= NULL
AS BEGIN
  SET NOCOUNT ON
  SELECT 
     E.IdProducto,
     E.IdCategoria,
     E.NombreProducto,
     E.Precio,
     E.Cantidad_Disponible,
     E.Caracteristicas,
     E.Estado
    FROM dbo.Producto E
    WHERE
		   (@IdProducto IS NULL OR IdProducto=@IdProducto)
END