using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalMenu.Model
{
    public class CashierOrder
    {
        public int Id { get; set; }
        public int CashierId { get; set; }
        public Cashier Cashier { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
