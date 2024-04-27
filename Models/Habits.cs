using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicalApp.Models
{
    public class Habits
    {
        [Key]
        public int HabitsId { get; set; }
        [ForeignKey("PatientId")]
        public int? PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        [Required, Display(Name ="Do you smoke?")]
        public Smoking Smoking { get; set; }
        [Required, Display(Name ="DO you take drugs?")]
        public DrugUse_Abuse DrugUse_Abuse { get; set; }
        [Required, Display (Name ="Do you Excercise?")]
        public Excercise Excercise { get; set; }
        [Required, Display(Name ="Do you drink alchol?")]
        public AlcoholIntake AlcoholIntake { get; set; }
        [Required, Display(Name ="Do you have any special diet?")]
        public Diet Diet { get; set; }
    }

    public enum Diet
    {
        Yes,
        No,
    }

    public enum AlcoholIntake
    {
        Yes,
        No
    }

    public enum Excercise
    {
        Yes,
        No
    }

    public enum DrugUse_Abuse
    {
        Yes, No,
    }

    public enum Smoking
    {
        Yes,
        No
    }
}
