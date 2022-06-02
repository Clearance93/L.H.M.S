using Clinical_App.Models;
using ClinicalApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ClinicalApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(ApplicationUser user)
        {
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