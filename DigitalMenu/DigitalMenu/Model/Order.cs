using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalMenu.Model
{
    public class Order
    {
        public int? OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? TotalValue { get; set; }
        public int? OrderStatus { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public CashierOrder CashierOrder { get; set; }
        public int TableId { get; set; }
        public Table Table { get; set; }
    }
}
