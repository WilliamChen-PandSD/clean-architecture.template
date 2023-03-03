using ErrorOr;

namespace CleanArchitecture.Domain.Common.Errors;

public static partial class Errors
{
    public static class Weather
    {
        public static Error LocationNotFound
        => Error.Failure(code: "Weather.NotAvailable",
                          description: "Weather information in the location not available.");
    }
}