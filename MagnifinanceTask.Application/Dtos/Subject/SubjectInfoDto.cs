namespace MagnifinanceTask.Application.Dtos.Subject;

public class SubjectInfoDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public CourseInfo Course { get; set; }
    
    public int StudentsCount { get; set; }

    public IEnumerable<StudentGrade> Grades { get; set; }
}

public class StudentGrade
{
    public StudentInfo Student { get; set; }
    public int GradeValue { get; set; }
}

public class StudentInfo
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public DateTime Birthday { get; set; }
    
    public int RegistrationNumber { get; set; }
}

public class CourseInfo
{
    public int Id { get; set; }

    public string Name { get; set; }

    public TeacherInfo Teacher { get; set; }
}

public class TeacherInfo
{
    public int Id { get; set; }
    
    public string Name { get; set; }

    public DateTime Birthday { get; set; }

    public double Salary { get; set; }
}