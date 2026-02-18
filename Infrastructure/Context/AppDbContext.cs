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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consultation>()
                .HasOne(c => c.Patient)
                .WithMany()
                .HasForeignKey(c => c.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Consultation>()
                .HasOne(c => c.Doctor)
                .WithMany()
                .HasForeignKey(c => c.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Consultation>()
                .HasOne(c => c.MedicalRecord)
                .WithOne(m => m.Consultation)
                .HasForeignKey<MedicalRecord>(m => m.ConsultationId)
                .OnDelete(DeleteBehavior.Cascade);
            //lembrar que se apagar consulta, apaga o prontuario
        }
    }
}
