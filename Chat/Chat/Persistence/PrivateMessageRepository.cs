using Chat.Interfaces;
using Chat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Persistence
{
    public class PrivateMessageRepository : IPrivateMessageRepository
    {
        private readonly ChatContext _db;

        public PrivateMessageRepository(ChatContext db)
        {
            _db = db;
        }

        public List<PrivateMessage> GetPrivateMessages(string fromUserId, string toUserId)
        {
            return _db.PrivateMessages.Where(m => m.FromUserId == fromUserId && m.ToUserId == toUserId).ToList();
        }
        public async Task AddAsync(PrivateMessage mes)
        {
            await _db.PrivateMessages.AddAsync(mes);
            _db.SaveChanges();
        }
    }
}
