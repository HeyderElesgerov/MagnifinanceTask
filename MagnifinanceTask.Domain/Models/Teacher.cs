namespace MagnifinanceTask.Domain.Models;

public class Teacher : Entity<int>
{
    public string Name { get; set; }

    public DateTime Birthday { get; set; }

    public double Salary { get; set; }
    
    public IEnumerable<Course> Courses { get; set; }
}