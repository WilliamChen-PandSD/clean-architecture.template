using FluentValidation.Results;
using FluentAssertions;
using CleanArchitecture.Application.Weather.Queries;
using FluentAssertions.Execution;

namespace CleanArchitecture.UnitTests.Validation;

public class ValidationTests
{
    private ValidationResult WeatherQueryValidateModel(WeatherQuery query)
    {
        var validator = new WeatherQueryValidator();
        var validateResult = validator.Validate(query);

        return validateResult;
    }

    [Theory]
    [MemberData(nameof(WeatherQueryInputModel))]
    public void When_WeatherQuery_Return_ValidateResult(WeatherQuery query, bool isValid, int numberOfErrors, string validationMessage)
    {
        // Arrange

        // Act
        var validateResult = WeatherQueryValidateModel(query);

        // Assert
        using (new AssertionScope())
        {
            validateResult.IsValid.Should().Be(isValid);
            validateResult.Errors.Count.Should().Be(numberOfErrors);
            if (numberOfErrors > 0)
            {
                var errors = string.Join(" ", validateResult.Errors.ConvertAll(error => error.ErrorMessage));
                errors.Should().BeEquivalentTo(validationMessage);
            }
        }
    }

    public static IEnumerable<object[]> WeatherQueryInputModel =>
        new List<object[]>
        {
            new object[]
            {
                new WeatherQuery("Brisbane", "QLD", "4000", "AU"), true, 0, string.Empty
            },
            new object[]
            {
                new WeatherQuery("Brisbane", "QLD", string.Empty, "AU"), false, 1, "'Post Code' must not be empty."
            },
            new object[]
            {
                new WeatherQuery("Brisbane", "QLD", null!, "AU"), false, 1, "'Post Code' must not be empty."
            },
            new object[]
            {
                new WeatherQuery("Brisbane", "QLD", "4000", ""), false, 1, "'Country Code' must not be empty."
            },
            new object[]
            {
                new WeatherQuery(null!, "QLD", "4000", "AU"), true, 0, string.Empty
            },
            new object[]
            {
                new WeatherQuery("Brisbane", null!, "4000", "AU"), true, 0, string.Empty
            },
            new object[]
            {
                new WeatherQuery("Brisbane", "QLD", null!, null!), false, 2, "'Post Code' must not be empty. 'Country Code' must not be empty."
            }
        };
}