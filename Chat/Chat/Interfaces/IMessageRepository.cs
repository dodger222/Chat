using Chat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Interfaces
{
    public interface IMessageRepository
    {
        void Add(Message message);
        IEnumerable<Message> GetMessages();
    }
}
