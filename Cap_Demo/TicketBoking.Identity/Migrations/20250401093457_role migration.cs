using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketBoking.Identity.Migrations
{
    /// <inheritdoc />
    public partial class rolemigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41776008-6086-1fbf-b923-2879a6680b9a",
                column: "NormalizedName",
                value: "ADMINISTRATOR");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41886008-6086-1fbf-b923-2879a6680b9a",
                column: "NormalizedName",
                value: "USER");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41776062-6086-1fbf-b923-2879a6680b9a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f8dfa29-f787-45a6-bb23-43633ed2d545", "AQAAAAIAAYagAAAAEMPWowdRBayK9wMX6WNaxTP5KLHpyGMZ/xyjhVEAeRh2nLakZw+RriDVSz/q5d05RA==", "76a2a6af-f9cd-48b1-8ea5-592d40323729" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41776062-6086-1fcf-b923-2879a6680b9a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "060a4a86-c8b5-4c64-9bdb-31404357a456", "AQAAAAIAAYagAAAAEESv8g8wmtojqzWh+JP8/QHpfFmUohdxoZn+USG0EIuFRvZ6N7WizZmReI2546cYJA==", "a636ff11-ba43-4f91-90c4-edb15ccf85e8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41776008-6086-1fbf-b923-2879a6680b9a",
                column: "NormalizedName",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41886008-6086-1fbf-b923-2879a6680b9a",
                column: "NormalizedName",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41776062-6086-1fbf-b923-2879a6680b9a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Role", "SecurityStamp" },
                values: new object[] { "8f3633e6-7249-4165-ae91-54b689dca846", "AQAAAAIAAYagAAAAEJdsINJUU8h7kglRSddAurURYd4vYNhTnGrLjm3WOP7a5Pe4Rz450Kd0bQ9iJAa69w==", "Admin", "7fc5ad3b-6f11-40b3-9feb-b1dc19124db9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41776062-6086-1fcf-b923-2879a6680b9a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Role", "SecurityStamp" },
                values: new object[] { "c7e350e4-0c49-4785-a875-7cd370a79dad", "AQAAAAIAAYagAAAAECf6UV9AwtPCahlfuac1oazDZnVo0VO2vnx4JzuO7RHM1EogQnaL4s8mxnWeSayD3A==", "User", "ddfb28d3-7f5a-4de2-b2c8-56a5b2b88bc4" });
        }
    }
}
