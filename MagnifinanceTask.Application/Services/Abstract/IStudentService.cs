using MagnifinanceTask.Application.Dtos.Student;
using MagnifinanceTask.Domain.Models;

namespace MagnifinanceTask.Application.Services.Abstract;

public interface IStudentService
{
    void AddNewStudent(AddStudentDto dto);
    void UpdateStudent(UpdateStudentDto dto);
    void DeleteStudent(int id);
    IEnumerable<Student> GetAllStudents();
    Student GetById(int id);
    IEnumerable<StudentInfoDto> List();
}