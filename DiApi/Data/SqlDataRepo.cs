namespace DiApi.Data;

public class SqlDataRepo
{
    public string ReturnData()
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("--> Getting data from SQL Database...");
        Console.ResetColor();
        
        return ("SQL DATA FROM DB");
    }

}