using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalMenu.Model
{
    public class ProdutoImagem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Value { get; set; }
        public bool Status { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
    }
}
