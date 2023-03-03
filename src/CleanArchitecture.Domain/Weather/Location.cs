namespace CleanArchitecture.Domain.Weather;

public class Location
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string? Country { get; set; }
    public string? State { get; set; }
}