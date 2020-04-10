﻿// <auto-generated />
using System;
using Gainzville.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gainzville.Database.Migrations
{
    [DbContext(typeof(GainzDbContext))]
    [Migration("20200401230109_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Gainzville.Database.ExerciseReading", b =>
                {
                    b.Property<Guid>("ExerciseReadingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newsequentialid())");

                    b.Property<DateTime>("DateOfReading")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ExerciseTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Mass")
                        .HasColumnType("real");

                    b.Property<Guid>("ProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Reps")
                        .HasColumnType("int");

                    b.HasKey("ExerciseReadingId");

                    b.HasIndex("ExerciseTypeId");

                    b.HasIndex("ProfileId");

                    b.ToTable("ExerciseReading");
                });

            modelBuilder.Entity("Gainzville.Database.ExerciseType", b =>
                {
                    b.Property<Guid>("ExerciseTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newsequentialid())");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("ExerciseTypeId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("AK_ExerciseTypeName");

                    b.ToTable("ExerciseType");
                });

            modelBuilder.Entity("Gainzville.Database.Profile", b =>
                {
                    b.Property<Guid>("ProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newsequentialid())");

                    b.Property<string>("Aim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(getutcdate())");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<float>("Height")
                        .HasColumnType("real");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("ProfileId");

                    b.ToTable("Profile");
                });

            modelBuilder.Entity("Gainzville.Database.ExerciseReading", b =>
                {
                    b.HasOne("Gainzville.Database.ExerciseType", "ExerciseType")
                        .WithMany("ExerciseReading")
                        .HasForeignKey("ExerciseTypeId")
                        .HasConstraintName("FK_ExerciseReading_ExerciseType")
                        .IsRequired();

                    b.HasOne("Gainzville.Database.Profile", "Profile")
                        .WithMany("ExerciseReading")
                        .HasForeignKey("ProfileId")
                        .HasConstraintName("FK_ExerciseReading_Profile")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}