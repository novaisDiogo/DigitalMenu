using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalMenu.Model
{
    public class RestOrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public double Value { get; set; }
        public int Quantity { get; set; }
        public int OptionsId { get; set; }
        public int AdditionalId { get; set; }
        public string Product { get; set; }
        public string Options { get; set; }
        public string Additional { get; set; }
    }
}
