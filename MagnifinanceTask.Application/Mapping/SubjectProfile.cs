using AutoMapper;
using MagnifinanceTask.Application.Dtos.Subject;
using MagnifinanceTask.Domain.Models;

namespace MagnifinanceTask.Application.Mapping;

public class SubjectProfile : Profile
{
    public SubjectProfile()
    {
        CreateMap<AddSubjectDto, Subject>();
        CreateMap<Subject, SubjectInfoDto>()
            .ForMember(dto => dto.StudentsCount, ex => ex.MapFrom((m, dto) => m.Course.Students.Count()))
            .ForMember(dto => dto.Course, ex => ex.MapFrom((m, _) =>
            {
                return new CourseInfo()
                {
                    Id = m.CourseId,
                    Name = m.Course.Name,
                    Teacher = new TeacherInfo()
                    {
                        Id = m.Course.Teacher.Id,
                        Birthday = m.Course.Teacher.Birthday,
                        Name = m.Course.Teacher.Name,
                        Salary = m.Course.Teacher.Salary,
                    }
                };
            }))
            .ForMember(dto => dto.Grades, ex => ex.MapFrom((m, dto) =>
            {
                List<StudentGrade> studentGrades = new List<StudentGrade>();
                foreach (var student in m.Course.Students)
                {
                    var grades = student.Grades.Where(g => g.SubjectId == m.Id);
                    studentGrades.AddRange(grades.Select(g => new StudentGrade()
                    {
                        GradeValue = g.Value,
                        Student = new StudentInfo()
                        {
                            Id = student.Id,
                            Name = student.Name,
                            Birthday = student.Birthday,
                            RegistrationNumber = student.RegistrationNumber
                        }
                    }));
                }

                return studentGrades;
            }));
    }
}