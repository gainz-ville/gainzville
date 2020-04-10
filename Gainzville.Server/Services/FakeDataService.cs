using Gainzville.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gainzville.Server.Services
{
    public class FakeDataService : IGainzService
    {
        public FakeDataService()
        {
        }

        public Task<WeatherForecast[]> GetWeatherForecasts()
        {
            var rand = new Random(50);
            var result = new WeatherForecast[]
            {
                new WeatherForecast
                {
                    Date = DateTime.UtcNow - TimeSpan.FromSeconds(10),
                    Summary = "Gainzy",
                    TemperatureC = rand.Next(),
                },
                new WeatherForecast
                {
                    Date = DateTime.UtcNow - TimeSpan.FromSeconds(20),
                    Summary = "Leafy",
                    TemperatureC = rand.Next(),
                },
                new WeatherForecast
                {
                    Date = DateTime.UtcNow - TimeSpan.FromSeconds(30),
                    Summary = "Snowy",
                    TemperatureC = rand.Next(),
                },
            };

            return Task.FromResult(result);
        }

        public Task<IEnumerable<Profile>> GetProfiles()
        {
            var rand = new Random(50);
            var result = new Profile[]
            {
                new Profile
                {
                    Name = "Peter Gray",
                    DateOfBirth = new DateTime(1995, 5, 15),
                    Aim = "To get the gainz",
                    Height = 180,
                },
                new Profile
                {
                    Name = "Patryk Szczerbinski",
                    DateOfBirth = new DateTime(1993, 11, 14),
                    Aim = "To cut all the gainz",
                    Height = 171,
                },
                new Profile
                {
                    Name = "Michael Sansoni",
                    DateOfBirth = new DateTime(1993, 2, 28),
                    Aim = "To get no gainz",
                    Height = 197
                },
            };

            return Task.FromResult(result.AsEnumerable());
        }
    }
}
