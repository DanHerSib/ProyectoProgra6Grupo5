DROP TABLE IF EXISTS #CategoriaTemp

SELECT 
IdCategoria, Descripcion INTO #CategoriaTemp
FROM (
VALUES
(1, 'MUEBLES DE SALA'),
(2, 'MUEBLES DE COCINA'),
(3, 'DORMITORIO')

)AS TEMP (IdCategoria, Descripcion)


----ACTUALIZAR DATOS---
UPDATE P SET
  P.Descripcion= TM.Descripcion
FROM Dbo.Categoria P
INNER JOIN #CategoriaTemp TM
    ON P.IdCategoria= TM.IdCategoria


----INSERTAR DATOS---
SET IDENTITY_INSERT dbo.Categoria ON

INSERT INTO dbo.Categoria(
IdCategoria, Descripcion)
SELECT
IdCategoria, Descripcion
FROM #CategoriaTemp

EXCEPT
SELECT
IdCategoria, Descripcion
FROM dbo.Categoria

SET IDENTITY_INSERT dbo.Categoria OFF
GO