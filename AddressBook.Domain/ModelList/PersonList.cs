using AddressBook.Domain.Models;
using System.Text.Json;

namespace AddressBook.Domain.ModelList
{
    public static class PersonList
    {
        public static List<Person> Persons { get; set; } = JsonSerializer.Deserialize<List<Person>>(File.ReadAllText(@"..\AddressBook.Data\SeedingData\Persons.json"));



    }
}


