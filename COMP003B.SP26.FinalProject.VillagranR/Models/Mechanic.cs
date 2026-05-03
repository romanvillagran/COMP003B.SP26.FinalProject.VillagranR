using System.ComponentModel.DataAnnotations;

namespace COMP003B.SP26.FinalProject.VillagranR.Models
{
    public class Mechanic
    {
        public int MechanicId { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [Required]
        [StringLength(50)]
        public string? Specialty { get; set; }

        [Range(0,100)]
        public int YearsExperience { get; set; }

        [Required]
        public string? CertificationNumber { get; set; }

        public bool IsAvailable { get; set; }

        [StringLength(100)]
        public string? ShopLocation { get; set; }

        public ICollection<ServiceAppointment>? serviceAppointments { get; set; }
    }
}