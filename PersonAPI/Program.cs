using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PersonAPI.Data;
using PersonAPI.Dtos;
using PersonAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseNpgsql(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("api/v1/people", async (AppDbContext context, IMapper mapper) =>
{
    var people = await context.People.ToListAsync();

    return Results.Ok(mapper.Map<IList<PersonReadDto>>(people));
});
app.MapGet("api/v1/people/{id}", async (AppDbContext context, int id, IMapper mapper) =>
{
    var personModel = await context.People.FindAsync(id);

    if (personModel == null)
    {
        return Results.NotFound();
    }

    var personDto = mapper.Map<PersonReadDto>(personModel);
    
    return Results.Ok(personDto);
});

app.MapPost("api/v1/people/", async (IMapper mapper, AppDbContext context, PersonCreateDto personCreateDto) =>
{
    var personModel = mapper.Map<Person>(personCreateDto);
    
    await context.People.AddAsync(personModel);
    await context.SaveChangesAsync();

    return Results.Created($"api/v1/people/{personModel.Id}", 
        mapper.Map<PersonReadDto>(personModel));
});

app.MapPut("api/v1/people/{id}", async (AppDbContext context, int id, Person person) =>
{
    var personModel = await context.People.FindAsync(id);
    if (personModel == null)
    {
        return Results.NotFound();
    }

    personModel.FullName = person.FullName;
    personModel.Telephone = person.Telephone;
    personModel.DoB = person.DoB;
    await context.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("api/v1/people/{id}", async (AppDbContext context, int id) =>
{
    var personModel = await context.People.FindAsync(id);
    if (personModel == null)
    {
        return Results.NotFound();
    }

    context.People.Remove(personModel);
    await context.SaveChangesAsync();
    return Results.Ok(personModel);

});

app.Run();
