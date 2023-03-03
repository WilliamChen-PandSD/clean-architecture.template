using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Queries.Weather.Common;

namespace CleanArchitecture.Infrastructure.Weather;

public class WeatherProxy : IWeatherProxy
{
    public Task<WeatherResult> GetWeatherResult(double latitude, double longitude, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
