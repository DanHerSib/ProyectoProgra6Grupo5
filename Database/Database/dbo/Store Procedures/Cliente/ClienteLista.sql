CREATE PROCEDURE [dbo].[ClienteLista]
AS
	BEGIN
	SET NOCOUNT ON

	SELECT
	 Cedula, NombreCliente, Apellidos, 
	 Direccion, Fecha_Nacimiento, Telefono
	FROM Cliente

	END