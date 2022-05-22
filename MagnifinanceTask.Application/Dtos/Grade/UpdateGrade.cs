using System.ComponentModel.DataAnnotations;

namespace MagnifinanceTask.Application.Dtos.Grade;

public class UpdateGrade
{
    public int Id { get; set; }

    [Range(0, 100)]
    public int Value { get; set; }
}