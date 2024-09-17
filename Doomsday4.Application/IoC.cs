using Doomsday4.Application.PipelineBehaviors;
using Doomsday4.Domain.Data;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace Doomsday4.Application;

public static class IoC
{
    public static IServiceCollection AddApplication(this IServiceCollection services,
        IConfigurationManager configuration)
    {
        var assembly = typeof(IoC).Assembly;
        services.AddDatabase(configuration);
        services.AddMediatR(x => 
            x.RegisterServicesFromAssembly(assembly));
        services.AddValidatorsFromAssembly(assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>),
            typeof(ValidationBehavior<,>));
        return services;
    }
}