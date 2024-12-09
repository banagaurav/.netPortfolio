using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(20)]
        public string Role { get; set; } // You can set a default value for Role, like "User" if required
    }
}
