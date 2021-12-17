/*
Plantilla de script posterior a la implementación							
--------------------------------------------------------------------------------------
 Este archivo contiene instrucciones de SQL que se anexarán al script de compilación.		
 Use la sintaxis de SQLCMD para incluir un archivo en el script posterior a la implementación.			
 Ejemplo:      :r .\miArchivo.sql								
 Use la sintaxis de SQLCMD para hacer referencia a una variable en el script posterior a la implementación.		
 Ejemplo:      :setvar TableName miTabla							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
:r .\ScriptConfiguration\01-Cliente.sql
:r .\ScriptConfiguration\02-Categoria.sql
:r .\ScriptConfiguration\03-Producto.sql
:r .\ScriptConfiguration\04-Pedido.sql
:r .\ScriptConfiguration\05-PedidoDetalle.sql