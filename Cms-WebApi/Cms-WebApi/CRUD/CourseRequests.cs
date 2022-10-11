using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Cms_WebApi.Models;

namespace Cms_WebApi.CRUD;

public static class CourseRequests
{
    public static void CourseRequestsEndpoints(this WebApplication app)
    {
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
                return Results.Created($"/courses/{result.Id}", result);
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
                //course.CourseType = courseDto.CourseType;
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
        
        
    }
    
}