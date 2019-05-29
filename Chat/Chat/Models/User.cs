using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Models
{
    public class User : IdentityUser
    {
        public string Nickname { get; set; }
        public DateTime DateTimeRegistration { get; set; }

        public ICollection<Message> Messages { get; set; }
    }
}
