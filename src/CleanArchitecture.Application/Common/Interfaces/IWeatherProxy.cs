using CleanArchitecture.Application.Queries.Weather.Common;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface IWeatherProxy
{
    Task<WeatherResult> GetWeatherResult(double latitude, double longitude, CancellationToken cancellationToken);
}