using MagnifinanceTask.Application.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace MagnifinanceTask.Infrastructure.Ioc;

public static class MapperInjection
{
    public static IServiceCollection InjectAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(ex =>
        {
            ex.AddProfile(typeof(CourseProfile));
            ex.AddProfile(typeof(SubjectProfile));
            ex.AddProfile(typeof(TeacherProfile));
            ex.AddProfile(typeof(StudentProfile));
            ex.AddProfile(typeof(GradeProfile));
        });
        return services;
    }
}