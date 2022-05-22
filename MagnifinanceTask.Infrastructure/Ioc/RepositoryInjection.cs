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
        services.AddScoped<IGenericRepository<Subject, int>, GenericRepository<Subject, int>>();
        return services;
    }
}