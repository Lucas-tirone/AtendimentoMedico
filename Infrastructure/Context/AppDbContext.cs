using Microsoft.EntityFrameworkCore;
using AtendimentoMedico.Domain.Models;

namespace AtendimentoMedico.Infraestructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Consultation>? Consultations { get; set; }
        public DbSet<Doctor>? Doctors { get; set; } 
        public DbSet<Patient>? Patients { get; set; }
        public DbSet<MedicalRecord>? MedicalRecords { get; set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().Property(d => d.Active).HasDefaultValue(true);
            modelBuilder.Entity<Patient>().Property(p => p.Active).HasDefaultValue(true);
            modelBuilder.Entity<Consultation>().Property(c => c.Status).HasDefaultValue("Agendada");
        }*/
    }
}
