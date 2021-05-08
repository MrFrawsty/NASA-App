using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NASA_App.Data.Models
{
    public class Photo
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("sol")]
        public int Sol { get; set; }

        [JsonPropertyName("camera")]
        public Camera Camera { get; set; }

        [JsonPropertyName("img_src")]
        public string ImgSrc { get; set; }

        [JsonPropertyName("earth_date")]
        public string EarthDate { get; set; }

        [JsonPropertyName("rover")]
        public Rover Rover { get; set; }
    }
}
