using System.ComponentModel.DataAnnotations;

namespace ClinicalApp.Models
{
    public class Doctor
    {
          [Key]
        public int DoctorId { get; set; }
        
        [Required(ErrorMessage ="Doctor's Firts Name is required!")]
        [Display(Name ="Doctor's First Name")]
        public string DoctorFirstName { get; set; }
        [Required(ErrorMessage = "Doctor's Last Name is required!")]
        [Display(Name = "Doctor's Last Name")]
        public string DoctorLastName { get; set; }
        [Required(ErrorMessage = "Doctor's email is required!")]
        [Display(Name = "Doctor's Doctor's Email")]
        public string DoctorEmail { get; set; }
        [Required(ErrorMessage = "Doctor's Address is required!")]
        [Display(Name = "Doctor's Doctor's Address")]
        public string DoctorAddress { get; set; }
        [Required(ErrorMessage = "Doctor's Phone Number is required!")]
        [Display(Name = "Doctor's Doctor's Phone Number")]
        public string DoctorPhoneNumber { get; set; }
        [Required(ErrorMessage = "Doctor's Department is required!")]
        [Display(Name = "Doctor's Doctor's Department")]
        public string DoctorDepartmetment { get; set; }
        public string Image { get; set; }
    }
}