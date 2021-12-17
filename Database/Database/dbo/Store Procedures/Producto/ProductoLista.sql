CREATE PROCEDURE [dbo].[ProductoLista]
AS
	BEGIN
	SET NOCOUNT ON
	SELECT
	 IdProducto, IdCategoria, NombreProducto, Precio, Cantidad_Disponible,
	 Caracteristicas, Estado
	FROM Producto
END