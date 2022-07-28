using ApplicationCore.Dto;

namespace ApplicationCore.Interfaces;

public interface IWeatherForecastService
{
    /// <summary>
    /// Returns weather forecast lists.
    /// </summary>
    /// <returns>Weather forecast lists</returns>
    WeatherForecastDto[] GetWeatherForecasts();
}
