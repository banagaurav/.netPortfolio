using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6)] // Enforce minimum password length
        public string Password { get; set; }

        [Required]
        [StringLength(20)]
        public string Role { get; set; }

    }
}