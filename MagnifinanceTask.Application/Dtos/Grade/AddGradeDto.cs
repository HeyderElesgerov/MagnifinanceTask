using System.ComponentModel.DataAnnotations;

namespace MagnifinanceTask.Application.Dtos.Grade;

public class AddGradeDto
{
    public int StudentId { get; set; }

    [Range(0, 100)]
    public int Value { get; set; }
}