using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AddressBook.Data.Migrations.AddressDbContext
{
    /// <inheritdoc />
    public partial class SeedingTablePersons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "BirthDate", "City", "CreatedDate", "DepartmentId", "Email", "FullName", "ImageUrl", "Mobile", "PostalCode", "State", "Street", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateOnly(1985, 5, 20), "Anytown", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "john.doe@example.com", "John Doe", "https://example.com/image1.jpg", "1234567890", "12345", "Anystate", "123 Main St", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateOnly(1990, 7, 15), "Othertown", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "jane.smith@example.com", "Jane Smith", "https://example.com/image2.jpg", "0987654321", "67890", "Otherstate", "456 Oak St", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateOnly(1982, 3, 10), "Sometown", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "alice.johnson@example.com", "Alice Johnson", "https://example.com/image3.jpg", "1122334455", "11223", "Somestate", "789 Pine St", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateOnly(1978, 11, 25), "Thistown", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "bob.brown@example.com", "Bob Brown", "https://example.com/image4.jpg", "2233445566", "33445", "Thistate", "101 Maple St", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateOnly(1995, 2, 5), "Anycity", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "charlie.davis@example.com", "Charlie Davis", "https://example.com/image5.jpg", "3344556677", "55667", "Anystate", "202 Birch St", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateOnly(1988, 12, 13), "Thiscity", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "diana.prince@example.com", "Diana Prince", "https://example.com/image6.jpg", "4455667788", "44556", "Thisstate", "303 Elm St", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateOnly(1992, 8, 21), "Thatcity", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "evan.white@example.com", "Evan White", "https://example.com/image7.jpg", "5566778899", "55678", "Thatstate", "404 Cedar St", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateOnly(1975, 4, 17), "Thistown", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "fiona.green@example.com", "Fiona Green", "https://example.com/image8.jpg", "6677889900", "66789", "Thistate", "505 Ash St", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateOnly(1980, 6, 23), "Thiscity", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "george.harris@example.com", "George Harris", "https://example.com/image9.jpg", "7788990011", "77890", "Thistate", "606 Pine St", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateOnly(1997, 9, 29), "Anycity", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "hannah.clark@example.com", "Hannah Clark", "https://example.com/image10.jpg", "8899001122", "88901", "Anystate", "707 Birch St", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, new DateOnly(1983, 11, 12), "Somecity", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "irene.black@example.com", "Irene Black", "https://example.com/image11.jpg", "9900112233", "99001", "Somestate", "808 Walnut St", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, new DateOnly(1987, 4, 8), "Thatcity", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "jack.white@example.com", "Jack White", "https://example.com/image12.jpg", "1122334455", "11223", "Thatstate", "909 Chestnut St", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, new DateOnly(1992, 1, 15), "Thistown", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "kelly.brown@example.com", "Kelly Brown", "https://example.com/image13.jpg", "2233445566", "33445", "Thistate", "1010 Willow St", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, new DateOnly(1995, 5, 20), "Thatcity", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "liam.blue@example.com", "Liam Blue", "https://example.com/image14.jpg", "3344556677", "44556", "Thatstate", "1111 Fir St", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, new DateOnly(1989, 7, 22), "Thistown", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "mia.green@example.com", "Mia Green", "https://example.com/image15.jpg", "4455667788", "55667", "Thistate", "1212 Cedar St", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, new DateOnly(1984, 9, 11), "Somecity", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "noah.red@example.com", "Noah Red", "https://example.com/image16.jpg", "5566778899", "66778", "Somestate", "1313 Aspen St", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, new DateOnly(1991, 6, 30), "Thistown", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "olivia.purple@example.com", "Olivia Purple", "https://example.com/image17.jpg", "6677889900", "77889", "Thistate", "1414 Elm St", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, new DateOnly(1980, 12, 2), "Thistown", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "paul.yellow@example.com", "Paul Yellow", "https://example.com/image18.jpg", "7788990011", "88990", "Thistate", "1515 Pine St", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, new DateOnly(1994, 3, 7), "Somecity", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "quinn.orange@example.com", "Quinn Orange", "https://example.com/image19.jpg", "8899001122", "99011", "Somestate", "1616 Birch St", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, new DateOnly(1986, 8, 18), "Anytown", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "ruby.pink@example.com", "Ruby Pink", "https://example.com/image20.jpg", "9900112233", "12355", "Anystate", "1717 Maple St", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
