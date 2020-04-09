using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gainzville.Database.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExerciseType",
                columns: table => new
                {
                    ExerciseTypeId = table.Column<Guid>(nullable: false, defaultValueSql: "(newsequentialid())"),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseType", x => x.ExerciseTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    ProfileId = table.Column<Guid>(nullable: false, defaultValueSql: "(newsequentialid())"),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getutcdate())"),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Height = table.Column<float>(nullable: false),
                    Aim = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.ProfileId);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseReading",
                columns: table => new
                {
                    ExerciseReadingId = table.Column<Guid>(nullable: false, defaultValueSql: "(newsequentialid())"),
                    ProfileId = table.Column<Guid>(nullable: false),
                    ExerciseTypeId = table.Column<Guid>(nullable: false),
                    DateOfReading = table.Column<DateTime>(nullable: false),
                    Mass = table.Column<float>(nullable: false),
                    Reps = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseReading", x => x.ExerciseReadingId);
                    table.ForeignKey(
                        name: "FK_ExerciseReading_ExerciseType",
                        column: x => x.ExerciseTypeId,
                        principalTable: "ExerciseType",
                        principalColumn: "ExerciseTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExerciseReading_Profile",
                        column: x => x.ProfileId,
                        principalTable: "Profile",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseReading_ExerciseTypeId",
                table: "ExerciseReading",
                column: "ExerciseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseReading_ProfileId",
                table: "ExerciseReading",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "AK_ExerciseTypeName",
                table: "ExerciseType",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseReading");

            migrationBuilder.DropTable(
                name: "ExerciseType");

            migrationBuilder.DropTable(
                name: "Profile");
        }
    }
}
