using MagnifinanceTask.Application.Dtos.Teacher;
using MagnifinanceTask.Domain.Models;

namespace MagnifinanceTask.Application.Services.Abstract;

public interface ITeacherService
{
    void AddNewTeacher(AddTeacherDto dto);
    void UpdateTeacher(UpdateTeacherDto dto);
    void DeleteTeacher(int id);
    IEnumerable<Teacher> GetAllTeachers();
    Teacher GetById(int id);
}