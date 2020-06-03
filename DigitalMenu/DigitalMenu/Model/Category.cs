using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DigitalMenu.Model
{
    public class Category
    {
        public int? Id { get; set; }
        public string Description { get; set; }
        public List<CategoryProduct> CategoryProducts { get; set; }
        public Category()
        {
            CategoryProducts = new List<CategoryProduct>();
        }
    }
}
