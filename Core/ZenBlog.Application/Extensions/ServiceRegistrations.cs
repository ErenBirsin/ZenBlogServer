using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ZenBlog.Application.Extensions;

public static class ServiceRegistrations
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg => {}, Assembly.GetExecutingAssembly());

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
    }
}
