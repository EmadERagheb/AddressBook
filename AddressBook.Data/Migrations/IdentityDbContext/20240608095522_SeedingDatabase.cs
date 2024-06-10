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
                    { "9d5489cc-09aa-46b1-a580-f18ec0084946", 0, "331a7018-6de6-49bf-9c5f-a98ba3372985", "Sameh Hussein", "shussein@tamweely.com.eg", true, false, null, "SHUSSEIN@TAMWEELY.COM.EG", "SUSHUSSEIN@TAMWEELY.COM.EG", "AQAAAAIAAYagAAAAEGj7i3c40nxVNeh2EPze8OcZqjSVGt5b/dcLXhXvYhqfSUxYqMp6tcrvm3WHOEr8lQ==", null, false, "1b879ebb-fef6-49c8-9824-b0ce47f45420", false, "shussein@tamweely.com.eg" },
                    { "9d5489cc-09aa-46b1-a580-f18ec1235874", 0, "2aa96d13-92e2-4324-ac14-c6ef5933d775", "Admin Sameh Hussein", "admin.shussein@tamweely.com.eg", true, false, null, "ADMIN.SHUSSEIN@TAMWEELY.COM.EG", "ADMIN.SUSHUSSEIN@TAMWEELY.COM.EG", "AQAAAAIAAYagAAAAEHer80KtD4LNpRNzae5MAqUnXGOztkTBmjlMQPfcVdJSb9HZOLUyCFWET5XqXp3mKg==", null, false, "79394dbc-c90d-4a51-849a-59f69fea60cb", false, "admin.shussein@tamweely.com.eg" },
                    { "c0bsdf33-57b5-4b18-2303-d24bda5e8e5a", 0, "11f76e0e-99fa-47c0-a04f-ab2b071acf36", "User Emad", "emadeidragheb@gmail.com", true, false, null, "EMADEIDRAGHEB@GMAIL.COM", "EMADEIDRAGHEB@GMAIL.COM", "AQAAAAIAAYagAAAAEO2bDQiTTHUt45AC0iz4ti/NifQbcRS9pkXnjV89gwL6hmEV0aau/DyBt3hPw0ASaQ==", null, false, "80695ae4-eec5-4833-9bb4-0a0580e0e4a1", false, "emadeidragheb@gmail.com" },
                    { "c0bsdf33-57b5-4b18-8878-d24bda5e8e5a", 0, "ecc138d0-1245-4ce7-810c-030c2de56e19", "Admin Emad", "emaderagheb@gmail.com", true, false, null, "EMADERAGHEB@GMAIL.COM", "EMADERAGHEB@GMAIL.COM", "AQAAAAIAAYagAAAAENr52txLkxrvrzTcnU53A97FFI2w4/xEybKC8GHc4qoPuWVp9Ns3Im8j1jK4VtIB9w==", null, false, "2378da26-1be4-45e3-9b0a-ce89fda641bc", false, "emaderagheb@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "54364591-ad1f-42f9-ba53-2a25f8fb4dcf", "9d5489cc-09aa-46b1-a580-f18ec0084946" },
                    { "ce78aeb6-7cd4-47db-a96a-598bef56a1d9", "9d5489cc-09aa-46b1-a580-f18ec1235874" },
                    { "54364591-ad1f-42f9-ba53-2a25f8fb4dcf", "c0bsdf33-57b5-4b18-2303-d24bda5e8e5a" },
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
                keyValues: new object[] { "ce78aeb6-7cd4-47db-a96a-598bef56a1d9", "9d5489cc-09aa-46b1-a580-f18ec1235874" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "54364591-ad1f-42f9-ba53-2a25f8fb4dcf", "c0bsdf33-57b5-4b18-2303-d24bda5e8e5a" });

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
                keyValue: "9d5489cc-09aa-46b1-a580-f18ec1235874");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0bsdf33-57b5-4b18-2303-d24bda5e8e5a");

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
