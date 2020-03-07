﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NASA_App.Data
{
    public class RoverService
    {
        static readonly HttpClient httpClient = new HttpClient();
        public List<Photo> returnedPhotos { get; set; }
        public int RoverPosition { get; set; }
        public Photo CurrentPhoto { get; set; }
        public Rover Rover { get; set; }
        
    

        public async Task<Rover> GetRoverDataAsync(string path)
        {
            Camera camera; 
             Rover = null;
            RoverPosition = 0;

            HttpResponseMessage response = await httpClient.GetAsync(path);
            if(response.IsSuccessStatusCode)
            {
                
                Rover = await response.Content.ReadAsAsync<Rover>();
                camera = await response.Content.ReadAsAsync<Camera>();

                returnedPhotos = Rover.Photos;
                returnedPhotos.Clear();

                if (returnedPhotos.Count > 0)
                    {
                       
                        CurrentPhoto = returnedPhotos[RoverPosition];
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
