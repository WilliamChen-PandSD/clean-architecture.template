using FluentAssertions;
using FluentAssertions.Execution;
using MapsterMapper;
using Mapster;
using CleanArchitecture.Application.Queries.Weather.Common;
using CleanArchitecture.Contracts.Weather;
using CleanArchitecture.UnitTests.Data;
using CleanArchitecture.Api.Common.Mapping;

namespace CleanArchitecture.UnitTests.Mappers;

public class WeatherMappingTests
{
    private readonly IMapper _mapper;

    public WeatherMappingTests()
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(typeof(WeatherRequestMappingConfig).Assembly);
        _mapper = new Mapper(config);
    }

    [Fact]
    public void WeatherMapper_Should_Success()
    {
        // Arrange
        var weatherResult = MockData.ReturnWeatherResult();

        // Act
        var weatherResponse = _mapper.Map<WeatherResponse>(weatherResult);

        // Assert
        using (new AssertionScope())
        {
            weatherResponse.Should().NotBeNull();
            weatherResponse.City.Should().BeEquivalentTo("Brisbane");
            weatherResponse.Temperature.CurrentTemp.Should().Be(23);
            weatherResponse.Temperature.FeelsLike.Should().Be(27.3);
            weatherResponse.Temperature.MaxTemperature.Should().Be(29);
            weatherResponse.Temperature.Humidity.Should().Be(0.14);
            weatherResponse.Temperature.SeeLevel.Should().Be(1);
        }
    }
}