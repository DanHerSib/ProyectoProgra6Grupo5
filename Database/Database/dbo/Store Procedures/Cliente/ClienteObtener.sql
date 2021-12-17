CREATE PROCEDURE [dbo].[ClienteObtener]
	@Cedula int= NULL
AS BEGIN
  SET NOCOUNT ON
  SELECT 
     C.Cedula,
     C.NombreCliente,
     C.Apellidos,
     C.Direccion,
     C.Fecha_Nacimiento,
     C.Telefono
    FROM dbo.Cliente C
    WHERE
		   (@Cedula IS NULL OR Cedula=@Cedula)
END