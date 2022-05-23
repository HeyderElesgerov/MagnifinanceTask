namespace MagnifinanceTask.Application.Dtos.Student;

public class EnrollCourseDto
{
    public IEnumerable<int> CourseIds { get; set; }

    public int StudentId { get; set; }
}