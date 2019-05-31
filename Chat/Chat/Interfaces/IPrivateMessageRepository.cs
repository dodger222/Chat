using Chat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Interfaces
{
    public interface IPrivateMessageRepository
    {
        List<PrivateMessage> GetPrivateMessages(string FromUserId, string ToUserId);
    }
}
