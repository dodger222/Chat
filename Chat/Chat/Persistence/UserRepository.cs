using Chat.Interfaces;
using Chat.Models;
using Chat.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ChatContext _db;

        public UserRepository(ChatContext db)
        {
            _db = db;
        }

        public List<User> GetUsers()
        {
            return _db.Users.ToList();
        }

        public string GetUserId(string userName)
        {
            return _db.Users.Where(u => u.UserName == userName).FirstOrDefault().Id;
        }

        public DateTime GetUserRegistrationDate(string userId)
        {
            return _db.Users.Where(u => u.Id == userId).FirstOrDefault().DateTimeRegistration;
        }
    }
}
