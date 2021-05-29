using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chameleon.Shared
{
    public class GlbModel
    {
        public int Id { get; set; }

        [Required]
        public string ModelId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Src { get; set; }
        [Required]
        public string Alt { get; set; }

        public string Style { get; set; }
    }
}
