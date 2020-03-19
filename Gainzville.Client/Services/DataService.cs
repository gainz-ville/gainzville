using Gainzville.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Gainzville.Client.Services
{
    internal class DataService : IDataService
    {
        public DataService(HttpClient httpClient)
        {
            this.HttpClient = httpClient;
#if DEBUG
            this.HttpClient.BaseAddress = new Uri("http://localhost:5050/");
#else
            this.HttpClient.BaseAddress = new Uri("http://gainzville.co.uk:5050/");
#endif
        }

        public HttpClient HttpClient { get; }

        public Task<WeatherForecast[]> GetWeatherForecasts()
        {
            return this.HttpClient.GetJsonAsync<WeatherForecast[]>("weatherforecast");
        }

        public Task<IEnumerable<Profile>> GetProfiles()
        {
            return this.HttpClient.GetJsonAsync<IEnumerable<Profile>>("api/profiles");
        }
    }
}
