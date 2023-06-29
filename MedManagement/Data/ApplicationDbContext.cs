using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MedManagement.Data;

namespace MedManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Doctor> Doctor { get; set; } 

        public DbSet<DoctorMedicalFacility> DoctorMedicalFacility { get; set; }

        public DbSet<Evaluation> Evaluation { get; set; }

        public DbSet<MedicalFacility> MedicalFacility { get; set; }

        public DbSet<Patient> Patient { get; set; } 

        public DbSet<Service> Service { get; set; } 

        public DbSet<Terms> Terms { get; set; } 

        public DbSet<User> User { get; set; }

        public DbSet<MedManagement.Data.DiseasesTreated> DiseasesTreated { get; set; } = default!;
    }
}