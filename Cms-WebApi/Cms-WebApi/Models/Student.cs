using Microsoft.EntityFrameworkCore;

namespace Cms_WebApi.Models;

[Keyless]
public class Student
{
    public int Id { get; set; }
    
    public string? SchoolCharacteristic { get; set; }
    
    public string? FirstName { get; set; }
    
    public string? LastName { get; set; }
    
    public float Gpa { get; set; }

    public List<int>? JoinedCourses { get; set; } = new List<int>();

}

public class StudentDTO
{
    public int Id { get; set; }
    
    public string? SchoolCharacteristic { get; set; }
    
    public string? FirstName { get; set; }
    
    public string? LastName { get; set; }
    
    public float Gpa { get; set; }

    public List<int>? JoinedCourses { get; set; } = new List<int>();

}