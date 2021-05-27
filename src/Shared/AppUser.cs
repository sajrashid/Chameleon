using System;
using System.ComponentModel.DataAnnotations;

namespace Chameleon.Shared
{
    public class AppUser
    {
        public int Id { get; set; }

        [Required]
        public String Email { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "The Password field must be a minimum of 6 characters")]
        public string Password { get; set; }

        public string Theme { get; set; }
    }
}