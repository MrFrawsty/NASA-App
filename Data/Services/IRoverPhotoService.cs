using NASA_App.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NASA_App.Data
{
    public interface IRoverPhotoService
    {
        string GetRandomDate();
        Task<List<Photo>> GetRoverPhotos(string path);
        string DisplayPhotoIndex(int idx, int count);
    }
}