using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalMenu.Model
{
    public class UserStatus
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
