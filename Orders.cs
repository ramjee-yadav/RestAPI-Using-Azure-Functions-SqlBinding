using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionApp_Isolated_SqlBinding
{
    public class Orders
    {
        public int order_item_id { get; set; }
        public int order_id { get; set; }
        public int order_customer_id { get; set; }
        public int order_item_product_id { get; set; }
        public int order_item_quantity { get; set; }        
        public float order_item_product_price { get; set; }
        public float order_item_subtotal { get; set; }

    }
    public class OrdersView    {
        
        public int order_item_product_id { get; set; }
        public int order_item_quantity { get; set; }
        public float order_item_product_price { get; set; }
        public float order_item_subtotal { get; set; }
    }
}
