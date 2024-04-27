using System.ComponentModel.DataAnnotations;

namespace ClinicalApp.Models
{
    public class UserRole
    {
        [Key]
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string City_Town { get; set; }
        public ContractType ContractType { get; set; }
        public string Country { get; set; }
        public DateTime DateStarted { get; set; }
        public Department Department { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Position Position { get; set; }
        public string StreetName { get; set; }
        public string Surbub { get; set; }
        public string Title { get; set; }
        public string ZipCode { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string ConcurrencyStamp { get; set; }
    }
}
