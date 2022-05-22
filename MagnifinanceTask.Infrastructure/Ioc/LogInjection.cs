using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace MagnifinanceTask.Infrastructure.Ioc;

public static class LogInjection
{
    public static IServiceCollection InjectSerilog(this IServiceCollection services, string logPath)
    {
        services.AddSingleton<Serilog.ILogger>(new LoggerConfiguration().WriteTo.File(logPath).CreateLogger());
        return services;
    }
}