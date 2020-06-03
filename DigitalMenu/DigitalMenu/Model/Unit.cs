using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalMenu.Model
{
    public class Unit
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Product { get; set; } = new List<Product>();
    }
}
