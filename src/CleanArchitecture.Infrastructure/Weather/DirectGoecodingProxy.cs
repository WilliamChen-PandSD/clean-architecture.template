using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Weather.Queries;
using CleanArchitecture.Domain.Weather;

namespace CleanArchitecture.Infrastructure.Weather;

public class DirectGeocodingProxy : IDirectGeocodingProxy
{
    public Task<Location> GetLocation(WeatherQuery query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}