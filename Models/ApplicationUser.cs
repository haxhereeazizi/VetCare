
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace VetCare.Models;

public class ApplicationUser : IdentityUser
{
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; } = string.Empty;

    public ICollection<Pet> Pets { get; set; } = new List<Pet>(); // Navigation property for the user's pets
}
