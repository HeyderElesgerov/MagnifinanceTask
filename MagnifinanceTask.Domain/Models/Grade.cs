namespace MagnifinanceTask.Domain.Models;

public class Grade : Entity<int>
{
    public int Value { get; set; }

    public int StudentId { get; set; }
    public Student Student { get; set; }

    public int SubjectId { get; set; }
    public Subject Subject { get; set; }
}