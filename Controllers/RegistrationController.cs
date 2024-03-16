using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OrderManagementSystem.Models;

namespace OrderManagementSystem.Controllers
{
    
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public RegistrationController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }       

        public async Task<IActionResult> UserInfo()
        {
            // var user = await _userManager.GetUserAsync(HttpContext.User).ConfigureAwait
        }
    }
}