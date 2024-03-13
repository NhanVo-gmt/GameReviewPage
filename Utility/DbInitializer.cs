using Microsoft.AspNetCore.Identity;
using OrderManagementSystem.Models;

namespace OrderManagementSystem.Utility
{
    public class DbInitializer 
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
    }
}