using System.ComponentModel;
using System.Text.Json.Serialization;

namespace ApplicationCore.Dto;

[DisplayName("WeatherForecast")]
public class WeatherForecastDto
{
    [JsonPropertyName("date")]
    public DateTime Date { get; set; }

    [JsonPropertyName("temperature_c")]
    public int TemperatureC { get; set; }

    [JsonPropertyName("temperature_f")]
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    [JsonPropertyName("summary")]
    public string Summary { get; set; } = string.Empty;
}
