namespace MagnifinanceTask.Domain.Models;

public class Course : Entity<int>
{
    public string Name { get; set; }
    
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    
    public IEnumerable<Subject> Subjects { get; set; }
    
    public IEnumerable<Student> Students { get; set; }
}