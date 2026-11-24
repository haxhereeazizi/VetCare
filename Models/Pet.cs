
using System.ComponentModel.DataAnnotations;

namespace VetCare.Models;

public class Pet
{
    public int Id { get; set; } //primary key for pet

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty; //name of the pet

    [Required]
    [MaxLength(50)]
    public string Species { get; set; } = string.Empty; //species of the pet

    [MaxLength(100)]
    public string? Breed { get; set; } //breed of the pet

    public DateTime? BirthDate { get; set; } //birth date of the pet

    [MaxLength(20)]
    public string? Gender { get; set; } //gender of the pet

    public string OwnerId { get; set; } = string.Empty; //foreign key to the ApplicationUser (owner) of the pet

public ApplicationUser Owner { get; set; } = null!; //navigation property to the ApplicationUser (owner) of the pet
}
