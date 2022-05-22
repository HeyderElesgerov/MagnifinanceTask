namespace MagnifinanceTask.Domain.Models;

public class Student : Entity<int>
{
    public string Name { get; set; }
    
    public DateTime Birthday { get; set; }
    
    public int RegistrationNumber { get; set; }
    
    public IEnumerable<Course> Courses { get; set; }
    public IEnumerable<Grade> Grades { get; set; }
}