namespace DiApi.Data;

public class NoSqlDataRepo
{
    public string GetData()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("--> Getting data from SQL Database...");
        Console.ResetColor();
        
        return ("No SQL DATA FROM DB");
    }

}