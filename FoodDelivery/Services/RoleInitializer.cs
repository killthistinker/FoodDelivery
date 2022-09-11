using System.Threading.Tasks;
using FoodDelivery.Models;
using Microsoft.AspNetCore.Identity;

namespace FoodDelivery.Services
{
    public class RoleInitializer
    {
        public static async Task SeedARoleUser(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            string adminEmail = "admin@gmail.com";
            string password = "12345";
            var roles = new[] { "user", "admin", "administrator" };

            foreach (var role in roles)     
            {
                if (await roleManager.FindByNameAsync(role) is null)
                {
                    await roleManager.CreateAsync(new Role{Name = role});
                }
            }
            
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                User admin = new User { Email = adminEmail, UserName = adminEmail, IamAdmin = true};
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
    }
}