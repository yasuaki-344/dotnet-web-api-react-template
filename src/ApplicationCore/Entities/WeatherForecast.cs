using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities;

/// <summary>
/// Represents WeatherForecast entity
/// </summary>
[Table("weather_forecasts")]
public class WeatherForecast
{
    [Column("id")]
    public Guid WeatherForecastId { get; set; } = new Guid();

    [Column("date")]
    public DateTime Date { get; set; }

    [Column("temperature_c")]
    public int TemperatureC { get; set; }

    [Column("summary")]
    public string Summary { get; set; } = string.Empty;
}
