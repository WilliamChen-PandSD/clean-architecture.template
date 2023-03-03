using MediatR;
using CleanArchitecture.Application.Queries.Weather.Common;
using CleanArchitecture.Application.Weather.Queries;
using ErrorOr;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Common.Errors;

namespace CleanArchitecture.Application.Queries.Weather;

public class WeatherQueryHandler : IRequestHandler<WeatherQuery, ErrorOr<WeatherResult>>
{
    private readonly IWeatherProxy _weatherProxy;
    private readonly IDirectGeocodingProxy _directGeocodingProxy;

    public WeatherQueryHandler(IWeatherProxy weatherProxy, IDirectGeocodingProxy directGeocodingProxy)
    {
        _weatherProxy = weatherProxy;
        _directGeocodingProxy = directGeocodingProxy;
    }
    public async Task<ErrorOr<WeatherResult>> Handle(WeatherQuery request, CancellationToken cancellationToken)
    {
        var location = await _directGeocodingProxy.GetLocation(request, cancellationToken);

        return location is not null
            ? (ErrorOr<WeatherResult>)await _weatherProxy.GetWeatherResult(location.Latitude, location.Longitude, cancellationToken)
            : (ErrorOr<WeatherResult>)Errors.Location.LocationNotFound;
    }
}