CREATE PROCEDURE [dbo].[ProductoObtener]
	@IdProducto int= NULL
AS BEGIN
  SET NOCOUNT ON
  SELECT 
     E.IdProducto,
     E.NombreProducto,
     E.Precio,
     E.Cantidad_Disponible,
     E.Caracteristicas,
     E.Estado,
     --Categoria--
     Cat.IdCategoria,
     Cat.Descripcion
    FROM dbo.Producto E
    INNER JOIN Categoria Cat
    ON E.IdCategoria = Cat.IdCategoria
    WHERE
		   (@IdProducto IS NULL OR IdProducto=@IdProducto)
END