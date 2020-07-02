using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalMenu.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string PassHash { get; set; }
        public byte ResetPass { get; set; }
        public int UserStatusId { get; set; }
        public UserStatus UserStatus { get; set; }
    }
}
