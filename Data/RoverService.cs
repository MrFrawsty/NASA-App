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

        public async Task<Rover> GetRoverDataAsync(string path)
        {
            Rover rover = null;
          

            HttpResponseMessage response = await httpClient.GetAsync(path);
            if(response.IsSuccessStatusCode)
            {
                rover = await response.Content.ReadAsAsync<Rover>();
                
            }

            return rover;
        }


      
    }


}
