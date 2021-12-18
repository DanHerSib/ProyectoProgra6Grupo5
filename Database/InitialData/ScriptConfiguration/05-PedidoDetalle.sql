DROP TABLE IF EXISTS #PedidoDetalleTemp

SELECT 
IdDetalle,IdPedido, IdProducto, Cantidad, Envio INTO #PedidoDetalleTemp
FROM (
VALUES
(1,1, 2, 10, 2000),
(2,2, 3, 5, 1000),
(3,3, 1, 1, 3000),
(4,3, 2, 10, 2000),
(5,2, 1, 5, 3000)
)AS TEMP (IdDetalle, IdPedido, IdProducto, Cantidad, Envio)

----ACTUALIZAR DATOS---
UPDATE P SET
	P.IdPedido=TM.IdPedido,P.IdProducto=TM.IdProducto, P.Cantidad=TM.Cantidad,P.Envio=TM.Envio
FROM dbo.PedidoDetalle P
INNER JOIN #PedidoDetalleTemp TM
    ON P.IdDetalle= TM.IdDetalle  
    
----INSERTAR DATOS---
INSERT INTO dbo.PedidoDetalle(
IdDetalle, IdPedido, IdProducto, Cantidad, Envio)
SELECT
IdDetalle, IdPedido, IdProducto, Cantidad, Envio
FROM #PedidoDetalleTemp

EXCEPT
SELECT
IdDetalle, IdPedido, IdProducto, Cantidad, Envio
FROM dbo.PedidoDetalle
GO