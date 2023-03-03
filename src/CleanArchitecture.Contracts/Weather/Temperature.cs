namespace CleanArchitecture.Contracts.Weather;

public record Temperature(
    double CurrentTemp,
    double FeelsLike,
    double MinTemperature,
    double MaxTemperature,
    double Pressure,
    double Humidity,
    double SeeLevel,
    double GroundLevel,
    string Unit);