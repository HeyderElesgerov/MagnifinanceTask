using System.Security.Cryptography;
using AutoMapper;
using MagnifinanceTask.Application.Dtos.Student;
using MagnifinanceTask.Domain.Models;

namespace MagnifinanceTask.Application.Mapping;

public class StudentProfile : Profile
{
    public StudentProfile()
    {
        CreateMap<AddStudentDto, Student>()
            .ForMember(m => m.RegistrationNumber, ex => ex.MapFrom((_, _) => RandomNumberGenerator.GetInt32(1000, 9999)) );
    }
}