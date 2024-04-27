using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicalApp.Models
{
    public class Bookings
    {
        [Key]
        public int BookingsId { get; set; }
       [ForeignKey("PatientId")]
       [ValidateNever]
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        [Display(Name ="Patient booking slot")]
        public DateTime PatientBookingSlot { get; set; }
        public string Status { get; set; }
        public string? Comments { get; set; }
        public double Transactions { get; set; }
        [Display(Name ="Patient Full Names")]
        public string PatientFulleNames { get; set; }
    }
}
