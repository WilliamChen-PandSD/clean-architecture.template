namespace CleanArchitecture.Domain.Weather;

public class Temperature
{
    public double CurrentTemp { get; set; }
    public double FeelsLike { get; set; }
    public double MinTemperature { get; set; }
    public double MaxTemperature { get; set; }
    public double Pressure { get; set; }
    public double Humidity { get; set; }
    public double SeeLevel { get; set; }
    public double GroundLevel { get; set; }
    public string? Unit { get; set; }
}
