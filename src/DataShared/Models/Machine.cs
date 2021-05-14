using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataShared.Models
{
    public class Machine
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("default")]
        public string Default { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("model")]
        public string Model { get; set; }
        [JsonPropertyName("firmware")]
        public string Firmware { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("createdDate")]
        public DateTime CreatedDate { get; set; }
    }
}
