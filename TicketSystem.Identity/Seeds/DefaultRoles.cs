using Microsoft.AspNetCore.Identity;
using TicketSystem.Identity.Constants;

namespace TicketSystem.Identity.Seeds;

public static class DefaultRoles
{
    public static async Task SeedAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        await roleManager.CreateAsync(new IdentityRole(Roles.SuperAdmin.ToString()));
        await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
    }
}
