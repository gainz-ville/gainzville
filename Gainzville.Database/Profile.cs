using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gainzville.Database
{
    public partial class Profile
    {
        public Profile()
        {
            ExerciseReading = new HashSet<ExerciseReading>();
        }

        [Key]
        public Guid ProfileId { get; set; }
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public float Height { get; set; }
        public string Aim { get; set; }

        [InverseProperty("Profile")]
        public virtual ICollection<ExerciseReading> ExerciseReading { get; set; }
    }
}
