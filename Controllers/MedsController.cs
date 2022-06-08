using Microsoft.AspNetCore.Mvc;

namespace ClinicalApp.Controllers
{
    public class MedsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
