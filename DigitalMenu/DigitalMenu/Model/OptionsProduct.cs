using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalMenu.Model
{
    public class OptionsProduct
    {
        public int OptionsId { get; set; }
        public Options Options { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
