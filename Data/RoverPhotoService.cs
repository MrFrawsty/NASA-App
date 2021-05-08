using NASA_App.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace NASA_App.Data
{
    public class RoverPhotoService : IRoverPhotoService
    {
        private readonly IHttpClientFactory _clientFactory;
        private List<RoverPhoto> _roverPhotos;
        private Root _root;
        private int _currentPhotoIndex = 0;
        private string _photoPath;

        public RoverPhotoService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<List<Photo>> GetRoverPhotos(string path)
        {
            var client = _clientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, path);
            

            try
            {
                HttpResponseMessage response = await client.SendAsync(request);
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var root = await JsonSerializer.DeserializeAsync<Root>(responseStream);
             
                return root.Photos;
            }

            catch (HttpRequestException)
            {
                return new List<Photo>();
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
