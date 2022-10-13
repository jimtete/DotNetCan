using DiApi.DataServices;

namespace DiApi.Data;

public class NoSqlDataRepo : IDataRepo
{
    //private readonly IDataService _dataService;
    private readonly IServiceScopeFactory _serviceScopeFactory;
    
    public NoSqlDataRepo(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
        //_dataService = dataService;
    }
    
    public string ReturnData()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("--> Getting data from SQL Database...");
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            var dataService = scope.ServiceProvider.GetRequiredService<IDataService>();
            dataService.GetProductData("https://something.com/api");
            Console.ResetColor();
        
            return ("No SQL DATA FROM DB");
        }
        
        
    }
}