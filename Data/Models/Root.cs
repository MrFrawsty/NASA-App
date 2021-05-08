using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NASA_App.Data.Models
{
    public class Root
    {
        [JsonPropertyName("photos")]
        public List<Photo> Photos { get; set; }
    }
}
