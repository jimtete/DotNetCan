using CommandAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandAPI.Data;

public class SqlCommandRepo : ICommandRepo
{
    private readonly AppDbContext _context;
    
    public SqlCommandRepo(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<Command?> GetCommandById(string cid)
    {
        return await _context.Commands.FirstOrDefaultAsync(c => c.CommandId == cid);
    }

    public async Task<IList<Command>> GetAllCommands()
    {
        return await _context.Commands.ToListAsync();
    }

    public async Task CreateCommandAsync(Command command)
    {
        if (command == null)
        {
            throw new ArgumentNullException(nameof(command));
        }

        await _context.AddAsync(command);
    }

    public void DeleteCommand(Command cmd)
    {
        if (cmd == null)
        {
            throw new ArgumentNullException(nameof(cmd));
        }

        _context.Remove(cmd);
    }
}