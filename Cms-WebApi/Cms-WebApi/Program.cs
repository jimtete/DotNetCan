using System.Text.Json.Serialization;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cms_WebApi.Models;
using Cms_WebApi.CRUD;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CmsDatabaseContext>(options => 
    options.UseInMemoryDatabase("CmsDatabase"));
builder.Services.AddAutoMapper(typeof(CmsMapper));

//Creating the application.
var app = builder.Build();

app.CourseRequestsEndpoints();
app.StudentRequestsEndpoints();

app.MapGet("/", () => "Hello world!");

app.Run();

public class CmsMapper : Profile
{
    public CmsMapper()
    {
        //Courses Mapping
        CreateMap<Course, CourseDTO>();

        CreateMap<CourseDTO, Course>();
        
        
        //Students Mapping
        CreateMap<StudentDTO, Student>();

        CreateMap<Student, StudentDTO>();
    }
}


public class CmsDatabaseContext : DbContext
{
    
    
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses => Set<Course>();

    public CmsDatabaseContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(eb =>
        {
            eb.HasNoKey();
        });
    }
    
    
}