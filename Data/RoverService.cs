using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace NASA_App.Data
{
    public class RoverService
    {
        static readonly HttpClient httpClient = new HttpClient();
        public List<Photo> returnedPhotos;
        public int RoverPosition { get; set; }
        public Photo CurrentPhoto { get; set; }
        public Rover Rover { get; set; }
        //TODO fix naming violation
        public DateTime randomDate { get; set; }
        public string RoverPath { get; set; }

        public async Task<Rover> GetRoverDataAsync()
        {
            randomDate = GetRandomDate();
            Camera camera; 
             Rover = null;
            RoverPosition = 0;
            RoverPath = "https://api.nasa.gov/mars-photos/api/v1/rovers/opportunity/photos?earth_date=" + randomDate.ToString("yyyy-MM-dd") + "&api_key=HbTKyhkhfs0fqB7QalcH4XuQJ9VzelFT3Lgxxspa";

            HttpResponseMessage response = await httpClient.GetAsync(RoverPath);
            if(response.IsSuccessStatusCode)
            {
                
               
                Rover = await response.Content.ReadAsAsync<Rover>();
                //TODO look at camera 
                camera = await response.Content.ReadAsAsync<Camera>();

                returnedPhotos = Rover.Photos;

                if (returnedPhotos.Count > 0)
                {
                    CurrentPhoto = returnedPhotos[RoverPosition];
                    
                }

                else
                {
                   await this.GetRoverDataAsync();
                }


            }

            return Rover;
        }

        public void NextPicture()
        {
            if (RoverPosition < returnedPhotos.Count -1)
            {
                RoverPosition++;
                CurrentPhoto = returnedPhotos[RoverPosition];
            }

            else
            {
               
                CurrentPhoto = returnedPhotos[RoverPosition];
            }
        }

        public void PreviousPicture()
        {
            if (RoverPosition > 0)
            {
                RoverPosition--;
                CurrentPhoto = returnedPhotos[RoverPosition];
            }

            else
            {
            
                CurrentPhoto = returnedPhotos[RoverPosition];
            }

        }

        public DateTime GetRandomDate()
        {
            Random random = new Random();
            DateTime start = new DateTime(2013, 1, 1);
            DateTime end = new DateTime(2015, 12, 31);
            int range = (end - start).Days;
            return start.AddDays(random.Next(range));

        }



    }


}
