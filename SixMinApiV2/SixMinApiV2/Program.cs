using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SixMinApiV2.Data;
using SixMinApiV2.Dtos;
using SixMinApiV2.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddScoped<ICommandRepo, CommandRepo>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Endpoints
app.MapGet("api/v1/commands", async (ICommandRepo repo, IMapper mapper) =>
{
    var commands = await repo.GetAllCommands();
    return Results.Ok(mapper.Map<IEnumerable<CommandReadDto>>(commands));
});

app.MapGet("api/v1/commands/{cid}", async (ICommandRepo repo, IMapper mapper, int cid) =>
{
    var command = await repo.GetCommandById(cid);
    if (command == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(mapper.Map<CommandReadDto>(command));

});

app.MapPost("/api/v1/commands", async (ICommandRepo repo, IMapper mapper, CommandCreateDto cmdCreateDto) =>
{
    var commandModel = mapper.Map<Command>(cmdCreateDto);
    await repo.CreateCommand(commandModel);
    await repo.SaveChanges();

    var cmdReadDto = mapper.Map<CommandReadDto>(commandModel);

    return Results.Created($"api/v1/commands/{cmdReadDto.Id}",cmdReadDto);

});

app.MapPut("/api/v1/commands/{cid}",
    async (ICommandRepo repo, IMapper mapper, int cid, CommandUpdateDto cmdUpdateDto) =>
    {
        var command = await repo.GetCommandById(cid);
        if (command == null)
        {
            return Results.NotFound();
        }

        mapper.Map(cmdUpdateDto, command);
        
        await repo.SaveChanges();

        return Results.NoContent();
    });

app.MapDelete("api/v1/commands/{cid}",
    async (ICommandRepo repo, IMapper mapper, int cid) =>
    {
        var command = await repo.GetCommandById(cid);
        if (command == null)
        {
            return Results.NotFound();
        }

        repo.DeleteCommand(command);
        await repo.SaveChanges();

        return Results.NoContent();

    });

app.Run();