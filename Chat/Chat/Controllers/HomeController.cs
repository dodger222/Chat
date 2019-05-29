using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Chat.Models;
using Microsoft.AspNetCore.SignalR;
using Chat.Hubs;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Chat.Controllers
{
    public class HomeController : Controller
    {
        ChatContext _db;
        private readonly UserManager<User> _userManager;

        public HomeController(ChatContext db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            string userId =  _userManager.GetUserId(User);

            if (userId != null)
            {
                DateTime userName = _db.Users.Where(u => u.Id == userId).FirstOrDefault().DateTimeRegistration;
                IEnumerable<Message> messages = _db.Messages.Where(m => m.DateTimeOfSend.CompareTo(userName) > 0).Include(m => m.User).ToArray();
                var model = messages;
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
    }
}
