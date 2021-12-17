DROP TABLE IF EXISTS #ClienteTemp

SELECT 
Cedula, NombreCliente, Apellidos, Direccion, Fecha_Nacimiento, Telefono INTO #ClienteTemp
FROM (
VALUES
(204560123, 'Juan','Perez','Alajuela','01/10/1995',78451245),
(132501459, 'Marcela','Rivas','Heredia','12/27/1991',12457896),
(312140369, 'Ernesto', 'Dominguez','Cartago','06/30/1997',68745685)

)AS TEMP (Cedula, NombreCliente, Apellidos, Direccion, Fecha_Nacimiento, Telefono)


----ACTUALIZAR DATOS---
UPDATE C SET
  C.NombreCliente= TC.NombreCliente,
  C.Apellidos= TC.Apellidos,
  C.Direccion= TC.Direccion,
  C.Fecha_Nacimiento= TC.Fecha_Nacimiento,
  C.Telefono= TC.Telefono
FROM dbo.Cliente C
INNER JOIN #ClienteTemp TC
    ON C.Cedula= TC.Cedula

----INSERTAR DATOS---
INSERT INTO dbo.Cliente(
Cedula, NombreCliente, Apellidos, Direccion, Fecha_Nacimiento, Telefono)
SELECT
Cedula, NombreCliente, Apellidos, Direccion, Fecha_Nacimiento, Telefono
FROM #ClienteTemp

EXCEPT
SELECT
Cedula, NombreCliente, Apellidos, Direccion, Fecha_Nacimiento, Telefono
FROM dbo.Cliente
GO