namespace COMP003B.SP26.FinalProject.VillagranR.Models
{
    public class ServiceAppointment
    {
        public int ServiceAppointmentId {  get; set; }

        public int VehicleId { get; set; }

        public int MechanicId { get; set; }

        public int ServiceTypeId { get; set; }

        public virtual Vehicle? Vehicle { get; set; }

        public virtual Mechanic? Mechanic { get; set; }

        public virtual ServiceType? ServiceType { get; set; }
    }
}
