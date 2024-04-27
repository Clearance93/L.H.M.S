using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicalApp.Models
{
    public class MedicationOrderDetails
    {
        [Key]
        public int MedsOrderId { get; set; }
        [ForeignKey("MedsId")]
        public int MedsId { get; set; }
        public virtual PickUpMedication PickUpMedication { get; set; }
        public int Count { get; set; } 
        public double Price { get; set; }
        public string Prescriptions { get; set; }
        [Required, Display(Name ="Patient Full Names")]
        public string PatientFullNames { get; set; }
    }
}
