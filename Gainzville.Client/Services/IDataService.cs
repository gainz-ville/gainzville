using Gainzville.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gainzville.Client.Services
{
    public interface IDataService
    {
        Task<WeatherForecast[]> GetWeatherForecasts();

        Task<IEnumerable<Profile>> GetProfiles();

        Task<Profile> PostProfile(Profile profile);
    }
}
