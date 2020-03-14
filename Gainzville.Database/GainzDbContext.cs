using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Gainzville.Database
{
    public partial class GainzDbContext : DbContext
    {
        public GainzDbContext()
        {
        }

        public GainzDbContext(DbContextOptions<GainzDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ExerciseReading> ExerciseReading { get; set; }
        public virtual DbSet<ExerciseType> ExerciseType { get; set; }
        public virtual DbSet<Profile> Profile { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExerciseReading>(entity =>
            {
                entity.Property(e => e.ExerciseReadingId).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.ExerciseType)
                    .WithMany(p => p.ExerciseReading)
                    .HasForeignKey(d => d.ExerciseTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExerciseReading_ExerciseType");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.ExerciseReading)
                    .HasForeignKey(d => d.ProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExerciseReading_Profile");
            });

            modelBuilder.Entity<ExerciseType>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("AK_ExerciseTypeName")
                    .IsUnique();

                entity.Property(e => e.ExerciseTypeId).HasDefaultValueSql("(newsequentialid())");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.Property(e => e.ProfileId).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
