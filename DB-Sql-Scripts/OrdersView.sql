﻿CREATE VIEW OrderDetails_VW
AS SELECT o.order_item_product_id,
		  o.order_item_quantity,
		  o.order_item_product_price,
		  o.order_item_subtotal
FROM Orders o
GO;