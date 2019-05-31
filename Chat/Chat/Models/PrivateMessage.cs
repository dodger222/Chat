using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Models
{
    public class PrivateMessage
    {
        public int ID { get; set; }

        public string FromUserId { get; set; }
        public string FromUserName { get; set; }
        public string ToUserId { get; set; }
        public string Text { get; set; }
        public DateTime DateTimeOfSend { get; set; }

        public User FromUser { get; set; }
        public User ToUser { get; set; }
    }
}
