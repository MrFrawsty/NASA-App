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
        static List<Photo> returnedRovers = new List<Photo>();
        public int roverPosition;
        public Photo currentPhoto;
        public Rover rover;
        public Uri imageUri;

        public async Task<Rover> GetRoverDataAsync(string path)
        {
            Rover rover = null;
            Camera camera = null;
          

            HttpResponseMessage response = await httpClient.GetAsync(path);
            if(response.IsSuccessStatusCode)
            {
                rover = await response.Content.ReadAsAsync<Rover>();
                camera = await response.Content.ReadAsAsync<Camera>();

                returnedRovers = rover.Photos;
                currentPhoto = returnedRovers[roverPosition];

            }

            return rover;
        }

        public void NextPicture()
        {
            for (int i = 0; i < roverPosition; i++)
            {

                currentPhoto = returnedRovers[i];
            }

            roverPosition++;

        }


    }


}
