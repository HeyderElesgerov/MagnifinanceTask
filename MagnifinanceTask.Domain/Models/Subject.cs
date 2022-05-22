namespace MagnifinanceTask.Domain.Models;

public class Subject : Entity<int>
{
    public string Name { get; set; }
    
    public int CourseId { get; set; }
    public Course Course { get; set; }

    public IEnumerable<Grade> Grades { get; set; }
}