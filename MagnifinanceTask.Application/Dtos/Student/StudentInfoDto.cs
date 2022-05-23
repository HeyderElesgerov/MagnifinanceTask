using System.Security.AccessControl;
using MagnifinanceTask.Application.Dtos.Subject;

namespace MagnifinanceTask.Application.Dtos.Student;

public class StudentInfoDto
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public DateTime Birthday { get; set; }
    
    public int RegistrationNumber { get; set; }

    public IEnumerable<GradeInfo> Grades { get; set; }
}

public class GradeInfo
{
    public int Id { get; set; }

    public int Value { get; set; }

    public SubjectInfo Subject { get; set; }
}

public class SubjectInfo
{
    public int Id { get; set; }

    public string Name { get; set; }
}