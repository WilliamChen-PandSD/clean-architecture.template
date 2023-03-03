namespace CleanArchitecture.Contracts.Weather;

public record WeatherResponse(
string City,
Temperature Temperature,
Wind Wind);