namespace CleanArchitecture.Contracts.Weather;

public record Location(
    double Latitude,
    double Longitude,
    string Country,
    string State);