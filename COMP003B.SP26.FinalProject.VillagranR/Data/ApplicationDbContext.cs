using COMP003B.SP26.FinalProject.VillagranR.Models;
using Microsoft.EntityFrameworkCore;

namespace COMP003B.SP26.FinalProject.VillagranR.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Vehicle> vehicles { get; set; }
        public DbSet<Mechanic > mechanics { get; set; }

        public DbSet<ServiceType> serviceTypes { get; set; }

        public DbSet<ServiceAppointment> serviceAppointment { get; set; }
    }
}
