using System.ComponentModel.DataAnnotations;

namespace MagnifinanceTask.Application.Dtos.Grade;

public class UpdateGradeDto
{
    public int Id { get; set; }

    [Range(0, 100)]
    public int Value { get; set; }
}