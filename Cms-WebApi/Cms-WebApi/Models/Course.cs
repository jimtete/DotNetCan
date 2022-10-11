using Microsoft.EntityFrameworkCore;
namespace Cms_WebApi.Models;

public class Course
{
    public Course(string? courseName, int courseDuration, string? courseType)
    {
        CourseName = courseName;
        CourseDuration = courseDuration;
        CourseType = courseType;
    }

    public Course()
    {
    }

    public int Id { get; set; }
    public string? CourseName { get; set; }
    public int CourseDuration { get; set; }
    public string? CourseType { get; set; }
}
public class CourseDTO
{
    public int Id { get; set; }
    public string? CourseName { get; set; }
    public int CourseDuration { get; set; }
    
    public string? CourseType { get; set; }
}
