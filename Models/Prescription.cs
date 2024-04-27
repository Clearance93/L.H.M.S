using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicalApp.Models
{
    public class Prescription
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [ForeignKey("DoctorId")]
        public int? DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        [Required]
        [MaxLength(100)]
        public string PatientName { get; set; }

        [Required(ErrorMessage ="Amount is Required")]
        
        public decimal Amount { get; set; }

        [Required]
        public int Frequency { get; set; }


        //public ICollection<Doctor> Doctors { get; set; }
    }
}