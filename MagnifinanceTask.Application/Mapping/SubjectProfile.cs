using AutoMapper;
using MagnifinanceTask.Application.Dtos.Subject;
using MagnifinanceTask.Domain.Models;

namespace MagnifinanceTask.Application.Mapping;

public class SubjectProfile : Profile
{
    public SubjectProfile()
    {
        CreateMap<AddSubjectDto, Subject>();
    }
}