using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Shared.Models
{
    public class HelloWorld
    {
        [JsonPropertyName("greetings")]
        public string Greetings { get; set; }
    }
}
