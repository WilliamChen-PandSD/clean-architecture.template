using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Infrastructure.Weather;

using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IWeatherProxy, WeatherProxy>();
        services.AddSingleton<IDirectGeocodingProxy, DirectGeocodingProxy>();

        return services;
    }
}