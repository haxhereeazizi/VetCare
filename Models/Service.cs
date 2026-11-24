
using System.ComponentModel.DataAnnotations;

namespace VetCare.Models;

public class Service
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Description { get; set; }

    [Range(0, 1000000)]
    public decimal Price { get; set; }

    [Range(1, 480)]
    public int DurationInMinutes { get; set; }

    public bool IsActive { get; set; } = true;

    public ICollection<Appointment> Appointments { get; set; }
    = new List<Appointment>();
    
}
