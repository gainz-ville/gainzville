using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gainzville.Database
{
    public partial class ExerciseReading
    {
        [Key]
        public Guid ExerciseReadingId { get; set; }
        public Guid ProfileId { get; set; }
        public Guid ExerciseTypeId { get; set; }
        public DateTime DateOfReading { get; set; }
        public float Mass { get; set; }
        public int Reps { get; set; }

        [ForeignKey(nameof(ExerciseTypeId))]
        [InverseProperty("ExerciseReading")]
        public virtual ExerciseType ExerciseType { get; set; }
        [ForeignKey(nameof(ProfileId))]
        [InverseProperty("ExerciseReading")]
        public virtual Profile Profile { get; set; }
    }
}
