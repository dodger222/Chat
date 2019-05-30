using Chat.Interfaces;
using Chat.Models;
using Chat.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ChatContext _db;

        public MessageRepository(ChatContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Message message)
        {
            await _db.Messages.AddAsync(message);
            _db.SaveChanges();
        }

        public IEnumerable<Message> GetMessages(DateTime userRegistrationDateTime)
        {
            return _db.Messages.Where(m => m.DateTimeOfSend.CompareTo(userRegistrationDateTime) > 0).Include(m => m.User).ToArray();
        }
    }
}
