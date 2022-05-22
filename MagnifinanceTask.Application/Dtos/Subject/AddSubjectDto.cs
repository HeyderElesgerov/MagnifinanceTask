using System.ComponentModel.DataAnnotations;

namespace MagnifinanceTask.Application.Dtos.Subject;

public class AddSubjectDto
{
    [Required]
    public string Name { get; set; }

    public int CourseId { get; set; }
}