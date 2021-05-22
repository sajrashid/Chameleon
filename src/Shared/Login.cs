using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chameleon.Shared
{
    public class Login
    {

        [Required]
        [MinLength(6, ErrorMessage = "UserName nust be a minimum of 6 characters!")]
        public string Username { get; set; }

        [Required]
        [MinLength(6,ErrorMessage="Password nust be a minimum of 8 characters!")]
        public string Password { get; set; }
    }
}
