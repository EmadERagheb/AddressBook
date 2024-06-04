using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AddressBook.Data.Migrations.IdentityDbContext
{
    /// <inheritdoc />
    public partial class AddAnotherApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9d5489cc-09aa-46b1-a580-f18ec0084946",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9352e53-6b7e-4e05-92e0-3202f8607aea", "AQAAAAIAAYagAAAAELr5G6UxHJvOZ1f+Rc3kmCFTY1YB5/t5wfKlmAaZfj8WxbqJrqpFEV8ZqtK75rpHxw==", "e1d922cd-b103-40aa-9417-6137fdeea74a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0bsdf33-57b5-4b18-8878-d24bda5e8e5a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "63c0038c-3525-44fe-a3f8-afdf098a2895", "AQAAAAIAAYagAAAAEJGfyGR1szAznzQNoxS4Wt0l5OllhhaU2KhLab0YS6if9NcpTYtgirSNBh1tbpxzUQ==", "62219ff0-f4d8-455f-9e42-29199f7cac81" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9d5489cc-09aa-46b1-a580-f18ec1235874", 0, "b7867ab5-f041-4159-adfa-61f920f8b371", "Admin Sameh Hussein", "admin.shussein@tamweely.com.eg", true, false, null, "ADMIN.SHUSSEIN@TAMWEELY.COM.EG", "ADMIN.SUSHUSSEIN@TAMWEELY.COM.EG", "AQAAAAIAAYagAAAAEKIJIV9tU9X6Zf2yF0m7uGD5cgjEzIZR+AGxUObYAClgpXHLcSN5t0qtJ5pNjDdTgA==", null, false, "41a0dacf-d478-4af3-a7f3-c057c6bc00bc", false, "admin.shussein@tamweely.com.eg" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ce78aeb6-7cd4-47db-a96a-598bef56a1d9", "9d5489cc-09aa-46b1-a580-f18ec1235874" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ce78aeb6-7cd4-47db-a96a-598bef56a1d9", "9d5489cc-09aa-46b1-a580-f18ec1235874" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9d5489cc-09aa-46b1-a580-f18ec1235874");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9d5489cc-09aa-46b1-a580-f18ec0084946",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "57639d21-9fae-4427-ba94-dbc84acacc0a", "AQAAAAIAAYagAAAAEO5bPvjb1HiQm/pIsP78kmDzA7s+7jNsTiGN6Cw8SRlAzyKrC0w3/ckfoHihLaRWvQ==", "8b431d85-a64e-4cbc-9c9e-5d6fa925b7ad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0bsdf33-57b5-4b18-8878-d24bda5e8e5a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e7eba68a-8208-400b-a990-f2b971b88f7a", "AQAAAAIAAYagAAAAEGx6g4EJna0wsb3CwWdxG3RL+n/ko7iKpOEm5t/sKfiUWiaZJMfgXI7MaQfM7zw7hA==", "fa6beddb-9f52-421d-91c3-1d212dbaab25" });
        }
    }
}
