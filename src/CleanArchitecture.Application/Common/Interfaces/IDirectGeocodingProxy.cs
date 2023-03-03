using CleanArchitecture.Application.Weather.Queries;
using CleanArchitecture.Domain.Weather;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface IDirectGeocodingProxy
{
    Task<Location> GetLocation(WeatherQuery query, CancellationToken cancellationToken);
}