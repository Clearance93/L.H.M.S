// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using ClinicalApp.Data;
using ClinicalApp.Interface;
using ClinicalApp.Models;
using ClinicalApp.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;

namespace ClinicalApp.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IWebHostEnvironment _environment;
        private readonly DatabaseContext _context;
        private readonly IDoctorRespository _doc;
        private readonly IPorterRepository _porter;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager,
            IWebHostEnvironment environment,
            DatabaseContext context,
            IDoctorRespository doc,
            IPorterRepository porter)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
            _environment = environment;
            _context = context;
            _doc = doc;
            _porter = porter;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            public string Id { get; set; }
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            public string Title { get; set; }
            [Required, Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required, Display(Name = "Last Name")]
            public string LastName { get; set; }
            public Position Position { get; set; }
            [Display(Name = "Select the department you belong to")]
            public Department Department { get; set; }
            [Required, Display(Name = "Contract type")]
            public ContractType ContractType { get; set; }
            [Required, Display(Name = "Date Stated")]
            public DateTime DateStarted { get; set; }
            [EmailAddress]
            [Compare("Username")]
            public string EmailAddress { get; set; }
            [Required, Display(Name = "Street Name")]
            public string StreetName { get; set; }
            public string Surbub { get; set; }
            [Required, Display(Name = "City/Town")]
            public string City_Town { get; set; }
            [Required, Display(Name = "Zip Code")]
            public string ZipCode { get; set; }
            public string Country { get; set; }
            public string Code { get; set; }
            [Required, Display(Name = "Phone Number")]
            //[MaxLength(9)]
            public string PhoneNumber { get; set; }
            [Required]
            public string Image { get; set; }
        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            string webRootPath = _environment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            string fileName = Guid.NewGuid().ToString();
            var upload = Path.Combine(webRootPath, @"Images\Registration");
            var extention = Path.GetExtension(files[0].FileName);

            using (var fileStream = new FileStream(Path.Combine(upload, fileName + extention), FileMode.Create))
            {
                files[0].CopyTo(fileStream);
            }

            Input.Image = @"\Images\Registration\" + fileName + extention;


            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
           
                var user = CreateUser();

                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                user.FirstName = Input.FirstName;
                user.LastName = Input.LastName;
                user.PhoneNumber = Input.PhoneNumber;
                user.Email = Input.Email;
                user.DateStarted = Input.DateStarted;
                user.Surbub = Input.Surbub;
                user.City_Town = Input.City_Town;
                user.Country = Input.Country;
                user.Department = Input.Department;
                user.Position = Input.Position;
                user.StreetName = Input.StreetName;
                user.ZipCode = Input.ZipCode;
                user.Title = Input.Title;
                user.Image = Input.Image;


            //var porter = new Porter();
            //if(Input.Position == Position.Porters)
            //{
            //    _porter.Create(porter);
            //}


            var result = await _userManager.CreateAsync(user, Input.Password);

                if(!await _roleManager.RoleExistsAsync(Workers.AdminRole))
            {
                await _roleManager.CreateAsync(new IdentityRole(Workers.AdminRole));
                await _roleManager.CreateAsync(new IdentityRole(Workers.ManagerRole));
                await _roleManager.CreateAsync(new IdentityRole(Workers.DoctorRole));
                await _roleManager.CreateAsync(new IdentityRole(Workers.ITRole));   
                await _roleManager.CreateAsync(new IdentityRole(Workers.ParamedicRole));    
                await _roleManager.CreateAsync(new IdentityRole(Workers.CleanerRole));
                await _roleManager.CreateAsync(new IdentityRole(Workers.FinanceRole));
                await _roleManager.CreateAsync(new IdentityRole(Workers.HRRole));
                await _roleManager.CreateAsync(new IdentityRole(Workers.NurseRole));
                await _roleManager.CreateAsync(new IdentityRole(Workers.PorterRole));
            }

                if (result.Succeeded)
                {
                string role = Request.Form["rdUserRole"].ToString();
                if(role == Workers.HRRole)
                {
                    await _userManager.AddToRoleAsync(user, Workers.HRRole);
                }
                else if(role == Workers.NurseRole)
                {
                    await _userManager.AddToRoleAsync(user, Workers.NurseRole);
                }
                else if(role == Workers.DoctorRole)
                {
                    await _userManager.AddToRoleAsync(user, Workers.DoctorRole);
                }
                else if(role == Workers.AdminRole)
                {
                    await _userManager.AddToRoleAsync(user, Workers.AdminRole);
                }
                else if(role == Workers.FinanceRole)
                {
                    await _userManager.AddToRoleAsync(user, Workers.FinanceRole);
                }
                else if(role == Workers.PorterRole)
                {
                    await _userManager.AddToRoleAsync(user, Workers.PorterRole);
                }
                else if(role == Workers.ITRole)
                {
                    await _userManager.AddToRoleAsync(user, Workers.ITRole);
                }
                else if(role == Workers.ManagerRole)
                {
                    await _userManager.AddToRoleAsync(user, Workers.ManagerRole);
                }
                else if(role == Workers.ParamedicRole)
                {
                    await _userManager.AddToRoleAsync(user, Workers.ParamedicRole);
                }
                else
                {
                    await _userManager.AddToRoleAsync(user, Workers.CleanerRole);
                }

                

                _logger.LogInformation("User created a new account with password.");

                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"<h3>Welcome {user.FirstName} {user.LastName}</h3> to L.H.M.S<br />Please confirm your L.H.M.S account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl); 
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
           

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }
    }
}
