using NASA_App.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NASA_App.Data
{
    public class RoverPhoto
    {
    public int Id { get; set; }

    public int Sol { get; set; }

    public Camera Camera { get; set; }

    public Uri Img_src { get; set; }

    public string Earth_date { get; set; }

    public Rover Rover { get; set; }
    }
}
