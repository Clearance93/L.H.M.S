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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
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
       
        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var firstName = user.FirstName;
            var lastName = user.LastName;
            var title = user.Title;
            var position = user.Position;
            var department = user.Department;
            var contractType = user.ContractType;
            var streetName = user.StreetName;
            var surbub = user.Surbub;
            var city_Town = user.City_Town;
            var zipCode = user.ZipCode;
            var country = user.Country;
            var image = user.Image;


            Username = userName;


            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                FirstName = firstName,
                LastName = lastName,
                Title = title,
                Position = position,
                Department = department,
                ContractType = contractType,
                StreetName = streetName,
                Country = country,
                Image = image,
                Surbub = surbub,
                City_Town = city_Town,
                ZipCode = zipCode
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
               // await LoadAsync(user);
               // return Page();
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

            if(Input.FirstName == firstName || Input.LastName == lastName || Input.Title == title || Input.StreetName == streetName || Input.Surbub == surbub || Input.City_Town == cityTown || Input.ZipCode == zipCode || Input.Country == country)
            {
                user.FirstName = Input.FirstName;
                user.LastName = Input.LastName; 
                user.Title = Input.Title;   
                user.StreetName = Input.StreetName; 
                user.Surbub = Input.Surbub; 
                user.City_Town = Input.City_Town;
                user.ZipCode = Input.ZipCode;
                user.Country = Input.Country;
                await _userManager.UpdateAsync(user);
            }

            if(Input.Position == Position.Doctor || Input.Position == Position.Porters || Input.Position == Position.Nurse || Input.Position == Position.Manager || Input.Position == Position.Finance || Input.Position == Position.Admin || Input.Position == Position.Cleaner || Input.Position == Position.HR || Input.Position == Position.IT || Input.Position == Position.Paramedics)
            {
                user.Position = Position.Doctor;
                user.Position = Position.Porters;
                user.Position = Position.Nurse;
                user.Position = Position.Manager;
                user.Position = Position.Finance;   
                user.Position = Position.Admin;
                user.Position = Position.Cleaner;
                user.Position = Position.HR;
                user.Position = Position.IT;
                user.Position = Position.Paramedics;
                await _userManager.UpdateAsync(user);   
            }

            if(Input.Department == Department.IT || Input.Department == Department.Porter || Input.Department == Department.Management || Input.Department == Department.Theater || Input.Department == Department.Cleaner || Input.Department == Department.Admin || Input.Department == Department.Clinical || Input.Department == Department.Finanace || Input.Department == Department.HR || Input.Department == Department.Technical || Input.Department == Department.Paramedical || Input.Department == Department.OPD || Input.Department == Department.Medical || Input.Department == Department.Nursing || Input.Department == Department.Patholodgy || Input.Department == Department.Rehabilitation || Input.Department == Department.Physical || Input.Department == Department.Technical || Input.Department == Department.Radiology)
            {
                user.Department = Department.IT;    
                user.Department = Department.Porter;    
                user.Department = Department.Management;
                user.Department = Department.Theater;
                user.Department = Department.Cleaner;
                user.Department = Department.Admin;
                user.Department = Department.Clinical;
                user.Department = Department.Finanace;
                user.Department = Department.HR;
                user.Department = Department.Technical; 
                user.Department = Department.Paramedical;
                user.Department = Department.OPD;
                user.Department = Department.Medical;
                user.Department = Department.Nursing;   
                user.Department = Department.Patholodgy;    
                user.Department = Department.Rehabilitation;
                user.Department = Department.Physical;
                user.Department = Department.Technical;
                user.Department = Department.Radiology;
                await _userManager.UpdateAsync(user);
            }

            if (Request.Form.Files.Count > 0)
            {
                IFormFile file = Request.Form.Files.FirstOrDefault();
                using (var dataStream = new MemoryStream())
                {
                    await file.CopyToAsync(dataStream);
                    user.Image = dataStream.ToString();
                }
                await _userManager.UpdateAsync(user);
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
         }
    }
}
