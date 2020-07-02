using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalMenu.Model
{
    public class CategoryProduct
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
