using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NASA_App.Data.Models
{
    public class Root
    {
        [JsonPropertyName("photos")]
        public List<Photo> Photos { get; set; }
    }
}
