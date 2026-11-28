
using Microsoft.AspNetCore.Identity;
using VetCare.Constants;
using VetCare.Models;

namespace VetCare.Data
{
    public static class AdminSeeder
    {
        public static async Task SeedAdminAsync(
            IServiceProvider serviceProvider,
            IConfiguration configuration)
        {
            var userManager = serviceProvider
                .GetRequiredService<UserManager<ApplicationUser>>();

            var email = configuration["AdminSettings:Email"];
            var password = configuration["AdminSettings:Password"];

            if (string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
            {
                return;
            }

            var existingUser = await userManager.FindByEmailAsync(email);

            if (existingUser != null)
            {
                if (!await userManager.IsInRoleAsync(
                    existingUser, RoleNames.Admin))
                {
                    throw new InvalidOperationException(
                        "Admin email is already used by another account.");
                }

                return;
            }

            var admin = new ApplicationUser
            {
                FirstName = "System",
                LastName = "Admin",
                UserName = email,
                Email = email,
                EmailConfirmed = true
            };

            var createResult = await userManager.CreateAsync(
                admin, password);

            if (!createResult.Succeeded)
            {
                var errors = string.Join(", ",
                    createResult.Errors.Select(e => e.Description));

                throw new InvalidOperationException(
                    $"Could not create admin: {errors}");
            }

            var roleResult = await userManager.AddToRoleAsync(
                admin, RoleNames.Admin);

            if (!roleResult.Succeeded)
            {
                var errors = string.Join(", ",
                    roleResult.Errors.Select(e => e.Description));

                throw new InvalidOperationException(
                    $"Could not assign admin role: {errors}");
            }
        }
    }
}
