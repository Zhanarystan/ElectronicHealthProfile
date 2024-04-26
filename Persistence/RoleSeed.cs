using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronicHealthProfile.Entities;
using Microsoft.AspNetCore.Identity;

namespace ElectronicHealthProfile.Persistence;

public class RoleSeed
{
    public static async Task SeedData(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        string adminEmail = "admin@gmail.com";
        string password = "Admin_12345";

        if (await roleManager.FindByNameAsync("system_admin") == null)
            await roleManager.CreateAsync(new IdentityRole("system_admin"));
        if (await roleManager.FindByNameAsync("institution_admin") == null)
            await roleManager.CreateAsync(new IdentityRole("institution_admin"));
        if (await roleManager.FindByNameAsync("medical_staff") == null)
            await roleManager.CreateAsync(new IdentityRole("medical_staff"));
        if (await roleManager.FindByNameAsync("student") == null)
            await roleManager.CreateAsync(new IdentityRole("student"));

        if (await userManager.FindByEmailAsync(adminEmail) == null)
        {
            AppUser admin = new AppUser { Email = adminEmail, UserName = adminEmail, UserType = UserType.Admin };
            var result = await userManager.CreateAsync(admin, password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, "system_admin");
            }
        }
    }
}
