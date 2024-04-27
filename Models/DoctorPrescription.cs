using System.ComponentModel.DataAnnotations;

namespace ClinicalApp.Models
{
    public class DoctorPrescription
    {
        
        [Key]
        public int Id { get; set; }
        public string DoctorFirstName { get; set; }
        public string DoctorLastName { get; set; }
        [EmailAddress]
        public string DoctorEmail { get; set; }
        public string DoctorAddress { get; set; }
        public string DoctorPhoneNumber { get; set; }
        public string DoctorDepartmetment { get; set; }
        public string PatientName { get; set; }
        public decimal Amount { get; set; }
        public int Frequency { get; set; }
    }
}