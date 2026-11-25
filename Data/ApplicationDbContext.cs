
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VetCare.Models;

namespace VetCare.Data;

public class ApplicationDbContext
    : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Pet> Pets { get; set; }
    public DbSet<Veterinarian> Veterinarians { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Vaccination> Vaccinations { get; set; }
    public DbSet<MedicalRecord> MedicalRecords { get; set; }
    public DbSet<Availability> Availabilities { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Service>()
            .Property(s => s.Price)
            .HasPrecision(10, 2);

        builder.Entity<Veterinarian>()
            .HasIndex(v => v.UserId)
            .IsUnique();

        builder.Entity<Appointment>()
            .HasOne(a => a.MedicalRecord)
            .WithOne(m => m.Appointment)
            .HasForeignKey<MedicalRecord>(m => m.AppointmentId);

        builder.Entity<Appointment>()
            .HasIndex(a => new
            {
                a.VeterinarianId,
                a.StartTime
            });
    }
}
