using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Models;

namespace OrderManagementSystem.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        public UserController(IMapper mapper)
        {
            _mapper = mapper;
        }

        private List<User> users = new List<User>(){
            new User() {Id = 1, LastName = "Hoang", FirstName = "Lan", Email = "hoanglan@gmail.com", BankAccountNumber = 123456789},
            new User() {Id = 2, LastName = "Hoang", FirstName = "Linh", Email = "hoanglinh@gmail.com", BankAccountNumber = 123456789},
            new User() {Id = 3, LastName = "Hoang", FirstName = "Tu", Email = "hoangtu@gmail.com", BankAccountNumber = 123456789},
        };

        [HttpGet]
        public ActionResult<List<UserDTO>> GetAllUsers()
        {
            List<UserDTO> userDTOs = _mapper.Map<List<UserDTO>>(users);

            return Ok(userDTOs);
        }
    }
}