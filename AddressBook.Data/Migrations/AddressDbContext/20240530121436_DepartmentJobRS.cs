using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AddressBook.Data.Migrations.AddressDbContext
{
    /// <inheritdoc />
    public partial class DepartmentJobRS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_JobId",
                table: "Departments",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Jobs_JobId",
                table: "Departments",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Jobs_JobId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_JobId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "Departments");
        }
    }
}
