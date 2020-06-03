using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalMenu.Model
{
    public class AdditionalProduct
    {
        public int AdditionalId { get; set; }
        public Additional Additional { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
