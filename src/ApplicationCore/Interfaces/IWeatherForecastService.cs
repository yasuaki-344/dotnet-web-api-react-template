using ApplicationCore.Dto;

namespace ApplicationCore.Interfaces;

public interface IWeatherForecastService
{
    WeatherForecastDto[] GetWeatherForecasts();
}
