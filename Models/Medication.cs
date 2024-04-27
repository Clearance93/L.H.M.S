using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicalApp.Models
{
    public class Medications
    {
        [Key]
        public int MedicationId { get; set; }
        [ForeignKey("PatientId")]
        public int? PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        public string MedicationName { get; set; }
        public string TypeOfMedication { get; set; }
        public string Symptoms { get; set; }
        public string MedicationFor { get; set; }
        public DateTime StartTime { get; set; }
        public string DurationOfMedication { get; set; }
    }
}
