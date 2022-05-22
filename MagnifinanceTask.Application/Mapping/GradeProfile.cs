using AutoMapper;
using MagnifinanceTask.Application.Dtos.Grade;
using MagnifinanceTask.Domain.Models;

namespace MagnifinanceTask.Application.Mapping;

public class GradeProfile : Profile
{
    public GradeProfile()
    {
        CreateMap<AddGradeDto, Grade>();
    }
}