using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicalApp.Models
{
    public class WorkInformation
    {
        [Key]
        public int WorkId { get; set; }
        [ForeignKey("PatientId")]
        public int? PatientId { get; set; }
        public virtual  Patient Patient { get; set; }
        public string CompanyName { get; set; }
        [Required, Display(Name ="Company Address")]
        public string CompanyAddress { get; set; }
        [Required, Display(Name ="Company Contact Number")]
        public string CompanyContactNumber { get; set; }
        [Required, Display(Name ="Your Manager's Name")]
        public string ManagerName { get; set; }
        [Required, Display(Name ="Your manager's Email")]
        public string ManagerEmail { get; set; }
        public string Occupation { get; set; }
    }
}
