using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Doomsday4.Domain.Data;

public static class IoC
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        // Сюда передаём DbContext и имя подключения с файла в .Api - appsettings.json
        services.AddDbContext<RentDbContext>(
            options => options.UseNpgsql(
                configuration.GetConnectionString("name_connections")
            )
        );
        return services;
    }
}