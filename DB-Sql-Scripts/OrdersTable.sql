-- order_items table
CREATE TABLE orders (
  order_item_id INT NOT NULL,
  order_id INT NOT NULL,
  order_customer_id INT NOT NULL,
  order_item_product_id INT NOT NULL,
  order_item_quantity INT NOT NULL,  
  order_item_product_price FLOAT NOT NULL,
  order_item_subtotal FLOAT NOT NULL,
  PRIMARY KEY (order_item_id)
);

ALTER TABLE orders ADD CONSTRAINT pk_order_item_id PRIMARY KEY CLUSTERED (order_item_id);