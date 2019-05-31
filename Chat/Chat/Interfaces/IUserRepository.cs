using Chat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        string GetUserId(string userName);
        DateTime GetUserRegistrationDate(string userId);
    }
}
