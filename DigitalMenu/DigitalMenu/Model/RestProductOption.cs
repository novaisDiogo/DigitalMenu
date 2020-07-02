using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalMenu.Model
{
    public class RestProductOption
    {
        public string Description { get; set; }
        public double Value { get; set; }
        public List<OptionsProduct> S { get; set; }
    }
}
