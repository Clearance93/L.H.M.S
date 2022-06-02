using System.ComponentModel.DataAnnotations;

namespace ClinicalApp.Models
{
    public class IT
    {
        [Key]
        public int ITId { get; set; }
        [Required(ErrorMessage = "First Name is required"), Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required"), Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email Addressis required"), Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Home Address is required"), Display(Name = "Home Address")]
        public string HomeAddress { get; set; }
        [Required(ErrorMessage = "Phone Number is required"), Display(Name = "Phone Number"), MaxLength(10)]
        public string Phonenumber { get; set; }
        [Required(ErrorMessage = "Your photo is required!")]
        public string Image { get; set; }
    }
}
