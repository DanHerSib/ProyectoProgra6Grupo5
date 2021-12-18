CREATE PROCEDURE [dbo].[DetalleLista]
AS
	BEGIN
	SET NOCOUNT ON
	SELECT
	 IdPedido, IdProducto, Cantidad, Envio
	FROM PedidoDetalle
END