﻿CREATE PROCEDURE [dbo].[PedidoInsertar]
	@IdCliente int, 
	@FechaPedido Datetime

AS BEGIN
SET NOCOUNT ON
  BEGIN TRANSACTION TRASA
    BEGIN TRY
	INSERT INTO dbo.Pedido
	(IdCliente, FechaPedido)
	VALUES
	(@IdCliente, @FechaPedido)

  COMMIT TRANSACTION TRASA
  SELECT 0 AS CodeError, '' AS MsgError
  END TRY
  BEGIN CATCH
   SELECT 
         ERROR_NUMBER() AS CodeError,
		 ERROR_MESSAGE() AS MsgError
   ROLLBACK TRANSACTION TRASA
   END CATCH
 END