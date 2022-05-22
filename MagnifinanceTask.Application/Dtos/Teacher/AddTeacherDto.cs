using System.ComponentModel.DataAnnotations;

namespace MagnifinanceTask.Application.Dtos.Teacher;

public class AddTeacherDto
{
    [Required]
    public string Name { get; set; }

    public DateTime Birthday { get; set; }

    [Range(0, double.MaxValue)]
    public double Salary { get; set; }
}