using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AddressBook.Data.Migrations.AddressDbContext
{
    /// <inheritdoc />
    public partial class SeedingTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address_Street",
                table: "Persons",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "Address_State",
                table: "Persons",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "Address_PostalCode",
                table: "Persons",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "Address_City",
                table: "Persons",
                newName: "City");

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Engineer", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Layer", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Teacher", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedDate", "JobId", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "General Medicine", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Cardiology", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Neurology", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Surgery", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pediatrics", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Software Engineering", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Civil Engineering", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Mechanical Engineering", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Electrical Engineering", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Chemical Engineering", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Corporate Law", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Criminal Law", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Family Law", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Intellectual Property Law", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Tax Law", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Mathematics Department", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Science Department", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "History Department", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "English Department", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Physical Education Department", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "BirthDate", "City", "CreatedDate", "DepartmentId", "Email", "FullName", "ImageUrl", "Mobile", "PostalCode", "State", "Street", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1985, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anytown", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "john.doe@example.com", "John Doe", "images/m1.jpg", "1234567890", "12345", "Anystate", "123 Main St", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1990, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Othertown", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Jane.Smith@example.com", "Jane Smith", "images/w1.jpg", "0987654321", "67890", "Otherstate", "456 Oak St", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1982, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sometown", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "alice.johnson@example.com", "Alice Johnson", "images/7abe9bd1-76aa-4d8e-84b0-c63d9ad60750.jpg", "1122334455", "11223", "Somestate", "789 Pine St", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(1978, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thistown", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "bob.brown@example.com", "Bob Brown", "images/m3.jpg", "2233445566", "33445", "Thistate", "101 Maple St", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(1995, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anycity", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "charlie.davis@example.com", "Charlie Davis", "images/w3.jpg", "3344556677", "55667", "Anystate", "202 Birch St", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(1988, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thiscity", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "images/w12.jpg", "Diana Prince", "images/w4.jpg", "4455667788", "44556", "Thisstate", "303 Elm St", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(1992, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thatcity", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "evan.white@example.com", "Evan White", "images/pexels-kampus-7551590.jpg", "5566778899", "55678", "Thatstate", "404 Cedar St", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(1975, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thistown", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "Fiona.Green@example.com", "Fiona Green", "images/w12.jpg", "6677889900", "66789", "Thistate", "505 Ash St", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(1980, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thiscity", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, "george.harris@example.com", "George Harris", "images/m5.jpg", "7788990011", "77890", "Thistate", "606 Pine St", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(1997, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anycity", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "hannah.clark@example.com", "Hannah Clark", "images/w5.jpg", "8899001122", "88901", "Anystate", "707 Birch St", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, new DateTime(1983, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Somecity", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, "irene.black@example.com", "Irene Black", "images/w6.jpg", "9900112233", "99001", "Somestate", "808 Walnut St", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, new DateTime(1987, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thatcity", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, "jack.white@example.com", "Jack White", "images/m6.jpg", "1122334455", "11223", "Thatstate", "909 Chestnut St", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, new DateTime(1992, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thistown", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, "kelly.brown@example.com", "Kelly Brown", "images/w7.jpg", "2233445566", "33445", "Thistate", "1010 Willow St", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, new DateTime(1995, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thatcity", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "liam.blue@example.com", "Liam Blue", "images/w8.jpg", "3344556677", "44556", "Thatstate", "1111 Fir St", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, new DateTime(1989, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thistown", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "mia.green@example.com", "Mia Green", "images/c08308c3-4357-46a8-b9ad-6d892790c6f3.jpg", "4455667788", "55667", "Thistate", "1212 Cedar St", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, new DateTime(1984, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Somecity", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "noah.red@example.com", "Noah Red", "images/w9.jpg", "5566778899", "66778", "Somestate", "1313 Aspen St", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, new DateTime(1991, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thistown", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "olivia.purple@example.com", "Olivia Purple", "images/w10.jpg", "6677889900", "77889", "Thistate", "1414 Elm St", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, new DateTime(1980, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thistown", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, "paul.yellow@example.com", "Paul Yellow", "images/m7.jpg", "7788990011", "88990", "Thistate", "1515 Pine St", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, new DateTime(1994, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Somecity", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, "quinn.orange@example.com", "Quinn Orange", "images/w11.jpg", "8899001122", "99011", "Somestate", "1616 Birch St", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, new DateTime(1986, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anytown", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, "ruby.pink@example.com", "Ruby Pink", "images/m8.jpg", "9900112233", "12355", "Anystate", "1717 Maple St", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Persons",
                newName: "Address_Street");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Persons",
                newName: "Address_State");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "Persons",
                newName: "Address_PostalCode");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Persons",
                newName: "Address_City");
        }
    }
}
