using Gainzville.Shared;
using System.Collections.Generic;

namespace Gainzville.Server.Services
{
    public interface IGainzService
    {
        public IEnumerable<Profile> GetProfiles();

        public Profile PostProfile(Profile profile);
    }
}