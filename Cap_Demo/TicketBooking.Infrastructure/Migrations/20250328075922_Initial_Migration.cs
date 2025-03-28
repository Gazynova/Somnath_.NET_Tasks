using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TicketBooking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Venue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvailableSeats = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EventCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_events_EventCategories_EventCategoryId",
                        column: x => x.EventCategoryId,
                        principalTable: "EventCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EventCategories",
                columns: new[] { "Id", "EventCategoryName" },
                values: new object[,]
                {
                    { 1, "Music" },
                    { 2, "Conference" },
                    { 3, "Sports" }
                });

            migrationBuilder.InsertData(
                table: "events",
                columns: new[] { "Id", "AvailableSeats", "Date", "Description", "EventCategoryId", "Name", "Price", "Venue" },
                values: new object[,]
                {
                    { 1, 1000, new DateTime(2021, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amit Mishra Live Concert", 1, "Amit Mishra", 500m, "Mumbai" },
                    { 2, 1000, new DateTime(2021, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arijit Singh Live Concert", 1, "Arijit Singh", 500m, "Mumbai" },
                    { 3, 500, new DateTime(2025, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nvidia GTC Conference", 2, "Nvidia  GTC", 100m, "Mumbai" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_events_EventCategoryId",
                table: "events",
                column: "EventCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "events");

            migrationBuilder.DropTable(
                name: "EventCategories");
        }
    }
}
