using Chat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Interfaces
{
    public interface IMessageRepository
    {
        Task AddAsync(Message message);
        IEnumerable<Message> GetMessages(DateTime userRegistrationDateTime);
    }
}
