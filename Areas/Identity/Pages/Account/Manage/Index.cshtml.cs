// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System.ComponentModel.DataAnnotations;
using ClinicalApp.Data;
using ClinicalApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClinicalApp.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public IndexModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

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
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
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
            public string Image { get; set; }

        }
       
        private async Task LoadAsync(IdentityUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            //var firstName = user.FirstName;
            //var lastName = user.LastName;
            //var title = user.Title;
            //var position = user.Position;
            //var department = user.Department;
            //var contractType = user.ContractType;
            //var streetName = user.StreetName;
            //var surbub = user.Surbub;
            //var city_Town = user.City_Town;
            //var zipCode = user.ZipCode;
            //var country = user.Country;
            //var image = user.Image;


            Username = userName;


            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                //FirstName = firstName,
                //LastName = lastName,
                //Title = title,
                //Position = position,
                //Department = department,
                //ContractType = contractType,
                //StreetName = streetName,
                //Country = country,
                //Image = image,
                //Surbub = surbub,
                //City_Town = city_Town,
                //ZipCode = zipCode
            };

        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            //if (!ModelState.IsValid)
            //{
            //    await LoadAsync(user);
            //    return Page();
            //}

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            var firstName = Input.FirstName;
            var lastName = Input.LastName;
            var title = Input.Title;
            var position = Input.Position;
            var department = Input.Department;
            var contractType = Input.ContractType;
            var streetName = Input.StreetName;
            var surbub = Input.Surbub;
            var cityTown = Input.City_Town;
            var zipCode = Input.ZipCode;
            var country = Input.Country;
            var image = Input.Image;

            if(Input.FirstName != firstName || Input.LastName != lastName || Input.Title != title || Input.Position != position || Input.Department != department || Input.ContractType != contractType || Input.StreetName != streetName || Input.Surbub != surbub || Input.City_Town != cityTown || Input.ZipCode != zipCode || Input.Country != country || Input.Image != image)
            {
                //user.FirstName = Input.FirstName;
                //user.LastName = Input.LastName;
                //user.Title = Input.Title;
                //user.Position = Input.Position; 
                //user.Department = Input.Department;
                //user.ContractType = Input.ContractType;
                //user.StreetName = Input.StreetName;
                //user.Surbub = Input.Surbub;
                //user.City_Town = Input.City_Town;
                //user.ZipCode = Input.ZipCode;
                //user.Country = Input.Country;   
                //user.Image = Input.Image;
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
