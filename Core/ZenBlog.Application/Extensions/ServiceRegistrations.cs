﻿using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ZenBlog.Application.Behaviors;
using ZenBlog.Application.Options;

namespace ZenBlog.Application.Extensions;

public static class ServiceRegistrations
{
    public static void AddApplication(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.Configure<JwtTokenOptions>(configuration.GetSection(nameof(JwtTokenOptions)));
    }
}
