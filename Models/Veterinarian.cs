
using System.ComponentModel.DataAnnotations;

namespace VetCare.Models;

public class Veterinarian
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Specialization { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Biography { get; set; }

    public string UserId { get; set; } = string.Empty;

    public ApplicationUser User { get; set; } = null!;

    public ICollection<Appointment> Appointments { get; set; }
    = new List<Appointment>();

public ICollection<Availability> Availabilities { get; set; }
    = new List<Availability>();

public ICollection<Vaccination> Vaccinations { get; set; }
    = new List<Vaccination>();
}
