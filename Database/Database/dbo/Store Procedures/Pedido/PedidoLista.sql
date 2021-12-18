CREATE PROCEDURE [dbo].[PedidoLista]
AS
	BEGIN
	SET NOCOUNT ON
	SELECT
	 IdPedido, IdCliente, FechaPedido
	FROM Pedido
END