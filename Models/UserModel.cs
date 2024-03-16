using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace OrderManagementSystem.Models
{
    public class User : IdentityUser
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        //Sensitive information
        public int BankAccountNumber { get; set; }
    }
}
