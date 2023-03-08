using Microsoft.Extensions.Logging;
using FluentAssertions;
using MapsterMapper;
using MediatR;
using NSubstitute;
using CleanArchitecture.Api.Controllers;
using CleanArchitecture.Contracts.Weather;
using CleanArchitecture.Api.Swagger;
using FluentAssertions.Execution;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Application.Weather.Queries;
using ErrorOr;
using CleanArchitecture.Application.Queries.Weather.Common;
using CleanArchitecture.UnitTests.Data;
using Mapster;
using CleanArchitecture.Api.Common.Mapping;

namespace CleanArchitecture.UnitTests.Controllers;

public class WeatherControllerTests
{
    private readonly IMapper _mapper;
    private readonly ISender _sender;
    private readonly ILogger<WeatherController> _logger;
    private readonly WeatherController _controller;

    public WeatherControllerTests()
    {
        _sender = Substitute.For<ISender>();
        _logger = Substitute.For<ILogger<WeatherController>>();

        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(typeof(WeatherRequestMappingConfig).Assembly);
        _mapper = new Mapper(config);

        _controller = new WeatherController(_mapper, _sender, _logger);
    }

    [Fact]
    public async Task Weather_Returns_Success_When_ValidInput()
    {
        // Arrange
        var request = new WeatherRequest("Brisbane", "QLD", "4000", "AU");

        _sender.Send(Arg.Any<WeatherQuery>()).ReturnsForAnyArgs((ErrorOr<WeatherResult>)MockData.ReturnWeatherResult());

        // Act
        var response = await _controller.Get(request, new CancellationToken());

        // Assert
        using (new AssertionScope())
        {
            response.Should().NotBeNull();
            var result = (response as OkObjectResult)!.Value as WeatherResponse;
            result!.City.Should().BeEquivalentTo("Brisbane");
            result.Temperature.CurrentTemp.Should().Be(23);
            result.Temperature.FeelsLike.Should().Be(27.3);
            result.Temperature.MaxTemperature.Should().Be(29);
            result.Temperature.Humidity.Should().Be(0.14);
            result.Temperature.SeeLevel.Should().Be(1);
        }
    }
}