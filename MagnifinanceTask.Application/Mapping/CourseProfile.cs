using AutoMapper;
using MagnifinanceTask.Application.Dtos.Course;
using MagnifinanceTask.Domain.Models;

namespace MagnifinanceTask.Application.Mapping;

public class CourseProfile : Profile
{
    public CourseProfile()
    {
        CreateMap<Course, CourseInfoDto>()
            .ForMember(dto => dto.StudentsCount, ex => ex.MapFrom((m, _) => m.Students.Count()))
            .ForMember(dto => dto.TeacherCount, ex => ex.MapFrom((_, _) => 1))
            .ForMember(dto => dto.GradeAverage, ex => ex.MapFrom((m, _) =>
            {
                double gradeSum = m.Students.SelectMany(s => s.Grades).Where(g => g.Subject.CourseId == m.Id)
                    .Select(g => g.Value).Sum();
                double average =  gradeSum / m.Students.Count();
                if (double.IsNormal(average))
                    return average;
                return 0;
            }));

        CreateMap<AddCourseDto, Course>();
        CreateMap<UpdateCourseDto, Course>();
    }
}