using Gainzville.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gainzville.Client.Services
{
    public interface IDataService
    {
        Task<WeatherForecast[]> GetWeatherForecasts();

        Task<IEnumerable<Profile>> GetProfiles();
    }
}
