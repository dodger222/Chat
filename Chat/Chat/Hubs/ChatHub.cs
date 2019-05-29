using Chat.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        ChatContext _db;

        public ChatHub(ChatContext db)
            :base()
        {
            _db = db;
        }

        public async Task Send(string message, string userName)
        {
            Message mes = new Message
            {
                Text = message,
                UserId = _db.Users.Where(u => u.UserName == userName).FirstOrDefault().Id,
                DateTimeOfSend = DateTime.Now
            };

            if (mes != null && message.Length != 0)
            {
                await _db.Messages.AddAsync(mes);
                _db.SaveChanges();
                await Clients.All.SendAsync("Receive", message, userName);
            }
        }
    }
}
