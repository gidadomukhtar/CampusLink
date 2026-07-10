using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampusLink.Migrations
{
    /// <inheritdoc />
    public partial class AddUniversityToStudentProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "University",
                table: "StudentProfiles",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "University",
                table: "StudentProfiles");
        }
    }
}
