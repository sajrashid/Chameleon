namespace Chameleon.Shared
{
    using System.ComponentModel.DataAnnotations;

    public class Machine
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Host { get; set; }
    }
}