using ClinicalApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClinicalApp.Areas.Identity.Pages.Account
{
    public class ChatModel : PageModel
    {
        private readonly ILogger<ChatModel> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

    [BindProperty]
        public List<SelectListItem> Users { get; set; }

    [BindProperty]
        public string MyUser { get; set; }
        public ChatModel(ILogger<ChatModel> logger, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

    public void OnGet()
        {
            //get all the users from the database
            Users = _userManager.Users.ToList()
                .Select(a => new SelectListItem { Text = a.UserName, Value = a.UserName })
                .OrderBy(s => s.Text).ToList();

        //get logged in user name
        MyUser = User.Identity.Name;

    }
    }
}

