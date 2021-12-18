CREATE TABLE [dbo].[PedidoDetalle]
(
IdDetalle INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_Detalle PRIMARY KEY CLUSTERED(IdDetalle),
	IdPedido INT NOT NULL CONSTRAINT FK_PedidoDetalle_Pedido FOREIGN KEY(IdPedido)
    REFERENCES dbo.Pedido(IdPedido),
	IdProducto INT NOT NULL CONSTRAINT FK_PedidoDetalle_Producto FOREIGN KEY(IdProducto)
    REFERENCES dbo.Producto(IdProducto),
	Cantidad INT NOT NULL,
	Envio FLOAT NOT NULL
)
