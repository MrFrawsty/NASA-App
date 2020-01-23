using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NASA_App.Data
{
    public class ApodService
    {
        
        static readonly HttpClient httpClient = new HttpClient();

        public async Task<Apod> GetApodAsync(string path)
        {
            Apod apod = null;

            HttpResponseMessage response = await httpClient.GetAsync(path);
            if(response.IsSuccessStatusCode)
            {
                apod = await response.Content.ReadAsAsync<Apod>();
            }

                return apod;
            
        }

        public async Task<Apod> GetNextApodAsync(string path, string date)
        {
            Apod nextApod = null;

            HttpResponseMessage response = await httpClient.GetAsync(path + "&date=" + date);
            if (response.IsSuccessStatusCode)
            {
                nextApod = await response.Content.ReadAsAsync<Apod>();
            }

            return nextApod;
        }


       public DateTime NextDay(DateTime selectedDate)
        {
            if(selectedDate < DateTime.Now)
            selectedDate = selectedDate.AddDays(01);

            return selectedDate;
        }

        public DateTime PreviousDay(DateTime selectedDate)
        {
            selectedDate = selectedDate.AddDays(-1);

            return selectedDate;
        }

    }
}
