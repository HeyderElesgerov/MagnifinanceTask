using MagnifinanceTask.Domain.Data;
using MagnifinanceTask.Domain.Models;
using MagnifinanceTask.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace MagnifinanceTask.Infrastructure.Ioc;

public static class RepositoryInjection
{
    public static IServiceCollection InjectRepositories(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Course, int>, GenericRepository<Course, int>>();
        services.AddScoped<ISubjectRepository, SubjectRepository>();
        services.AddScoped<IGenericRepository<Teacher, int>, GenericRepository<Teacher, int>>();
        services.AddScoped<IGenericRepository<Student, int>, GenericRepository<Student, int>>();
        services.AddScoped<IGenericRepository<Grade, int>, GenericRepository<Grade, int>>();
        return services;
    }
}