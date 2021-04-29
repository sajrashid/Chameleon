using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSignalR.Server.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
