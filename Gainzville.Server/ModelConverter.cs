using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gainzville.Shared;

namespace Gainzville.Server
{
    public static class ModelConverter
    {
        public static Profile ToModel(this Database.Profile profile)
        {
            return new Profile
            {
                Name = profile.Name,
                Aim = profile.Aim,
                CreatedDate = profile.CreatedDate,
                DateOfBirth = profile.DateOfBirth,
                Height = profile.Height,
                Id = profile.Id,
            };
        }
    }
}
