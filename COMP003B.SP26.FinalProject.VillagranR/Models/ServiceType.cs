using System.ComponentModel.DataAnnotations;

namespace COMP003B.SP26.FinalProject.VillagranR.Models
{
    public class ServiceType
    {
        public int ServiceTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string? ServiceName { get; set; }

        [Required]
        [StringLength(500)]
        public string? Description { get; set; }

        [Range(0, 5000)]
        public int Price { get; set; }

        public int EstimatedHours { get; set; }

        public bool IsActive { get; set; }

        public ICollection<ServiceAppointment>? ServiceAppointments { get; set; }
    }
}
