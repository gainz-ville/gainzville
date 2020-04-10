using Gainzville.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gainzville.Server.Services
{
    public interface IGainzService
    {
        public Task<WeatherForecast[]> GetWeatherForecasts();

        public Task<IEnumerable<Profile>> GetProfiles();
    }
}