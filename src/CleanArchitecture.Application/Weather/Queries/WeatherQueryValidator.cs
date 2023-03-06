using FluentValidation;

namespace CleanArchitecture.Application.Weather.Queries;

public class WeatherQueryValidator : AbstractValidator<WeatherQuery>
{
    public WeatherQueryValidator()
    {
        RuleFor(x => x.PostCode).NotEmpty();
        RuleFor(x => x.CountryCode).NotEmpty();
    }
}