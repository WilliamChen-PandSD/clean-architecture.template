namespace CleanArchitecture.Contracts.Weather;

public record WeatherRequest(
    string City,
    string StateCode,
    string PostCode,
    string CountryCode);