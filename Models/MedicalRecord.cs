
using System.ComponentModel.DataAnnotations;

namespace VetCare.Models;

public class MedicalRecord
{
    public int Id { get; set; }

    public int AppointmentId { get; set; }
    public Appointment Appointment { get; set; } = null!;

    [Required]
    [MaxLength(500)]
    public string Diagnosis { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string? Treatment { get; set; }

    [MaxLength(1000)]
    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; }
        = DateTime.UtcNow;
}
