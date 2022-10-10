using FactorialAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IStaticMethods, StaticMethods>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Userdb>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/Factorial",Factorial);

app.UseHttpsRedirection();

app.Run();

public static IResult Factorial([FromServices] IStaticMethods staticMethods,[FromBody] int number)
{
    return Results.Ok(staticMethods.RecursiveFactorial(number));
}

record User(int id)
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;

    public int BirthYear { get; set; } = default!;
}

class Userdb : DbContext
{
    public Userdb(DbContextOptions<Userdb> options) : base(options)
    {
        
    }

    public DbSet<User> Users => Set<User>();
}




