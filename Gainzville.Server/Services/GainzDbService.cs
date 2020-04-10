using System;
using System.Collections.Generic;
using System.Linq;
using Gainzville.Database;

namespace Gainzville.Server.Services
{
    public class GainzDbService : IGainzService
    {
        private GainzDbContext repository;

        public GainzDbService(GainzDbContext context)
        {
            this.repository = context ??
                throw new ArgumentNullException("Context cannot be null.");
        }

        public IEnumerable<Shared.Profile> GetProfiles()
        {
            return this.repository.Profile
                .ToList()
                .Select(x => x.ToModel());
        }

        public Shared.Profile PostProfile(Shared.Profile profile)
        {
            var newProfile = new Profile
            {
                Name = profile.Name,
                DateOfBirth = profile.DateOfBirth,
                Aim = profile.Aim,
                Height = profile.Height,
                CreatedDate = profile.CreatedDate
            };

            var entry = this.repository.Profile.Add(newProfile);
            this.repository.SaveChanges();

            return entry.Entity.ToModel();
        }
    }
}
