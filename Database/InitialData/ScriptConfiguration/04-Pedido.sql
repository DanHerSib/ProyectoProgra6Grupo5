DROP TABLE IF EXISTS #PedidoTemp

SELECT 
IdPedido, IdCliente, FechaPedido INTO #PedidoTemp
FROM (
VALUES
(1, 204560123, '11/12/2021'),
(2, 312140369, '11/12/2021'),
(3, 132501459, '09/12/2021')
)AS TEMP (IdPedido, IdCliente, FechaPedido)

----ACTUALIZAR DATOS---
UPDATE P SET
	P.IdCliente=TM.IdCliente, P.FechaPedido=TM.FechaPedido
FROM dbo.Pedido P
INNER JOIN #PedidoTemp TM
    ON P.IdPedido= TM.IdPedido  
    
----INSERTAR DATOS---
SET IDENTITY_INSERT dbo.Pedido ON

INSERT INTO dbo.Pedido(
IdPedido, IdCliente, FechaPedido)
SELECT
IdPedido, IdCliente, FechaPedido
FROM #PedidoTemp

EXCEPT
SELECT
IdPedido, IdCliente, FechaPedido
FROM dbo.Pedido

SET IDENTITY_INSERT dbo.Pedido OFF
GO