using System.Text.Json;
using SerializerV2.Helpers;
using SerializerV2.Models;
Directory.SetCurrentDirectory("/home/ADDC/jimtete/GitHub/DotNetCan/SerializerV2/SerializerV2/");


var person = new Person
{
    Id = 1,
    FirstName = "Sean",
    LastName = "Connery",
    Age = 90,
    IsAlive = false,
    Address = new Address
    {
        StreetName = "Foinikos 14",
        City = "Thermi",
        ZipCode = "57001"
    },
    Phones = new List<Phone>()
    {
        new Phone{ PhoneType = "Home", PhoneNumber = "2310635450"},
        new Phone{ PhoneType = "Mobile", PhoneNumber = "6948487721"}
    }
};

var opt = new JsonSerializerOptions
{
    WriteIndented = true,
    PropertyNamingPolicy = new LowerCaseNamingPolicy()
};

string jsonString = JsonSerializer.Serialize<Person>(person, opt);
string fileName = "person.json";

File.WriteAllText(fileName, jsonString);

Console.WriteLine(File.ReadAllText(fileName));