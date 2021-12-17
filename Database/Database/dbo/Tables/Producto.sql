CREATE TABLE [dbo].[Producto]
(
	IdProducto INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_Producto PRIMARY KEY CLUSTERED(IdProducto)
   ,IdCategoria INT NOT NULL CONSTRAINT FK_Producto_Categoria FOREIGN KEY(IdCategoria)
    REFERENCES dbo.Categoria(IdCategoria)
   ,NombreProducto VARCHAR(50) NOT NULL
   ,Precio FLOAT NOT NULL
   ,Cantidad_Disponible INT NOT NULL
   ,Caracteristicas VARCHAR(50) NOT NULL
   ,Estado VARCHAR(50) NOT NULL
)
WITH (DATA_COMPRESSION = PAGE)
GO