CREATE PROCEDURE [dbo].[UsuarioObtener]
	  @IdUsuario int = NULL
AS BEGIN
  SET NOCOUNT ON
  SELECT 
     IdUsuario,
	 Usuario,
     Nombre
    FROM dbo.Usuario
    WHERE
    (@IdUsuario IS NULL OR IdUsuario=@IdUsuario)
END