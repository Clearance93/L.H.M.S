using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicalApp.Models
{
    public class MedsToBeCollected
    {
        [Key]
        public int MedicId { get; set; }
        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        [ValidateNever]
        public Patient Patient { get; set; }
        [DisplayFormat(DataFormatString ="{0:C")]
        [Display(Name ="Total")]
        public double Total { get; set; }
        [Display(Name ="Pick up Time")]
        public DateTime PickUpTime { get; set; }
        [Required, Display(Name = "Pick up Date")]
        [NotMapped]
        public DateTime PickUpDate { get; set; }

        public string MedsStatus { get; set; }
        [Display(Name ="Full Names")]
        public string FullNames { get; set; }
        [Display(Name ="Contact Number")]
        public string ContactNumber { get; set; }
    }
}
