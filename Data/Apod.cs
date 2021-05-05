using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NASA_App.Data
{
   
    public class Apod
    {
        [JsonPropertyName("copyright")]
        public string CopyRight { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("explanation")]
        public string Explanation { get; set; }

        [JsonPropertyName("hdrul")]
        public Uri HDUri { get; set; }

        [JsonPropertyName("url")]
        public Uri Url { get; set; }

        [JsonPropertyName("media_type")]
        public string MediaType { get; set; }


    }
}
