using System.ComponentModel.DataAnnotations;

namespace MagnifinanceTask.Application.Dtos.Course;

public class AddCourseDto
{
    [Required]
    public string Name { get; set; }

    public int TeacherId { get; set; }
}