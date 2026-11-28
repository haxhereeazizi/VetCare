
using Microsoft.AspNetCore.Identity;
using VetCare.Constants;

namespace VetCare.Data
{
    public static class RoleSeeder
    {
        public static async Task SeedRolesAsync(
            IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();

            string[] roles =
            {
                RoleNames.Admin,
                RoleNames.Veterinarian,
                RoleNames.PetOwner
            };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    var result = await roleManager.CreateAsync(
                        new IdentityRole(role));

                    if (!result.Succeeded)
                    {
                        var errors = string.Join(", ",
                            result.Errors.Select(e => e.Description));

                        throw new InvalidOperationException(
                            $"Could not create role {role}: {errors}");
                    }
                }
            }
        }
    }
}
