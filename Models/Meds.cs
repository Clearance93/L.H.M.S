using System.ComponentModel.DataAnnotations;

namespace ClinicalApp.Models
{
    public class Meds
    {
        [Key]
        public int MedicineId { get; set; }
        public string Image { get; set; }
        [Required, Display(Name ="Name of Medication")]
        public string NameOfMedication { get; set; }
        public string Discription { get; set; }
        [Required, Display(Name ="Type Of Medication")]
        public string TypOfMedication { get; set; }
        [Required, Display(Name ="Type Of Chronic")]
        public string TypeOfChronic { get; set; }
    }
}
