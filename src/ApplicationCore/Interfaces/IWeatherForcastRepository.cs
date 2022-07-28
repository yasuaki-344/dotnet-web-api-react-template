using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces;

public interface IWeatherForecastRepository
{
    /// <summary>
    /// Returns weather forecast lists.
    /// </summary>
    /// <returns>Weather forecast lists</returns>
    IEnumerable<WeatherForecast> GetWeatherForecasts();
}
