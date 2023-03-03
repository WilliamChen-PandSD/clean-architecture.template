using Mapster;
using CleanArchitecture.Application.Queries.Weather.Common;
using CleanArchitecture.Application.Weather.Queries;
using CleanArchitecture.Contracts.Weather;

namespace CleanArchitecture.Api.Common.Mapping;

public class WeatherRequestMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<WeatherRequest, WeatherQuery>();
        config.NewConfig<WeatherResult, WeatherResponse>();
    }
}
