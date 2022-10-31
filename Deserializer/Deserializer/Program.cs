using System.Net.Http.Json;
using System.Text.Json;
using Deserializer.Models;

var opt = new JsonSerializerOptions()
{
    PropertyNameCaseInsensitive = true
};

Directory.SetCurrentDirectory("/home/ADDC/jimtete/GitHub/DotNetCan/Deserializer/Deserializer/");

HttpClientHandler clientHandler = new HttpClientHandler();
clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };


using HttpClient client = new HttpClient(clientHandler)
{
    BaseAddress = new Uri("https://localhost:7231")
};

var temperatures = await client.GetFromJsonAsync<Temperature[]>("weatherforecast", opt);
if (temperatures != null)
{
    foreach (var temp in temperatures)
    {
        Console.WriteLine($"Summary: {temp.Summary}");
    }
}

/*if (response.IsSuccessStatusCode)
{
    var temperatures = await JsonSerializer.DeserializeAsync<Temperature[]>(await response.Content.ReadAsStreamAsync(), opt);
    if (temperatures != null)
    {
        foreach (var temp in temperatures)
        {
            Console.WriteLine($"Summary: {temp.Summary}");
        }
    }
}
else
{
    Console.WriteLine($"Whoops!, Error at: {response.StatusCode}");
}*/