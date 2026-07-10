using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampusLink.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentProfiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Department = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Bio = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Skills = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Interests = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    GitHubLink = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    LinkedInLink = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    ContactPhone = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentProfiles", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentProfiles");
        }
    }
}
