using System.Text.Json.Serialization;

namespace Chameleon.Shared
{
    public class HelloWorld
    {
        [JsonPropertyName("greetings")]
        public string Greetings { get; set; }
    }
}