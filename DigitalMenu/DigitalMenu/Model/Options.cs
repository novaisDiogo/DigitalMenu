using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalMenu.Model
{
    public class Options
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public ICollection<OptionsProduct> OptionsProducts { get; set; }
    }
}
