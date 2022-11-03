using System.Text.Json;
using CommandAPI.Models;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using StackExchange.Redis;

namespace CommandAPI.Data;

public class RedisCommandRepo : ICommandRepo
{

    private readonly IConnectionMultiplexer _redis;

    public RedisCommandRepo(IConnectionMultiplexer redis)
    {
        _redis = redis;
    }
    
    public async Task SaveChangesAsync()
    {
        Console.WriteLine("-->Save changes is no longer needed");
        await Task.CompletedTask;
    }

    public async Task<Command?> GetCommandById(string cid)
    {
        var db = _redis.GetDatabase();

        var command = await db.HashGetAsync("commands", cid);

        if (!string.IsNullOrEmpty(command))
        {
            return JsonSerializer.Deserialize<Command>(command);
        }

        return null;
    }

    public async Task<IList<Command?>?> GetAllCommands()
    {
        var db = _redis.GetDatabase();

        var completeSet = await db.HashGetAllAsync("commands");

        if (completeSet.Length > 0)
        {
            return Array.ConvertAll(completeSet, val =>
                JsonSerializer.Deserialize<Command>(val.Value));
        }

        List<Command> empty = new List<Command>();

        return empty;
    }

    public async Task CreateCommandAsync(Command command)
    {
        if (command == null)
        {
            throw new ArgumentNullException(nameof(command));
        }

        var db = _redis.GetDatabase();

        var serialCommand = JsonSerializer.Serialize(command);

        await db.HashSetAsync($"commands", new HashEntry[] 
            {new HashEntry(command.CommandId,serialCommand)});
    }

    public void DeleteCommand(Command cmd)
    {
        var db = _redis.GetDatabase();

        db.HashDelete("commands", cmd.CommandId);
    }

    public async Task UpdateCommandAsync(Command command)
    {
        var db = _redis.GetDatabase();

        var serialCommand = JsonSerializer.Serialize(command);
        await db.HashSetAsync($"commands", new HashEntry[] 
            {new HashEntry(command.CommandId,serialCommand)});
    }
}