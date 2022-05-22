namespace MagnifinanceTask.Application.Dtos.Course;

public class CourseInfoDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int TeacherCount { get; set; }

    public int StudentsCount { get; set; }

    public double GradeAverage { get; set; }
}