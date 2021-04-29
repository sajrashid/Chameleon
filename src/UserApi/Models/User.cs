using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSignalR.Server.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<Role> Roles { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastLogin { get; set; }
    }
}
