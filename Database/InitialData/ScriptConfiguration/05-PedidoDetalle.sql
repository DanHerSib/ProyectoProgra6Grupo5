DROP TABLE IF EXISTS #PedidoDetalleTemp

SELECT 
IdPedido, IdProducto, Cantidad, Envio INTO #PedidoDetalleTemp
FROM (
VALUES
(1, 2, 10, 2000),
(2, 3, 5, 1000),
(3, 1, 1, 3000),
(3, 2, 10, 2000),
(2, 1, 5, 3000)
)AS TEMP (IdPedido, IdProducto, Cantidad, Envio)

----ACTUALIZAR DATOS---
UPDATE P SET
	P.IdProducto=TM.IdProducto, P.Cantidad=TM.Cantidad,P.Envio=TM.Envio
FROM dbo.PedidoDetalle P
INNER JOIN #PedidoDetalleTemp TM
    ON P.IdPedido= TM.IdPedido  
    
----INSERTAR DATOS---
INSERT INTO dbo.PedidoDetalle(
IdPedido, IdProducto, Cantidad, Envio)
SELECT
IdPedido, IdProducto, Cantidad, Envio
FROM #PedidoDetalleTemp

EXCEPT
SELECT
IdPedido, IdProducto, Cantidad, Envio
FROM dbo.PedidoDetalle
GO