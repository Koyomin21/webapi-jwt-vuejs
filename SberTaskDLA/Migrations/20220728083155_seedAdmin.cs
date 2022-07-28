using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SberTaskDLA.Migrations
{
    public partial class seedAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c7b013f0-5201-4317-abd8-c211f91b7330", "2", "User", "USER" },
                    { "fab4fac1-c546-41de-aebc-a14da6895711", "1", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bb3dc917-e0f7-45a5-badb-575fc2a300d7", 0, "06263a66-ecdf-4209-a693-a9f393911edc", "anuar@mail.ru", false, "Anuar", "Farkhatuly", false, null, "Borangaziyev", null, null, "AQAAAAEAACcQAAAAEEzonM6+z1WSE05eF4NWrIOG3QSoVntDwAVSn+LJLXmXHvYKIDmUtPP/dE/RJ+bLNA==", "87775554466", false, "340f4413-ee8e-464e-ab40-2104fac3b1d7", false, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fab4fac1-c546-41de-aebc-a14da6895711", "bb3dc917-e0f7-45a5-badb-575fc2a300d7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7b013f0-5201-4317-abd8-c211f91b7330");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fab4fac1-c546-41de-aebc-a14da6895711", "bb3dc917-e0f7-45a5-badb-575fc2a300d7" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fab4fac1-c546-41de-aebc-a14da6895711");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bb3dc917-e0f7-45a5-badb-575fc2a300d7");
        }
    }
}
