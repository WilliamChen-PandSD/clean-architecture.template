using CleanArchitecture.Application.Queries.Weather.Common;
using CleanArchitecture.Domain.Weather;

namespace CleanArchitecture.UnitTests.Data;

public static class MockData
{
    public static WeatherResult ReturnWeatherResult()
    {
        return new(
                new Temperature
                {
                    CurrentTemp = 23,
                    FeelsLike = 27.3,
                    MaxTemperature = 29,
                    MinTemperature = 18,
                    GroundLevel = 4.5,
                    Humidity = 0.14,
                    Pressure = 2,
                    SeeLevel = 1,
                    Unit = "F"
                },
                    new Wind
                    {
                        DirectionDegrees = 3.5,
                        Gus = 3.6,
                        Speed = 1
                    },
                    new Location
                    {
                        Country = "AU",
                        Latitude = 3.3,
                        Longitude = 2.2,
                        State = "QLD",
                        City = "Brisbane"
                    });
    }
}