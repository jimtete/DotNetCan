using System.Text.Json;
using Deserializer.Models;

var opt = new JsonSerializerOptions()
{
    PropertyNameCaseInsensitive = true
};

Directory.SetCurrentDirectory("/home/ADDC/jimtete/GitHub/DotNetCan/Deserializer/Deserializer/");

string fileName = "person.json";

string jsonString = File.ReadAllText(fileName);

Person? person = JsonSerializer.Deserialize<Person>(jsonString,opt);

Console.WriteLine($"The first name is: {person!.LastName}");