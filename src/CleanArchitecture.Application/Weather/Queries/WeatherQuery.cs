using ErrorOr;
using MediatR;
using CleanArchitecture.Application.Queries.Weather.Common;

namespace CleanArchitecture.Application.Weather.Queries;

public record WeatherQuery(
    string City,
    string StateCode,
    string PostCode,
    string CountryCode) : IRequest<ErrorOr<WeatherResult>>;