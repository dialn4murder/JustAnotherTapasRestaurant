using Microsoft.AspNetCore.Identity;

namespace JustAnotherTapasRestaurant.Data
{
    public class IdentitySeedData
    {
        public static async Task Initialize(JustAnotherTapasRestaurantContext context,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            // Ensures database is created
            context.Database.EnsureCreated();

            // Adding roles
            string adminRole = "Admin";
            string memberRole = "Member";
            string universalPassword = "P@55w0rd";

            // Look for an existing admin role and if theres none create it
            if (await roleManager.FindByNameAsync(adminRole) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(adminRole));
            }

            // Look for an existing member role if not create it

            if (await roleManager.FindByNameAsync(memberRole) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(memberRole));
            }

            // Checks if there are admin roles, if not it will create them
            if (await userManager.FindByNameAsync("admin@chester.ac.uk") == null)
            {
                var user = new IdentityUser
                {
                    UserName = "admin@chester.ac.uk",
                    Email = "admin@chester.ac.uk",
                    PhoneNumber = "1234567890",
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, universalPassword);
                    await userManager.AddToRoleAsync(user, adminRole);
                }
            }

            // Checks if there are admin roles, if not it will create them
            if (await userManager.FindByNameAsync("member@chester.ac.uk") == null)
            {
                var user = new IdentityUser
                {
                    UserName = "member@chester.ac.uk",
                    Email = "member@chester.ac.uk",
                    PhoneNumber = "1234567890",
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, universalPassword);
                    await userManager.AddToRoleAsync(user, adminRole);
                }
            }
        }
    }
}
