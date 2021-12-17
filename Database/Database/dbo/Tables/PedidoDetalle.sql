CREATE TABLE [dbo].[PedidoDetalle]
(
	IdPedido INT NOT NULL CONSTRAINT FK_PedidoDetalle_Pedido FOREIGN KEY(IdPedido)
    REFERENCES dbo.Pedido(IdPedido),
	IdProducto INT NOT NULL CONSTRAINT FK_PedidoDetalle_Producto FOREIGN KEY(IdProducto)
    REFERENCES dbo.Producto(IdProducto),
	Cantidad INT NOT NULL,
	Envio FLOAT NOT NULL
)
