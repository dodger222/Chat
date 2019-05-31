using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Chat.Models;
using Microsoft.AspNetCore.Identity;
using Chat.Interfaces;

namespace Chat.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(UserManager<User> userManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            string userId =  _userManager.GetUserId(User);

            if (userId != null)
            {
                // get list of users

                IEnumerable<User> users = _unitOfWork.UserRepository.GetUsers();
                users = users.Where(u => u.UserName != User.Identity.Name);
                var model = users;
                return View(model);
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        public IActionResult GetMessages(string toUserId)
        {
            List<PrivateMessage> privateMessages = new List<PrivateMessage>();
            List<PrivateMessage> privateMessagesTwo = new List<PrivateMessage>();

            if (toUserId != null)
            {
                string fromUserId = _unitOfWork.UserRepository.GetUserId(User.Identity.Name);

                // get messages from both users
                privateMessages = _unitOfWork.PrivateMessageRepository.GetPrivateMessages(fromUserId, toUserId);
                privateMessagesTwo = _unitOfWork.PrivateMessageRepository.GetPrivateMessages(toUserId, fromUserId);

                // merge messages into one list
                privateMessages.AddRange(privateMessagesTwo);

                //sort by DateTime of send
                privateMessages = privateMessages.OrderBy(m => m.DateTimeOfSend).ToList();
            }

            return PartialView(privateMessages);
        }
    }
}
