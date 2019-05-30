using Chat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Interfaces
{
    public interface IUserRepository
    {
        string GetUserId(string userName);
        DateTime GetUserRegistrationDate(string UserId);
    }
}
