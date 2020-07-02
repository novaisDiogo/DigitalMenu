using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalMenu.Model
{
    [Table("Vagas")]
    public class Tables
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
