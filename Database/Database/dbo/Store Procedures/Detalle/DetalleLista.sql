CREATE PROCEDURE [dbo].[DetalleLista]
AS
	BEGIN
	SET NOCOUNT ON
	SELECT
	 IdDetalle, IdPedido, IdProducto, Cantidad, Envio
	FROM PedidoDetalle
END