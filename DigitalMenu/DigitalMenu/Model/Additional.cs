using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DigitalMenu.Model
{
    public class Additional
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<AdditionalProduct> AdditionalProducts { get; set; }

        public Additional()
        {
            AdditionalProducts = new Collection<AdditionalProduct>();
        }
    }
}
