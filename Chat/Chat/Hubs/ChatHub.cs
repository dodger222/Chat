using Chat.Interfaces;
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
        private readonly IMessageRepository _messageRepository;
        private readonly IUserRepository _userRepository;

        public ChatHub(IMessageRepository messageRepository, IUserRepository userRepository)
            :base()
        {
            _messageRepository = messageRepository;
            _userRepository = userRepository;
        }

        public async Task Send(string message, string userName)
        {
            Message mes = new Message
            {
                Text = message,
                UserId = _userRepository.GetUserId(userName),
                DateTimeOfSend = DateTime.Now
            };

            if (mes != null && message.Length != 0)
            {
                await _messageRepository.AddAsync(mes);
                await Clients.All.SendAsync("Receive", message, userName);
            }
        }
    }
}
