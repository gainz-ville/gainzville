using Gainzville.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gainzville.Server.Services
{
    public class FakeDataService : IGainzService
    {
        private List<Profile> profiles = new List<Profile>
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

        public FakeDataService()
        {
        }

        public WeatherForecast[] GetWeatherForecasts()
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

            return result;
        }

        public IEnumerable<Profile> GetProfiles()
        {
            return this.profiles.AsEnumerable();
        }

        public Profile PostProfile(Profile profile)
        {
            if (profile == null)
            {
                throw new ArgumentNullException("Profile cannot be null");
            }

            this.profiles.Add(profile);

            return profile;
        }
    }
}
