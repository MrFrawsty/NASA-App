using System;
using System.Threading.Tasks;

namespace NASA_App.Data
{
    public interface IApodService
    {
        Task<Apod> GetApodAsync(string path);
        Task<Apod> GetNextApodAsync(string path, string date);
        DateTime NextDay(DateTime selectedDate);
        DateTime PreviousDay(DateTime selectedDate);
    }
}