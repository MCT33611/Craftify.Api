using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Craftify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AWSRDS_addNotification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f418cbdb-a2a5-4ef1-87db-0ec22fa4cdf5"));

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Blocked", "City", "Email", "EmailConfirmed", "FirstName", "JoinDate", "LastName", "PasswordHash", "PostalCode", "ProfilePicture", "Role", "State", "StreetAddress", "UpdatedDate" },
                values: new object[] { new Guid("215353d3-43c3-49d8-8ec0-6b41e32b94dd"), false, null, "craftify.onion0.122@gmail.com", true, "ADMIN", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "pass@FY04", null, null, "ADMIN", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("215353d3-43c3-49d8-8ec0-6b41e32b94dd"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Blocked", "City", "Email", "EmailConfirmed", "FirstName", "JoinDate", "LastName", "PasswordHash", "PostalCode", "ProfilePicture", "Role", "State", "StreetAddress", "UpdatedDate" },
                values: new object[] { new Guid("f418cbdb-a2a5-4ef1-87db-0ec22fa4cdf5"), false, null, "craftify.onion0.122@gmail.com", true, "ADMIN", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "pass@FY04", null, null, "ADMIN", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
