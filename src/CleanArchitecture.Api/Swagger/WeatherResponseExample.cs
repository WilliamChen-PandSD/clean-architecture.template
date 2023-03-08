using CleanArchitecture.Contracts.Weather;

using Swashbuckle.AspNetCore.Filters;

namespace CleanArchitecture.Api.Swagger;

public class WeatherResponseExample : IExamplesProvider<WeatherResponse>
{
    public WeatherResponse GetExamples() => ReturnWeatherResponse();

    public static WeatherResponse ReturnWeatherResponse()
    {
        return new("Brisbane",
                    new Temperature(23, 27.3, 17, 29, 4.5, 0.14, 2, 1, "F"),
                    new Wind(3.5, 3.6, 1));
    }
}