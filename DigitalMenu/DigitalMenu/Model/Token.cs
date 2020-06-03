using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalMenu.Model
{
    [Table("Token")]
    public class Token
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Secret { get; set; }
    }
}
