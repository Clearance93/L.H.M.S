using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ClinicalApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        [Required, Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required, Display(Name ="Last Name")]
        public string LastName { get; set; }
        public Position Position { get; set; }
        [Display(Name ="Select the department you belong to")]
        public Department Department { get; set; }
        [Required, Display(Name ="Contract type")]
        public ContractType ContractType { get; set; }
        [Required, Display(Name ="Date Stated")]
        public DateTime DateStarted { get; set; }
        [EmailAddress]
        [Compare("Username")]
        //public string EmailAddress { get; set; }
        [Required, Display(Name ="Street Name")]
        public string StreetName { get; set; }
        public string Surbub { get; set; }
        [Required, Display(Name ="City/Town")]
        public string City_Town { get; set; }
        [Required, Display(Name ="Zip Code")]
        public string ZipCode { get; set; }
        public string Country { get; set; }
        [Required]
        public string Image { get; set; }
    }

    public enum Department
    {
        OPD,
        Medical,
        Nursing,
        Paramedical,
        Porter,
        Patholodgy,
        Physical,
        Rehabilitation,
        Theater,
        Phamacy,
        Radiology,
        Technical,
        Management,
        IT,
        HR,
        Finanace,
        Clinical,
        Admin,
        Cleaner
    }

    public enum Position
    {
        Doctor,
        Nurse,
        HR,
        Paramedics,
        Cleaner,
        Finance,
        Porters,
        IT,
        Manager,
        Admin
    }

    public enum ContractType
    {
        Intern,
        Temp_Contract,
        Parmenent
    }
}
