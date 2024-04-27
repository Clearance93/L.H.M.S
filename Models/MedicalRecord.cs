using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicalApp.Models
{
    public class MedicalRecord
    {
        [Key]
        public int MedicalId { get; set; }
        [ForeignKey("PatientId")]
        public int? PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        [Required, Display(Name ="Have you been diagnosied yet?")]
        public PresentDiagnisis PresentDiagnisis { get; set; }
        [Required, Display(Name = "Have you been diagnosied before?")]
        public PastDiagnosis PastDiagnosis { get; set; }
        [Required, Display(Name = "Do you have any medical care?")]
        public MedicalCare MedicalCare { get; set; }
        [Required, Display(Name = "Are you on a treatment?")]
        public Treatment Treatment { get; set; }
        [Required, Display(Name = "Do you have any allegies?")]
        public Allegies Allegies { get; set; }
    }

    public enum Allegies
    {
        Yes,
        No
    }

    public enum Treatment
    {
        Yes,
        No
    }

    public enum MedicalCare
    {
        Yes, No
    }

    public enum PastDiagnosis
    {
        Yes, No
    }   

    public enum PresentDiagnisis
    {
        Yes,
        No
    }
}
