using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AddressBook.Data.Migrations.IdentityDbContext
{
    /// <inheritdoc />
    public partial class SeedingDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireTime",
                table: "AspNetUserTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "54364591-ad1f-42f9-ba53-2a25f8fb4dcf", null, "User", "USER" },
                    { "ce78aeb6-7cd4-47db-a96a-598bef56a1d9", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "9d5489cc-09aa-46b1-a580-f18ec0084946", 0, "57639d21-9fae-4427-ba94-dbc84acacc0a", "Sameh Hussein", "shussein@tamweely.com.eg", true, false, null, "SHUSSEIN@TAMWEELY.COM.EG", "SUSHUSSEIN@TAMWEELY.COM.EG", "AQAAAAIAAYagAAAAEO5bPvjb1HiQm/pIsP78kmDzA7s+7jNsTiGN6Cw8SRlAzyKrC0w3/ckfoHihLaRWvQ==", null, false, "8b431d85-a64e-4cbc-9c9e-5d6fa925b7ad", false, "shussein@tamweely.com.eg" },
                    { "c0bsdf33-57b5-4b18-8878-d24bda5e8e5a", 0, "e7eba68a-8208-400b-a990-f2b971b88f7a", "Emad", "emaderagheb@gmail.com", true, false, null, "EMADERAGHEB@GMAIL.COM", "EMADERAGHEB@GMAIL.COM", "AQAAAAIAAYagAAAAEGx6g4EJna0wsb3CwWdxG3RL+n/ko7iKpOEm5t/sKfiUWiaZJMfgXI7MaQfM7zw7hA==", null, false, "fa6beddb-9f52-421d-91c3-1d212dbaab25", false, "emaderagheb@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "54364591-ad1f-42f9-ba53-2a25f8fb4dcf", "9d5489cc-09aa-46b1-a580-f18ec0084946" },
                    { "ce78aeb6-7cd4-47db-a96a-598bef56a1d9", "c0bsdf33-57b5-4b18-8878-d24bda5e8e5a" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "54364591-ad1f-42f9-ba53-2a25f8fb4dcf", "9d5489cc-09aa-46b1-a580-f18ec0084946" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ce78aeb6-7cd4-47db-a96a-598bef56a1d9", "c0bsdf33-57b5-4b18-8878-d24bda5e8e5a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54364591-ad1f-42f9-ba53-2a25f8fb4dcf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce78aeb6-7cd4-47db-a96a-598bef56a1d9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9d5489cc-09aa-46b1-a580-f18ec0084946");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0bsdf33-57b5-4b18-8878-d24bda5e8e5a");

            migrationBuilder.DropColumn(
                name: "ExpireTime",
                table: "AspNetUserTokens");
        }
    }
}
