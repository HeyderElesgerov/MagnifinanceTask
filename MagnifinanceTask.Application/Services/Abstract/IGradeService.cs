using MagnifinanceTask.Application.Dtos.Grade;
using MagnifinanceTask.Domain.Models;

namespace MagnifinanceTask.Application.Services.Abstract;

public interface IGradeService
{
    void AddNewGrade(AddGradeDto dto);
    void UpdateGrade(UpdateGradeDto dto);
    void DeleteGrade(int id);
    IEnumerable<Grade> GetAllGrades();
    Grade GetById(int id);
}