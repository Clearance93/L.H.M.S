using Microsoft.AspNetCore.Mvc;

namespace ClinicalApp.Controllers
{
    public class MedsCollectionDetailsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
