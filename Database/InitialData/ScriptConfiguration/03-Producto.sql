DROP TABLE IF EXISTS #ProductoTemp

SELECT 
IdProducto, IdCategoria, NombreProducto, Precio, Cantidad_Disponible, Caracteristicas, Estado INTO #ProductoTemp
FROM (
VALUES
(1, 2,'Sillon L', 155000, 100,'Madera Natural','DISPONIBLE'),
(2, 3,'Mesa de noche', 5000000, 20,'Color Beige','LIMITADO'),
(3, 1,'Gabetero', 100000, 0,'Color Gris','AGOTADO')
)AS TEMP (IdProducto, IdCategoria, NombreProducto, Precio, Cantidad_Disponible, Caracteristicas, Estado)

----ACTUALIZAR DATOS---
UPDATE P SET
  P.IdCategoria= TM.IdCategoria,
  P.NombreProducto= TM.NombreProducto,
  P.Cantidad_Disponible= TM.Cantidad_Disponible,
  P.Caracteristicas= TM.Caracteristicas,
  P.Estado= TM.Estado
FROM dbo.Producto P
INNER JOIN #ProductoTemp TM
    ON P.IdProducto= TM.IdProducto  
    
----INSERTAR DATOS---
SET IDENTITY_INSERT dbo.Producto ON

INSERT INTO dbo.Producto(
IdProducto, IdCategoria, NombreProducto, Precio, Cantidad_Disponible, Caracteristicas, Estado)
SELECT
IdProducto, IdCategoria, NombreProducto, Precio, Cantidad_Disponible, Caracteristicas, Estado
FROM #ProductoTemp

EXCEPT
SELECT
IdProducto, IdCategoria, NombreProducto, Precio, Cantidad_Disponible, Caracteristicas, Estado
FROM dbo.Producto

SET IDENTITY_INSERT dbo.Producto OFF
GO