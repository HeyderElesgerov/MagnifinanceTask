using AutoMapper;
using MagnifinanceTask.Application.Dtos.Teacher;
using MagnifinanceTask.Domain.Models;

namespace MagnifinanceTask.Application.Mapping;

public class TeacherProfile : Profile
{
    public TeacherProfile()
    {
        CreateMap<AddTeacherDto, Teacher>();
    }
}