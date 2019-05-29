using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Models
{
    public class Message
    {
        public int ID { get; set; }

        public string UserId { get; set; }
        public string Text { get; set; }
        
        public User User { get; set; }
    }
}
