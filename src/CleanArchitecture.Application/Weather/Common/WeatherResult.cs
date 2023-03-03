using CleanArchitecture.Domain.Weather;

namespace CleanArchitecture.Application.Queries.Weather.Common;

public record WeatherResult(Temperature Temperature, Wind Wind, Location Location);