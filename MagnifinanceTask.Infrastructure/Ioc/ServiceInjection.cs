using MagnifinanceTask.Application.Services.Abstract;
using MagnifinanceTask.Application.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace MagnifinanceTask.Infrastructure.Ioc;

public static class ServiceInjection
{
    public static IServiceCollection InjectServices(this IServiceCollection services)
    {
        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped<ISubjectService, SubjectService>();
        services.AddScoped<ITeacherService, TeacherService>();
        services.AddScoped<IStudentService, StudentService>();
        return services;
    }
}