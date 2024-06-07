using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Medication> Medications { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedication> PrescriptionMedications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PrescriptionMedication>()
            .HasKey(pm => new { pm.PrescriptionId, pm.MedicationId });

        modelBuilder.Entity<PrescriptionMedication>()
            .HasOne(pm => pm.Prescription)
            .WithMany(p => p.PrescriptionMedications)
            .HasForeignKey(pm => pm.PrescriptionId);

        modelBuilder.Entity<PrescriptionMedication>()
            .HasOne(pm => pm.Medication)
            .WithMany(m => m.PrescriptionMedications)
            .HasForeignKey(pm => pm.MedicationId);
    }
}
