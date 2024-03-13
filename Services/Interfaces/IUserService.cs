using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Models;

namespace OrderManagementSystem.Services
{
    public interface IUserService 
    {
        ActionResult<IEnumerable<User>> GetAllUsers();
        ActionResult<User> GetUserById(int id);
        ActionResult<User> AddUser();
        ActionResult<User> DeleteUser();
    }
}