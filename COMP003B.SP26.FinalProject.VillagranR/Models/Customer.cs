using System.ComponentModel.DataAnnotations;

namespace COMP003B.SP26.FinalProject.VillagranR.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required]
        [StringLength(30)]
        public string? Name { get; set; }
     

        [Required]
        [EmailAddress]
        public string? Address { get; set; }

        [Required]
        [Phone]
        public string? Phone { get; set; }
        
        public ICollection<Vehicle>? Vehicles { get; set; }
    }
}
