using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace NASA_App.Data
{
    public class ApodService : IApodService
    {
        private readonly IHttpClientFactory _clientFactory;
        private static readonly string _path = "https://api.nasa.gov/planetary/apod?api_key=HbTKyhkhfs0fqB7QalcH4XuQJ9VzelFT3Lgxxspa";

        public ApodService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<Apod> GetApodAsync()
        {
            var client = _clientFactory.CreateClient();
            Apod apod = null;
            var request = new HttpRequestMessage(HttpMethod.Get, _path);

            try
            {
                HttpResponseMessage response = await client.SendAsync(request);

                using var responseStream = await response.Content.ReadAsStreamAsync();
                apod = await JsonSerializer.DeserializeAsync<Apod>(responseStream);

                return apod;
            }

            catch(HttpRequestException e)
            {
                var message = e.Message;
                return new Apod();
            }

        }

        public async Task<Apod> GetNextApodAsync(string date)
        {
            var client = _clientFactory.CreateClient();
            Apod nextApod = new Apod();

            var request = new HttpRequestMessage(HttpMethod.Get, _path + "&date=" + date);

            try
            { 
                 HttpResponseMessage response = await client.SendAsync(request);
              
                  using var responseStream = await response.Content.ReadAsStreamAsync();
                  nextApod = await JsonSerializer.DeserializeAsync<Apod>(responseStream);
                  return nextApod;
            }
            catch(HttpRequestException e)
            {
                var message = e.Message;
                return new Apod();
            }

        }


        public DateTime NextDay(DateTime selectedDate)
        {
            if (selectedDate.Date == DateTime.Now.Date)
            {

                return selectedDate;
            }

            else
            {
                selectedDate = selectedDate.AddDays(01);
                return selectedDate;
            }

        }

        public DateTime PreviousDay(DateTime selectedDate)
        {
            selectedDate = selectedDate.AddDays(-1);

            return selectedDate;
        }

    }
}
