using System.ComponentModel.DataAnnotations;

namespace ClinicalApp.Models
{
    public class Clearner
    {
        [Key]
        public int CleanerId { get; set; }
        [Required(ErrorMessage = "First Name is required"), Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required"), Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email Addressis required"), Display(Name = "Email Address"), EmailAddress]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Home Address is required"), Display(Name = "Home Address")]
        public string HomeAddress { get; set; }
        [Required(ErrorMessage = "Phone Number is required"), Display(Name = "Phone Number"), MaxLength(10)]
        public string Phonenumber { get; set; }
        [Required(ErrorMessage = "Your photo is required!")]
        public string Image { get; set; }
        [Required(ErrorMessage ="Your Agend Name/Company is needed"), Display(Name ="Agent Name/Company")]
        public string AgentName { get; set; }
        [Required(ErrorMessage ="Your Agend Manager is required!"), Display(Name ="Agent Manager")]
        public string Manager { get; set; }
        [Required(ErrorMessage ="Your Agent phone number is needed"), Display(Name ="Agent Contact Number"), MaxLength(10)]
        public string AgentPhoneNumber { get; set; }
        [Required(ErrorMessage ="Your Agent work Email Address is required!"), Display(Name ="Agent Work Email")]
        public string AgentWorkEmail { get; set; }
        [Required(ErrorMessage ="Agent Physical Address is required")]
        public string Address { get; set; }
    }
}
