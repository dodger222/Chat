﻿using Chat.Interfaces;
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
        private readonly IUnitOfWork _unitOfWork;

        public ChatHub(IUnitOfWork unitOfWork)
            :base()
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Send(string message, string userName)
        {
            Message mes = new Message
            {
                Text = message,
                UserId = _unitOfWork.UserRepository.GetUserId(userName),
                DateTimeOfSend = DateTime.Now
            };

            if (mes != null && message.Length != 0)
            {
                await _unitOfWork.MessageRepository.AddAsync(mes);
                await Clients.All.SendAsync("Receive", message, userName);
            }
        }

        public async Task SendPrivateMessage(string toUserId, string message)
        {
            string fromUserName = Context.User.Identity.Name;

            string fromUserId = _unitOfWork.UserRepository.GetUserId(fromUserName);

            PrivateMessage mes = new PrivateMessage
            {
                FromUserId = fromUserId,
                FromUserName = fromUserName,
                ToUserId = toUserId,
                Text = message,
                DateTimeOfSend = DateTime.Now
            };

            await _unitOfWork.PrivateMessageRepository.AddAsync(mes);

            await Clients.Users(Context.UserIdentifier, toUserId).SendAsync("ReceivePrivateMessage", message, fromUserName);
        }
    }
}
