using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicalApp.Models
{
    public class FinancialInformation
    {
        [Key]
        public int FinancialInfoId { get; set; }
        [ForeignKey("PatientId")]
        public int? PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        [Required, Display(Name ="Subscriber Full Names")]
        public string SubscriberName { get; set; }
        [Required, Display(Name ="Contact Number")]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        [Required, Display(Name ="Realtionship to the Patient")]
        public string RelationShipToThePatient { get; set; }
        [Required, Display(Name ="Amount Owe")]
        public double AmountOwe { get; set; }
        [Required, Display(Name ="Amount Payed")]
        public double AmountPayed { get; set; }
        [Required, Display(Name ="Method of payement")]
        public string MethodOfPayement { get; set; }
    }
}
