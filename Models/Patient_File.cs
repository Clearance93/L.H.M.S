using System.ComponentModel.DataAnnotations;

namespace ClinicalApp.Models
{
    public class Patient_File 
    {
        [Key]
        public int PatientId { get; set; }
        [Required(ErrorMessage = "Patient First Name is required"), Display(Name = "Patient Name")]
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
        [Required]
        public int Age { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]
        public string Ethnicity { get; set; }
        [Display(Name = "Passport Number")]
        public string? PassportNumber { get; set; }
        [Display(Name = "Country of birth")]
        public string Country { get; set; }
        [Display(Name = "Reason for visittation in South Africa")]
        public string? ReasonForVisitation { get; set; }
        [Display(Name = "Duration of visitiation in South Africa")]
        public string? DurationOfVisitation { get; set; }
        [Display(Name = "Ward Name")]
        public string Ward_Name { get; set; }
        [Display(Name = "Date of admition")]
        public string DateOfAdmition { get; set; }
        [Required, Display(Name = "Admitted for?")]
        public string AdmittedFor { get; set; }
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
        public RecoveryChances RecoveryChances { get; set; }
        [Required, Display(Name = "Does a patient require treatment?")]
        public string RecommendedTreatment { get; set; }
        [Required, Display(Name = "Can a patient survive if treatment is taken?")]
        public SuucessOfRecoveryIftreatmentTaken SuucessOfRecoveryIftreatmentTaken { get; set; }



        //NEXT OF KIN INFORMATION
        [Required, Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Home Address")]
        public string Address { get; set; }
        [Required, Display(Name = "Relationship to the patient")]
        public string RealtionshipToThePatient { get; set; }
        [Required, Display(Name = "Cell Number")]
        public string CellNo { get; set; }
        [Display(Name = "Email Address")]
        public string? P_EmailAddress { get; set; }
        [Display(Name = "Home Number")]
        public string? HomeNumber { get; set; }
        [Display(Name = "Work Number")]
        public string? WorkNumber { get; set; }
        [Display(Name = "Work Email Address")]
        public string? WorkEmailAddress { get; set; }
        [Required(ErrorMessage = "Doctor's Firts Name is required!")]
        [Display(Name = "Doctor's First Name")]
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
        public string SubscriberName { get; set; }
        [Required, Display(Name = "Contact Number")]
        public string PhoneNumber { get; set; }
        [Required, Display(Name = "Realtionship to the Patient")]
        public string RelationShipToThePatient { get; set; }
        [Required, Display(Name = "Amount Owe")]
        public double AmountOwe { get; set; }
        [Required, Display(Name = "Amount Payed")]
        public double AmountPayed { get; set; }
        [Required, Display(Name = "Method of payement")]
        public string MethodOfPayement { get; set; }
        [Required, Display(Name = "Do you smoke?")]
        public Smoking Smoking { get; set; }
        [Required, Display(Name = "DO you take drugs?")]
        public DrugUse_Abuse DrugUse_Abuse { get; set; }
        [Required, Display(Name = "Do you Excercise?")]
        public Excercise Excercise { get; set; }
        [Required, Display(Name = "Do you drink alchol?")]
        public AlcoholIntake AlcoholIntake { get; set; }
        [Required, Display(Name = "Do you have any special diet?")]
        public Diet Diet { get; set; }
        [Required, Display(Name = "Have you been diagnosied yet?")]
        public PresentDiagnisis PresentDiagnisis { get; set; }
        [Required, Display(Name = "Have you been diagnosied before?")]
        public PastDiagnosis PastDiagnosis { get; set; }
        [Required, Display(Name = "Do you have any medical care?")]
        public MedicalCare MedicalCare { get; set; }
        [Required, Display(Name = "Are you on a treatment?")]
        public Treatment Treatment { get; set; }
        [Required, Display(Name = "Do you have any allegies?")]
        public Allegies Allegies { get; set; }
        public string MedicationName { get; set; }
        public string TypeOfMedication { get; set; }
        public string Symptoms { get; set; }
        public string MedicationFor { get; set; }
        public DateTime StartTime { get; set; }
        public string DurationOfMedication { get; set; }
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
        public string CompanyName { get; set; }
        [Required, Display(Name = "Company Address")]
        public string CompanyAddress { get; set; }
        [Required, Display(Name = "Company Contact Number")]
        public string CompanyContactNumber { get; set; }
        [Required, Display(Name = "Your Manager's Name")]
        public string ManagerName { get; set; }
        [Required, Display(Name = "Your manager's Email")]
        public string ManagerEmail { get; set; }
        public string Occupation { get; set; }
    }
}
