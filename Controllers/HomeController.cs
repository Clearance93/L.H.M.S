using Clinical_App.Models;
using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ClinicalApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository _user;

        public HomeController(ILogger<HomeController> logger,
            IUserRepository user)
        {
            _logger = logger;
            _user = user;
        }

        public IActionResult Index()
        {
            var userID = _user.GetUserId();
            var isLoggedIn = _user.IsAuthenticated();

            if(userID == null)
            {
                ViewData["notLoggedIn"] = "";
                
            }
            else
            {
                ViewData["loggedIn"] = "";
            }
            return View();
        }
        [Authorize(Roles ="Admin, Doctor")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SetTheme(string data)
        {
            CookieOptions cokkies = new CookieOptions();
            cokkies.Expires = DateTime.Now.AddDays(1); 
            Response.Cookies.Append("theme", data,cokkies);
            return Ok();
        }
    }
}