using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AddressBook.Data.Migrations.AddressDbContext
{
    /// <inheritdoc />
    public partial class PersonDepartmentRS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_DepartmentId",
                table: "Persons",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Departments_DepartmentId",
                table: "Persons",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Departments_DepartmentId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_DepartmentId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Persons");
        }
    }
}
