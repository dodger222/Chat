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

namespace Chat.Controllers
{
    public class HomeController : Controller
    {
        ChatContext _db;

        public HomeController(ChatContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Message> messages = _db.Messages.Include(m => m.User).ToArray();
            var model = messages;
            return View(model);
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
