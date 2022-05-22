using MagnifinanceTask.Application.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace MagnifinanceTask.Infrastructure.Ioc;

public static class MapperInjection
{
    public static IServiceCollection InjectAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(ex => ex.AddProfile(typeof(CourseProfile)));
        return services;
    }
}