using System.ComponentModel.DataAnnotations;

namespace MagnifinanceTask.Application.Dtos.Student;

public class AddStudentDto
{
    [Required]
    public string Name { get; set; }
    
    public DateTime Birthday { get; set; }
}