using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gainzville.Database
{
    public partial class ExerciseType
    {
        public ExerciseType()
        {
            ExerciseReading = new HashSet<ExerciseReading>();
        }

        [Key]
        public Guid ExerciseTypeId { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [InverseProperty("ExerciseType")]
        public virtual ICollection<ExerciseReading> ExerciseReading { get; set; }
    }
}
