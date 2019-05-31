using Chat.Interfaces;
using Chat.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ChatContext db;
        private UserRepository userRepository;
        private MessageRepository messageRepository;
        private PrivateMessageRepository privateMessageRepository;

        public UnitOfWork(ChatContext context)
        {
            db = context;
        }

        public IUserRepository UserRepository => userRepository ?? new UserRepository(db);
        public IMessageRepository MessageRepository => messageRepository ?? new MessageRepository(db);
        public IPrivateMessageRepository PrivateMessageRepository => privateMessageRepository ?? new PrivateMessageRepository(db);
    }
}
