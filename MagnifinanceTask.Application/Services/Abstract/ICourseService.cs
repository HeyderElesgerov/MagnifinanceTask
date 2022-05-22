using MagnifinanceTask.Application.Dtos.Course;
using MagnifinanceTask.Domain.Models;

namespace MagnifinanceTask.Application.Services.Abstract;

public interface ICourseService
{
    void AddNewCourse(AddCourseDto dto);
    void UpdateCourse(UpdateCourseDto dto);
    void DeleteCourse(int id);
    IEnumerable<CourseInfoDto> ListCourses();
    IEnumerable<Course> GetAllCourses();
    Course GetById(int id);
}