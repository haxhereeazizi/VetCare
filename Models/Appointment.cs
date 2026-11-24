
using System.ComponentModel.DataAnnotations;

namespace VetCare.Models;

public class Appointment
{
    public int Id { get; set; }

    public int PetId { get; set; }
    public Pet Pet { get; set; } = null!;

    public int VeterinarianId { get; set; }
    public Veterinarian Veterinarian { get; set; } = null!;

    public int ServiceId { get; set; }
    public Service Service { get; set; } = null!;

    [Required]
    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public AppointmentStatus Status { get; set; }
        = AppointmentStatus.Pending;

    [MaxLength(500)]
    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; }
        = DateTime.UtcNow;

        public MedicalRecord? MedicalRecord { get; set; }
}
