CREATE PROCEDURE [dbo].[CategoriaObtener]
	@IdCategoria int= NULL
AS BEGIN
  SET NOCOUNT ON
  SELECT 
     E.IdCategoria,
     E.Descripcion
    FROM dbo.Categoria E
    WHERE
		   (@IdCategoria IS NULL OR IdCategoria=@IdCategoria)
END