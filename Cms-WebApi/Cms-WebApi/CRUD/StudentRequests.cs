using AutoMapper;
using Cms_WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Cms_WebApi.CRUD;

public static class StudentRequests
{
    public static void StudentRequestsEndpoints(this WebApplication app)
    {
        app.MapGet("/students", async (CmsDatabaseContext db) =>
        {
            try
            {
                var results = await db.Students.ToListAsync();
                return Results.Ok(results);
            }
            catch (SystemException ex)
            {
                return Results.Problem(ex.Message);
            }
        });
        
        app.MapGet("/students/{studentId}", async (int studentId, CmsDatabaseContext db, IMapper mapper) =>
        {
            var student = await db.Students.FindAsync(studentId);
            if (student == null)
            {
                return Results.NotFound();
            }
    
            var result =  mapper.Map<StudentDTO>(student);
            return Results.Ok(result);
        });
        
        app.MapPost("/students", async (StudentDTO studentDto,
            CmsDatabaseContext db,
            IMapper mapper) =>
        {
            try
            {
                var newStudent = mapper.Map<Student>(studentDto);
                db.Students.Add(newStudent);
                await db.SaveChangesAsync();

                var result = mapper.Map<StudentDTO>(newStudent);
                return Results.Created($"/students/{result.Id}", result);
            }
            catch (System.Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        });

        app.MapPut("/students/{studentId}",
            async (int studentId, StudentDTO studentDTO, CmsDatabaseContext db, IMapper mapper) =>
            {
                var student = await db.Students.FindAsync(studentId);
                if (student == null)
                {
                    return Results.NotFound();
                }
                if(studentDTO.Gpa!=0)student.Gpa = studentDTO.Gpa;
                if (studentDTO.FirstName!=null)student.FirstName = studentDTO.FirstName;
                if (studentDTO.LastName!=null)student.LastName = studentDTO.LastName;
                if (studentDTO.SchoolCharacteristic!=null)student.SchoolCharacteristic = studentDTO.SchoolCharacteristic;

                await db.SaveChangesAsync();

                var result = mapper.Map<StudentDTO>(student);
                return Results.Ok(result);
            });

        app.MapDelete("/students/{studentId}",
            async (int studentId, CmsDatabaseContext db, IMapper mapper) =>
            {
                var student = await db.Students.FindAsync(studentId);
                if (student == null)
                {
                    return Results.NotFound();
                }

                db.Students.Remove(student);
                await db.SaveChangesAsync();

                var result = mapper.Map<StudentDTO>(student);
                return Results.Ok(result);
            });
    }
    
    
    
}