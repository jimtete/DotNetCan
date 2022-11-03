using CommandAPI.Data;
using CommandAPI.Models;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>
    (opt => opt.UseNpgsql(connectionString));

builder.Services.AddSingleton<IConnectionMultiplexer>
    (opt => ConnectionMultiplexer.
        Connect(builder.Configuration.GetConnectionString("RedisConnection")));
builder.Services.AddScoped<ICommandRepo,SqlCommandRepo>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//GET SINGLE
app.MapGet("api/v1/commands/{commandId}", async (ICommandRepo repo, string commandId) =>
{
    var command = await repo.GetCommandById(commandId);

    if (command == null)
    {
        return Results.NotFound();
    }
    
    return Results.Ok(command);
});

//GET MULTIPLE
app.MapGet("api/v1/commands", async (ICommandRepo repo) =>
{
    var commands = await repo.GetAllCommands();

    return Results.Ok(commands);
});

//CREATE
app.MapPost("api/v1/commands", async (ICommandRepo repo, Command command) =>
{
    await repo.CreateCommandAsync(command);
    await repo.SaveChangesAsync();

    return Results.Created($"api/v1/commands/{command.CommandId}", command);
});

//UPDATE
app.MapPut("api/v1/commands/{commandId}", async (ICommandRepo repo, string commandId
, Command command) =>
{
    var modelCommand = await repo.GetCommandById(commandId);
    
    if (modelCommand is null)
    {
        return Results.NotFound();
    }

    modelCommand.HowTo = command.HowTo;
    modelCommand.Platform = command.Platform;
    modelCommand.CommandLine = command.CommandLine;

    await repo.UpdateCommandAsync(modelCommand);
    await repo.SaveChangesAsync();

    return Results.NoContent();

});

//DELETE
app.MapDelete("api/v1/commands/{commandId}", async (ICommandRepo repo, string commandId) =>
{
    var command = await repo.GetCommandById(commandId);

    if (command == null)
    {
        return Results.NotFound();
    }

    repo.DeleteCommand(command);
    await repo.SaveChangesAsync();

    return Results.Ok(command);
});




app.Run();
