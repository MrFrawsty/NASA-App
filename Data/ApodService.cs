using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace NASA_App.Data
{
    public class ApodService : IApodService
    {
        private readonly IHttpClientFactory _clientFactory;


        public ApodService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<Apod> GetApodAsync(string path)
        {
            var client = _clientFactory.CreateClient();
            Apod apod = null;
            var request = new HttpRequestMessage(HttpMethod.Get, path);

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

        public async Task<Apod> GetNextApodAsync(string path, string date)
        {
            var client = _clientFactory.CreateClient();
            Apod nextApod = new Apod();

            var request = new HttpRequestMessage(HttpMethod.Get, path + "&date=" + date);

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
