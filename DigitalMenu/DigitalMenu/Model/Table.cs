using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalMenu.Model
{
    public class Table
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
