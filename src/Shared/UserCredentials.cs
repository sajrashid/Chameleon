using System.ComponentModel.DataAnnotations;

namespace Chameleon.Shared
{
    public class UserCredentials
    {
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Password nust be a minimum of 8 characters!")]
        public string Password { get; set; }
    }
}