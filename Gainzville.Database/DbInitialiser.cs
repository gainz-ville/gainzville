
namespace Gainzville.Database
{
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    /// <summary>
    /// A class to initialise data in the database.
    /// </summary>
    public static class DbInitialiser
    {
        public static void Initialise(GainzDbContext context, IConfiguration configuration)
        {
            context.Database.EnsureCreated();

            if (context.Profile.Any())
            {
                return;
            }

            using (var transaction = context.Database.BeginTransaction())
            {
                context.Profile.AddRange(
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
                        DateOfBirth = new DateTime(1980, 1, 1),
                        Aim = "To get no gainz",
                        Height = 240
                    });

                context.SaveChanges();

                context.ExerciseType.AddRange(
                    new ExerciseType
                    {
                        Name = "Flat Bench",
                    },
                    new ExerciseType
                    {
                        Name = "Deadlift",
                    },
                    new ExerciseType
                    {
                        Name = "Squat",
                    },
                    new ExerciseType
                    {
                        Name = "OH Press",
                    },
                    new ExerciseType
                    {
                        Name = "Weighted Pull Up",
                    });

                context.SaveChanges();

                transaction.Commit();
            }
        }
    }
}