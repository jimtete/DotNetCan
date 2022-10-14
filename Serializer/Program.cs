using System.Text.Json;
using Serializer.Models;

var person = new Person()
{
    Id = 1,
    FirstName = null,
    LastName = "Tetepoulos",
    Age = 30,
    IsAlive = true,
    Address = new Address
    {
        StreetName = "Miltiadou 2",
        City = "Polichnis",
        ZipCode = "56532"
    },
    Phones = new List<Phone>
    {
        new Phone{ PhoneType = "Home",PhoneNumber ="2310555666"},
        new Phone{ PhoneType = "Mobile", PhoneNumber = "6948336666"}
    },
    EyeColor = "Blue"
};

var opt = new JsonSerializerOptions
{
    WriteIndented = true,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
};

string JsonString = JsonSerializer.Serialize(person, opt);
string FileName = "/home/ADDC/jimtete/RiderProjects/Serializer/person.json";

File.WriteAllText(FileName,JsonString);

Console.WriteLine(File.ReadAllText(FileName));