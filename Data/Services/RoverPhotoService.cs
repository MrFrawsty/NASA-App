using NASA_App.Data.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace NASA_App.Data
{
    public class RoverPhotoService : IRoverPhotoService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly string _key = "&api_key=HbTKyhkhfs0fqB7QalcH4XuQJ9VzelFT3Lgxxspa";

        public RoverPhotoService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        

        public async Task<List<Photo>> GetRoverPhotos(string partialPath)
        {
            var fullPath = partialPath + GetRandomDate() + _key;
            var client = _clientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, fullPath);
            

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

        public string DisplayPhotoIndex(int index, int count)
        {
            return $"{index + 1}" + "/" + $"{count}";
        }

        
        public string GetRandomDate()
        {
            Random random = new Random();
            DateTime start = new DateTime(2013, 1, 1);
            DateTime end = new DateTime(2015, 12, 31);
            int range = (end - start).Days;
            return start.AddDays(random.Next(range)).ToString("yyyy-MM-dd");

        }
    }
}
