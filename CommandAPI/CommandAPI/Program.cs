using CommandAPI.Data;
using CommandAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(connectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//GET SINGLE
app.MapGet("api/v1/commands/{commandId}", async (AppDbContext context, string commandId) =>
{
    var command = await context.Commands.FirstOrDefaultAsync(c => c.CommandId == commandId);

    if (command == null)
    {
        return Results.NotFound();
    }
    
    return Results.Ok(command);
});

//GET MULTIPLE
app.MapGet("api/v1/commands", async (AppDbContext context) =>
{
    var commands = await context.Commands.ToListAsync();

    return Results.Ok(commands);
});

//CREATE
app.MapPost("api/v1/commands", async (AppDbContext context, Command command) =>
{
    await context.Commands.AddAsync(command);
    await context.SaveChangesAsync();

    return Results.Created($"api/v1/commands/{command.CommandId}", command);
});

//UPDATE
app.MapPut("api/v1/commands/{commandId}", async (AppDbContext context, string commandId
, Command command) =>
{
    var modelCommand = await context.Commands.FirstOrDefaultAsync(c => c.CommandId == commandId);
    
    if (modelCommand is null)
    {
        return Results.NotFound();
    }

    modelCommand.HowTo = command.HowTo;
    modelCommand.Platform = command.Platform;
    modelCommand.CommandLine = command.CommandLine;

    await context.SaveChangesAsync();

    return Results.NoContent();

});

//DELETE
app.MapDelete("api/v1/commands/{commandId}", async (AppDbContext context, string commandId) =>
{
    var command = await context.Commands.FirstOrDefaultAsync(c => c.CommandId == commandId);

    if (command == null)
    {
        return Results.NotFound();
    }

    context.Commands.Remove(command);
    await context.SaveChangesAsync();

    return Results.Ok(command);
});




app.Run();
