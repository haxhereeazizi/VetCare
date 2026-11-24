
using System.ComponentModel.DataAnnotations;

namespace VetCare.Models;

public class Vaccination
{
    public int Id { get; set; }

    public int PetId { get; set; }
    public Pet Pet { get; set; } = null!;

    public int VeterinarianId { get; set; }
    public Veterinarian Veterinarian { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string VaccineName { get; set; } = string.Empty;

    public DateTime VaccinationDate { get; set; }

    public DateTime? NextVaccinationDate { get; set; }

    [MaxLength(500)]
    public string? Notes { get; set; }
}
