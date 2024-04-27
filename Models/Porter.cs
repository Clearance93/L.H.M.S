using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicalApp.Models
{
    public class Porter 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        [Required, Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; }
        public Position Position { get; set; }
        [Display(Name = "Select the department you belong to")]
        public Department Department { get; set; }
        [Required, Display(Name = "Contract type")]
        public ContractType ContractType { get; set; }
        [Required, Display(Name = "Date Stated")]
        public DateTime DateStarted { get; set; }
        [EmailAddress]
        [Compare("Username")]
        [Required, Display(Name = "Street Name")]
        public string StreetName { get; set; }
        public string Surbub { get; set; }
        [Required, Display(Name = "City/Town")]
        public string City_Town { get; set; }
        [Required, Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
        public string Country { get; set; }
        [Required]
        public string Image { get; set; }
    }
}
