﻿CREATE PROCEDURE [SelectOrderItemList_SP]
	@order_id INT
AS
	SELECT o.order_item_id,
		   o.order_id,
	       o.order_customer_id,
		   o.order_item_product_id,
		   o.order_item_quantity,
		   o.order_item_product_price,
		   o.order_item_subtotal
    FROM dbo.Orders o 
	WHERE order_id = @order_id;

--- test the Stored Procedure
declare @order_id int =1;
EXEC [SelectOrderItemList_SP] 	@order_id ;
