using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicalApp.Models
{
    public class MedsCollectionDetails
    {
        [Key]
        public int Id { get; set; }
        public int MedicId { get; set; }
        [ForeignKey("MedicId")]
        public MedsToBeCollected MedsToBeCollected { get; set; }
        [Required]
        [Display(Name ="Collection Date")]
        public DateTime CollectionDate { get; set; }
        public int MedicineId { get; set; }
        [ForeignKey("MedicineId")]
        public virtual Meds Meds { get; set; }
        public int Count  { get; set; }
        public double Price { get; set; }
        [Display(Name ="Full Names")]
        public string FullNames { get; set; }
        [Display(Name ="Contact Number")]
        public string ContacNumber { get; set; }
    }
}
