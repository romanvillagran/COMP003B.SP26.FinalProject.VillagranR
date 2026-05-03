using System.ComponentModel.DataAnnotations;

namespace COMP003B.SP26.FinalProject.VillagranR.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string? Make { get; set; }

        [Required]
        [StringLength(30)]
        public string? Model { get; set; }

        [Range(1950,2027)]
        public int Year { get; set; }

        [Required]
        [StringLength(20)]
        public string?  LicensePlate { get; set; }

        [Required]
        [Range(0,500000)]
        public int Mileage { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer? Customer { get; set; }

        public ICollection<ServiceAppointment>? ServiceAppointment { get; set; }

    }
}
