using MagnifinanceTask.Infrastructure.EF;
using Microsoft.Extensions.DependencyInjection;

namespace MagnifinanceTask.Infrastructure.Ioc;

public static class DbInjection
{
    public static IServiceCollection InjectSqlServer(this IServiceCollection services, string connectionString)
    {
        services.AddSqlServer<TaskDbContext>(connectionString, opt =>
        {
            opt.MigrationsAssembly("MagnifinanceTask.API");
        });
        return services;
    }
}