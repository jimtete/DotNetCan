using System.Text.Json.Serialization;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CmsDatabaseContext>(options => 
    options.UseInMemoryDatabase("CmsDatabase"));
builder.Services.AddAutoMapper(typeof(CmsMapper));

var app = builder.Build();

app.MapGet("/", () => "Hello world!");

app.MapGet("/courses", async (CmsDatabaseContext db) =>
{

    try
    {
        var results = await db.Courses.ToListAsync();
        return Results.Ok(results);
    }
    catch (System.Exception ex)
    {
        return Results.Problem(ex.Message);
    }
    
});

app.MapGet("/courses/{courseId}", async (int courseId, CmsDatabaseContext db, IMapper mapper) =>
{
    var course = await db.Courses.FindAsync(courseId);
    if (course == null)
    {
        return Results.NotFound();
    }

    var result = mapper.Map<CourseDTO>(course);
    return Results.Ok(result);
});

//app.MapPost("/courses", async ([FromBody] CourseDTO courseDto,[FromServices] CmsDatabaseContext db,[FromServices] IMapper mapper) =>
app.MapPost("/courses", async (CourseDTO courseDto,
    CmsDatabaseContext db,
    IMapper mapper) =>
{
    try
    {
        var newCourse = mapper.Map<Course>(courseDto);
        
        db.Courses.Add(newCourse);
        await db.SaveChangesAsync();

        var result = mapper.Map<CourseDTO>(newCourse);
        return Results.Created($"/courses/{result.CourseId}", result);
    }
    catch (System.Exception ex)
    {
        return Results.Problem(ex.Message);
    }
});

app.MapPut("/courses/{courseId}",
    async (int courseId, CourseDTO courseDto, CmsDatabaseContext db, IMapper mapper) =>
    {
        var course = await db.Courses.FindAsync(courseId);
        if (course == null)
        {
            return Results.NotFound();
        }

        course.CourseName = courseDto.CourseName;
        course.CourseDuration = courseDto.CourseDuration;
        course.CourseType = (int)courseDto.CourseType;
        await db.SaveChangesAsync();
        
        var result = mapper.Map<CourseDTO>(course);
        return Results.Ok(result);

    });

app.MapDelete("/courses/{courseId}", async (int courseId, CmsDatabaseContext db, IMapper mapper) =>
{
    var course = await db.Courses.FindAsync(courseId);
    if (course == null)
    {
        return Results.NotFound();
    }

    db.Courses.Remove(course);
    await db.SaveChangesAsync();

    var result = mapper.Map<CourseDTO>(course);
    return Results.Ok(result);
});

app.Run();

public class CmsMapper : Profile
{
    public CmsMapper()
    {
        CreateMap<Course, CourseDTO>();

        CreateMap<CourseDTO, Course>();
    }
}
public class Course
{
    public int CourseId { get; set; }
    public string? CourseName { get; set; }
    public int CourseDuration { get; set; }
    public int CourseType { get; set; }
}

public class CourseDTO
{
    public int CourseId { get; set; }
    public string? CourseName { get; set; }
    public int CourseDuration { get; set; }
    
    [JsonConverter((typeof(JsonStringEnumConverter)))]
    public COURSE_TYPE CourseType { get; set; }
}

public enum COURSE_TYPE
{
    ENGINEERING = 1,
    MEDIAL,
    MANAGEMENT
}

public class CmsDatabaseContext : DbContext
{
    public DbSet<Course> Courses => Set<Course>();
    public CmsDatabaseContext(DbContextOptions options) : base(options)
    {
        
    }
}