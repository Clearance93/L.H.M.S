using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ClinicalApp.Models
{
    public class Chronic_Desease
    {
        [Key]
        public int DiseaseId { get; set; }
        [Required, Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required, Display(Name ="Last Name")]
        public string LastName { get; set; }
        [Required, Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }
        [Required, Display(Name ="Id Number")]
        public string Id_Number { get; set; }
        [Required, Display(Name = "SA Id or Passport")]
        public string SAIdorPassport { get; set; }
        [Display(Name ="Passport number")]
        [DefaultValue("xxxxx1213456789")]
        public string? PassportNumber { get; set; }
        [Display(Name = "County of birth")]
        [DefaultValue("South African citizen")]
        public string? CountryOfBirth { get; set; }
        [Required, Display(Name ="Home Address")]
        public string HomeAddress { get; set; }
        [Required, Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }
        [Required, Display(Name = "Email Address")]
        [DefaultValue("No Email")]
        public string EmailAddress { get; set; }
        [Required, Display(Name = "Ward Name")]
        public string WardName { get; set; }
        [Required, Display(Name = "Chronic")]
        public string Chronic { get; set; }
        [Required, Display(Name = "Duration of medication")]
        public string DurationOfMedicatiomn { get; set; }
        [Required, Display(Name = "Date Admitted")]
        public DateTime DateAdmitted { get; set; }
    }
}
