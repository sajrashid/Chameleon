
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chameleon.Shared
{
    public class AppUser
    {
        public int Id { get; set; }
        [Required]
        public String FirstName{ get; set; }
        [Required]
        public String LastName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "The Password field must be a minimum of 6 characters")]
        public string Password { get; set; }
    }
}
