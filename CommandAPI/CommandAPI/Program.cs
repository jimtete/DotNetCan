using CommandAPI.Data;
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
/*
//CREATE
app.MapGet("api/v1/commands", async (AppDbContext context) =>
{

});

//UPDATE
app.MapGet("api/v1/commands", async (AppDbContext context) =>
{

});

//DELETE
app.MapGet("api/v1/commands", async (AppDbContext context) =>
{

});*/




app.Run();
