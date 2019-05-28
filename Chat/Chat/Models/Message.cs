﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Models
{
    public class Message
    {
        public int ID { get; set; }
        public int UserID { get; set; }

        public User User { get; set; }
    }
}
