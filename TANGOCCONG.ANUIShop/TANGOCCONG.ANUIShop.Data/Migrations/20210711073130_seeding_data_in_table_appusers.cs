using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TANGOCCONG.ANUIShop.Data.Migrations
{
    public partial class seeding_data_in_table_appusers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("61e36f04-67f5-4d3b-a5a4-6f85c4be086d"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("61e36f04-67f5-4d3b-a5a4-6f85c4be086d"), new Guid("5e3d0b60-cda3-4160-814b-0de10f058ece") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("5e3d0b60-cda3-4160-814b-0de10f058ece"));

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("42c471c2-5c36-4f3c-a2d6-dd028be7fa85"), "67ab4660-ffed-4211-af15-87bc9d9334d5", "Admintrator role", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("42c471c2-5c36-4f3c-a2d6-dd028be7fa85"), new Guid("f9da477d-8ecb-408b-a1cc-ff1c68631d7a") });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "ImagePath", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TimeCreated", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("f9da477d-8ecb-408b-a1cc-ff1c68631d7a"), 0, "216b8074-8d28-4e20-9e20-c63f026328d9", new DateTime(1997, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "tacong56@gmail.com", true, "Ta", null, "Cong", false, null, "tacong56@gmail.com", "admin", "AQAAAAEAACcQAAAAEIAqtnLMgwKSpjb7ohd1+M1F3KSY0CHu8zWy2CN+Ay8mi9YvF5JcHUb8y1/rhkg8cw==", null, false, "", new DateTime(2021, 7, 11, 14, 31, 28, 845, DateTimeKind.Local).AddTicks(2973), false, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("42c471c2-5c36-4f3c-a2d6-dd028be7fa85"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("42c471c2-5c36-4f3c-a2d6-dd028be7fa85"), new Guid("f9da477d-8ecb-408b-a1cc-ff1c68631d7a") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("f9da477d-8ecb-408b-a1cc-ff1c68631d7a"));

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("61e36f04-67f5-4d3b-a5a4-6f85c4be086d"), "6591e5b7-b26f-4bee-a232-2aeb9df2a042", "Admintrator role", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("61e36f04-67f5-4d3b-a5a4-6f85c4be086d"), new Guid("5e3d0b60-cda3-4160-814b-0de10f058ece") });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "ImagePath", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TimeCreated", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("5e3d0b60-cda3-4160-814b-0de10f058ece"), 0, "86cc1af0-c0c4-4ac7-afec-44319511dcc8", new DateTime(1997, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "tacong56@gmail.com", true, "Ta", null, "Cong", false, null, "tacong56@gmail.com", "admin", "AQAAAAEAACcQAAAAEGPEyk/Co6v6OJwEHGUFrNC66e0YEMJfFRmt3AD/Nxw7mU9GQuBqzG6JaHQG/3ap2g==", null, false, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "admin" });
        }
    }
}
