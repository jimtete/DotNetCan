using System.ComponentModel.DataAnnotations;

namespace PersonAPI.Models;

public class Person
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string FullName { get; set; }
    [Required]
    public string Telephone { get; set; }
    [Required]
    public string DoB { get; set; }

    public int YearsAlive
    {
        get
        {
            var Today = DateTime.Today;

            var splitDoB = DoB!.Split("/");

            return Today.Year - Int32.Parse(splitDoB[2]);
        }
    }
}