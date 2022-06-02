using System.ComponentModel.DataAnnotations;

namespace ClinicalApp.Dto
{
    public class DoctorCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string DoctorFirstName { get; set; }
        [Required]
        public string DoctorLastName { get; set; }
        [Required]
        [EmailAddress]
        public string DoctorEmail { get; set; }
        [Required]
        public string DoctorAddress { get; set; }
        [Required]
        [Phone]
        public int DoctorPhoneNumber { get; set; }
        [Required]
        public string DoctorDepartmanent { get; set; }
    }
}