﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NASA_App.Data.Models
{
    public class Camera
    {

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("rover_id")]
        public int RoverId { get; set; }

        [JsonPropertyName("full_name")]
        public string FullName { get; set; }
    }
}
