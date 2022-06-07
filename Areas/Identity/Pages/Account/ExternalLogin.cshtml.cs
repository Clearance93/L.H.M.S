// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using ClinicalApp.Models;
using ClinicalApp.Utility;

namespace ClinicalApp.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ExternalLoginModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        private readonly IEmailSender _emailSender;
        private readonly ILogger<ExternalLoginModel> _logger;
        private readonly IWebHostEnvironment _environment;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ExternalLoginModel(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            ILogger<ExternalLoginModel> logger,
            IEmailSender emailSender, 
            IWebHostEnvironment environment,
            RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _logger = logger;
            _emailSender = emailSender;
            _environment = environment;

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
        public string ProviderDisplayName { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string ErrorMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [EmailAddress]
            public string Email { get; set; }
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
            [MaxLength(9)]
            public string PhoneNumber { get; set; }
            [Required]
            public string Image { get; set; }
        }
        
        public IActionResult OnGet() => RedirectToPage("./Login");

        public IActionResult OnPost(string provider, string returnUrl = null)
        {
            // Request a redirect to the external login provider.
            var redirectUrl = Url.Page("./ExternalLogin", pageHandler: "Callback", values: new { returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }

        public async Task<IActionResult> OnGetCallbackAsync(string? returnUrl = null, string remoteError = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (remoteError != null)
            {
                ErrorMessage = $"Error from external provider: {remoteError}";
                return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
            }
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ErrorMessage = "Error loading external login information.";
                return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
            }

            // Sign in the user with this external login provider if the user already has a login.
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if (result.Succeeded)
            {
                _logger.LogInformation("{Name} logged in with {LoginProvider} provider.", info.Principal.Identity.Name, info.LoginProvider);
                return LocalRedirect(returnUrl);
            }
            if (result.IsLockedOut)
            {
                return RedirectToPage("./Lockout");
            }
            else
            {
                // If the user does not have an account, then ask the user to create an account.
                ReturnUrl = returnUrl;
                ProviderDisplayName = info.ProviderDisplayName;
                if (info.Principal.HasClaim(c => c.Type == ClaimTypes.Email))
                {
                    Input = new InputModel
                    {
                        Email = info.Principal.FindFirstValue(ClaimTypes.Email),
                        FirstName = info.Principal.FindFirstValue(ClaimTypes.Name).Split(' ')[0],
                        LastName = info.Principal.FindFirstValue(ClaimTypes.Name).Split(' ')[1],
                    };
                }
                return Page();
            }
        }

        public async Task<IActionResult> OnPostConfirmationAsync(string? returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            // Get the information about the user from the external login provider
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ErrorMessage = "Error loading external login information during confirmation.";
                return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
            }

            if (ModelState.IsValid)
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

                var user = CreateUser();

                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
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

                if (!await _roleManager.RoleExistsAsync(Workers.AdminRole))
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

                    var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {

                    string role = Request.Form["rdUserRole"].ToString();
                    if (role == Workers.HRRole)
                    {
                        await _userManager.AddToRoleAsync(user, Workers.HRRole);
                    }
                    else if (role == Workers.NurseRole)
                    {
                        await _userManager.AddToRoleAsync(user, Workers.NurseRole);
                    }
                    else if (role == Workers.DoctorRole)
                    {
                        await _userManager.AddToRoleAsync(user, Workers.DoctorRole);
                    }
                    else if (role == Workers.AdminRole)
                    {
                        await _userManager.AddToRoleAsync(user, Workers.AdminRole);
                    }
                    else if (role == Workers.FinanceRole)
                    {
                        await _userManager.AddToRoleAsync(user, Workers.FinanceRole);
                    }
                    else if (role == Workers.PorterRole)
                    {
                        await _userManager.AddToRoleAsync(user, Workers.PorterRole);
                    }
                    else if (role == Workers.ITRole)
                    {
                        await _userManager.AddToRoleAsync(user, Workers.ITRole);
                    }
                    else if (role == Workers.ManagerRole)
                    {
                        await _userManager.AddToRoleAsync(user, Workers.ManagerRole);
                    }
                    else if (role == Workers.ParamedicRole)
                    {
                        await _userManager.AddToRoleAsync(user, Workers.ParamedicRole);
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, Workers.CleanerRole);
                    }


                    result = await _userManager.AddLoginAsync(user, info);
                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User created an account using {Name} provider.", info.LoginProvider);

                        var userId = await _userManager.GetUserIdAsync(user);
                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                        var callbackUrl = Url.Page(
                            "/Account/ConfirmEmail",
                            pageHandler: null,
                            values: new { area = "Identity", userId = userId, code = code },
                            protocol: Request.Scheme);

                        await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                            $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                        // If account confirmation is required, we need to show the link if we don't have a real email sender
                        if (_userManager.Options.SignIn.RequireConfirmedAccount)
                        {
                            return RedirectToPage("./RegisterConfirmation", new { Email = Input.Email });
                        }

                        await _signInManager.SignInAsync(user, isPersistent: false, info.LoginProvider);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            ProviderDisplayName = info.ProviderDisplayName;
            ReturnUrl = returnUrl;
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
                    $"override the external login page in /Areas/Identity/Pages/Account/ExternalLogin.cshtml");
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
