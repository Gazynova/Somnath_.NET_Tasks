using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TicketBoking.Identity.Migrations
{
    /// <inheritdoc />
    public partial class RoleConfigurationmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "41776008-6086-1fbf-b923-2879a6680b9a", null, "Administrator", null },
                    { "41886008-6086-1fbf-b923-2879a6680b9a", null, "User", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "41776062-6086-1fbf-b923-2879a6680b9a", 0, "8f3633e6-7249-4165-ae91-54b689dca846", "admin@gmail.com", true, false, null, "Admin System", null, null, "AQAAAAIAAYagAAAAEJdsINJUU8h7kglRSddAurURYd4vYNhTnGrLjm3WOP7a5Pe4Rz450Kd0bQ9iJAa69w==", null, false, "Admin", "7fc5ad3b-6f11-40b3-9feb-b1dc19124db9", false, "admin@gmail.com" },
                    { "41776062-6086-1fcf-b923-2879a6680b9a", 0, "c7e350e4-0c49-4785-a875-7cd370a79dad", "vani@gmail.com", true, false, null, "Vani Shree", null, null, "AQAAAAIAAYagAAAAECf6UV9AwtPCahlfuac1oazDZnVo0VO2vnx4JzuO7RHM1EogQnaL4s8mxnWeSayD3A==", null, false, "User", "ddfb28d3-7f5a-4de2-b2c8-56a5b2b88bc4", false, "vani@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "41776008-6086-1fbf-b923-2879a6680b9a", "41776062-6086-1fbf-b923-2879a6680b9a" },
                    { "41886008-6086-1fbf-b923-2879a6680b9a", "41776062-6086-1fcf-b923-2879a6680b9a" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "41776008-6086-1fbf-b923-2879a6680b9a", "41776062-6086-1fbf-b923-2879a6680b9a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "41886008-6086-1fbf-b923-2879a6680b9a", "41776062-6086-1fcf-b923-2879a6680b9a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41776008-6086-1fbf-b923-2879a6680b9a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41886008-6086-1fbf-b923-2879a6680b9a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41776062-6086-1fbf-b923-2879a6680b9a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41776062-6086-1fcf-b923-2879a6680b9a");
        }
    }
}
