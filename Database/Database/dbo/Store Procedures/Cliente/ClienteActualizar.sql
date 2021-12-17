CREATE PROCEDURE [dbo].[ClienteActualizar]
	@Cedula int,
	@NombreCliente varchar(50),
	@Apellidos VARCHAR(50),
	@Direccion VARCHAR(50),
	@Fecha_Nacimiento DATETIME,
	@Telefono INT
AS BEGIN
SET NOCOUNT ON
BEGIN TRANSACTION TRASA
    BEGIN TRY
	UPDATE dbo.Cliente SET
	NombreCliente=@NombreCliente,
	Apellidos=@Apellidos,
	Direccion=@Direccion,
	Fecha_Nacimiento=@Fecha_Nacimiento,
	Telefono=@Telefono
	WHERE 
	       Cedula=@Cedula
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