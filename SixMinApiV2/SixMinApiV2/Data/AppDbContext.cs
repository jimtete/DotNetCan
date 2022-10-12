using Microsoft.EntityFrameworkCore;
using SixMinApiV2.Models;

namespace SixMinApiV2.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Command> Commands => Set<Command>();
}