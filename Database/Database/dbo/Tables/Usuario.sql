CREATE TABLE [dbo].[Usuario]
(
	IdUsuario INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_Usuario PRIMARY KEY CLUSTERED(IdUsuario)
	, Usuario VARCHAR(250) NOT NULL
	, Nombre varchar(500) not null
	, Contrasena VARBINARY(max) NOT NULL
	, Estado BIT NOT NULL
)