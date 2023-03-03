using ErrorOr;

namespace CleanArchitecture.Domain.Common.Errors;

public static partial class Errors
{
    public static class Location
    {
        public static Error LocationNotFound
        => Error.NotFound(code: "Location.NotFound",
                          description: "Can not find location.");
    }
}