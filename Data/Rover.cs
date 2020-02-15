using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NASA_App.Data
{
    public class Rover
    {
        public int Rover_Id { get; set; }
        
        public string Full_Name { get; set; }

        public Uri Img_Src { get; set; }

        public List<Photo> Photos { get; set; }

        public string Earth_Date { get; set; }

        public List<Camera> Cameras { get; set; }

    }
}
