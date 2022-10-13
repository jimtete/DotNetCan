namespace DiApi.DataServices;

public class HttpDataService : IDataService
{
    public string GetProductData(string missing_name)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("---> Getting Product data...");
        Console.ResetColor();
        
        return "Some product data";
    }
}