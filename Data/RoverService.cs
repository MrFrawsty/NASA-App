using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NASA_App.Data
{
    public class RoverService
    {
        static readonly HttpClient httpClient = new HttpClient();
        public List<Photo> returnedRovers = new List<Photo>();
        static int roverPosition;
        public Photo CurrentPhoto { get; set; }
        public Rover Rover { get; set; }
    

        public async Task<Rover> GetRoverDataAsync(string path)
        {
            Camera camera; 
             Rover = null;

            HttpResponseMessage response = await httpClient.GetAsync(path);
            if(response.IsSuccessStatusCode)
            {
                Rover = await response.Content.ReadAsAsync<Rover>();
                camera = await response.Content.ReadAsAsync<Camera>();

                returnedRovers = Rover.Photos;
                CurrentPhoto = returnedRovers[roverPosition];

            }

            return Rover;
        }

        public void NextPicture()
        {
            if (roverPosition < returnedRovers.Count -1)
            {
                roverPosition++;
                CurrentPhoto = returnedRovers[roverPosition];
            }

            else
            {
               
                CurrentPhoto = returnedRovers[roverPosition];
            }
        }

        public void PreviousPicture()
        {
            if (roverPosition > 0)
            {
                roverPosition--;
                CurrentPhoto = returnedRovers[roverPosition];
            }

            else
            {
            
                CurrentPhoto = returnedRovers[roverPosition];
            }

        }

    }


}
