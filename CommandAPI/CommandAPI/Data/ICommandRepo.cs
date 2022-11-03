using CommandAPI.Models;

namespace CommandAPI.Data;

public interface ICommandRepo
{
    Task SaveChangesAsync();
    Task<Command?> GetCommandById(string cid);
    Task<IList<Command>> GetAllCommands();
    Task CreateCommandAsync(Command command);
    //Update
    void DeleteCommand(Command cmd);
}