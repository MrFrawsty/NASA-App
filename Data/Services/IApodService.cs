using System;
using System.Threading.Tasks;

namespace NASA_App.Data
{
    public interface IApodService
    {
        Task<Apod> GetApodAsync();
        Task<Apod> GetNextApodAsync(string date);
        DateTime NextDay(DateTime selectedDate);
        DateTime PreviousDay(DateTime selectedDate);
    }
}