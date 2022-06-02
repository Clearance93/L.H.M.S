using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicalApp.Models
{
    public class TreatmentHistory
    {
        [Key]
        public int TreatMentHistoryId { get; set; }
        [ForeignKey("PatientId")]
        public int? PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        [Display(Name ="Chief of Complains"), Required]
        public string ChiefComplains { get; set; }
        [Display(Name = "History of illness"), Required]
        public string HistoryOfIllenes { get; set; }
        [Display(Name = "Vital signs"), Required]
        public string VitalSigns { get; set; }
        [Display(Name = "Physical Examination"), Required]
        public string PhysicalExamination { get; set; }
        [Display(Name = "Surgeical History"), Required]
        public string SurgicalHistory { get; set; }
        [Display(Name = "Obstretric History"), Required]
        public string ObstetricHistory { get; set; }
        [Display(Name = "Medical Allegies"), Required]
        public string MedicalAllegies { get; set; }
        [Display(Name = "Family History"), Required]
        public string FamilyHistory { get; set; }
        [Display(Name = "Immunization History"), Required]
        public string ImmunizationHistory { get; set; }
        [Display(Name = "Development History"), Required]
        public string DevelopmentHistory { get; set; }
    }


}
