//using ClinicalApp.Models;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;

//namespace ClinicalApp.Controllers
//{
//    public class ChatController : Controller
//    {
//        private readonly ILogger<ChatController> _logger;
//        private readonly UserManager<ApplicationUser> _userManager;


//        [BindProperty]
//        public List<SelectListItem> Users { get; set; }

//        [BindProperty]
//        public string MyUser { get; set; }  


//        public ChatController(UserManager<ApplicationUser> userManager, ILogger<ChatController> logger)
//        {
//            _userManager = userManager;
//            _logger = logger;
//        }

//        public IActionResult Index()
//        {
//            Users = _userManager.Users.ToList()
//                .Select(a => new SelectListItem {  Text = a.UserName, Value = a.UserName})
//                .OrderBy(s => s.Text).ToList();

//            MyUser = User.Identity.Name;

//            return View();
//        }

//    }
//}
