using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicalApp.Models
{
    public class PickUpMedication
    {
        [Key]
        public int MedsId { get; set; }
        [ForeignKey("PatientId")]
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        [Display(Name ="Mediction number")]
        public string MedicationOder { get; set; }
        [Display(Name ="Medication Sub Total")]
        public double MedicationSubtotal { get; set; }
        [Required, Display(Name ="Pick up date")]
        public DateTime PickupDate { get; set; }
        [Display(Name ="Medication Status")]
        public string MediationStatus { get; set; }
        public string? Comments { get; set; } 
        public double Payment { get; set; }
        [Required, Display(Name ="Patient Full Names")]
        public string PatientFullName { get; set; }
        [Required, Display(Name ="Collecter full names")]
        public string CoolectorFullNames { get; set; }
        [Display(Name ="Phone Numbers")]
        public string PlhoneNumbers { get; set; }
    }
}
