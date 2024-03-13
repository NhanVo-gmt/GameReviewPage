
using Microsoft.AspNetCore.Identity;
using OrderManagementSystem.Models;

namespace OrderManagementSystem.Utility
{
    public class RoleInventory : IRoleInventory
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<User> _userManager;

        public RoleInventory(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        
        public async Task AddRoleAsync(string UserId)
        {
            var user = await _userManager.FindByIdAsync(UserId);
            var roles = _roleManager.Roles;
            List<string> StringRoles = new List<string>();
            if (user != null)
            {
                foreach (var item in roles) 
                {
                    StringRoles.Add(item.Name);
                }
                await _userManager.AddToRolesAsync(user, StringRoles);
            }
        }

        public async Task CreateNewRoleAsync()
        {
            Type t = typeof(TopMenu);
            foreach (Type classObj in t.GetNestedTypes())
            {
                foreach (var objField in classObj.GetFields())
                {
                    if (objField.Name.Contains("RoleName"))
                    {
                        var roleName = (string)objField.GetValue(objField);
                        if (!await _roleManager.RoleExistsAsync(roleName))
                        {
                            await _roleManager.CreateAsync(new IdentityRole(objField.Name));
                        }
                    }
                }
            }
        }
    }
}