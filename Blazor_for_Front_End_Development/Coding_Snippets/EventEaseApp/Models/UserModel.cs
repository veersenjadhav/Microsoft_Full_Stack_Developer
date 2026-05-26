using System.ComponentModel.DataAnnotations;

namespace EventEaseApp.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "User name is required.")]
        [StringLength(50, ErrorMessage = "Name is too long.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }
    }
}