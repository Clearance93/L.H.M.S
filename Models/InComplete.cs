using System.ComponentModel.DataAnnotations;

namespace ClinicalApp.Models
{
    public class InComplete
    {
        public int Id { get; set; }
        public string PatientFirstName { get; set; }
        [Required(ErrorMessage = "Patient Lats name is required"), Display(Name = "Patient Last Name")]
        public string PatientLastName { get; set; }
        [Required, Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Required, Display(Name = "Birth ID")]
        public string? BirthId { get; set; }
        [Required(ErrorMessage = "Patient contact number is required"), Display(Name = "Patient Contact Number")]
        public string ContactNumber { get; set; }
        [Required(ErrorMessage = "Email address is required"), Display(Name = "Emaill address")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Home address is required"), Display(Name = "Home address")]
        public string HomeAddress { get; set; }
        [Display(Name = "Admit Status eg Admitted/Discharged")]
        public string AdmitStatus { get; set; }
        [Display(Name = "Passport Number")]
        public string PassportNumber { get; set; }
        [Display(Name = "Country of birth")]
        public string Country { get; set; }
        [Display(Name = "Reason for visittation in South Africa")]
        public string ReasonForVisitation { get; set; }
        [Display(Name = "Duration of visitiation in South Africa")]
        public string DurationOfVisitation { get; set; }
        [Display(Name = "Ward Name")]
        public string Ward_Name { get; set; }
        [Display(Name = "Date of admition")]
        public string DateOfAdmition { get; set; }
        [Display(Name = "Date of discharge")]
        public string DateOfDischarge { get; set; }
        [Required, Display(Name = "Benefit and risk of treatment")]
        public string BenefitOfTreatment { get; set; }
        [Required, Display(Name = "Risk Of Treatment if not taken")]
        public string RiskOfTreatment { get; set; }
        [Required, Display(Name = "Start time of treatment")]
        public DateTime StartOfTreatment { get; set; }
        [Required, Display(Name = "End of Treatment")]
        public DateTime EndOfTreatment { get; set; }
        [Display(Name = "Treatment statsu eg: Completed, Incoplete or on medication")]
        public string TreeatmentStatus { get; set; }
        [Required(ErrorMessage = "Patient status is required"), Display(Name = "Patient status")]
        public PatientStatus PatientStatus { get; set; }
        [Required]
        public Infection Infection { get; set; }
        [Required]
        public Illness Illness { get; set; }
        [Required, Display(Name = "Are there recovery chances?")]
        public string RecoveryChances { get; set; }
        [Required, Display(Name = "Does a patient require treatment?")]
        public string RecommendedTreatment { get; set; }
        [Required, Display(Name = "Can a patient survive if treatment is taken?")]
        public SuucessOfRecoveryIftreatmentTaken SuucessOfRecoveryIftreatmentTaken { get; set; }
    }
}
