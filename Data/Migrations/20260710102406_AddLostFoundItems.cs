using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampusLink.Migrations
{
    /// <inheritdoc />
    public partial class AddLostFoundItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LostFoundItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Category = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Location = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    DatePosted = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PostedByUserId = table.Column<string>(type: "TEXT", nullable: false),
                    PostedByName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    ContactInfo = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LostFoundItems", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LostFoundItems");
        }
    }
}
