using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalMenu.Model
{
    public class RestProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public List<CategoryProduct> S { get; set; }
    }
}
