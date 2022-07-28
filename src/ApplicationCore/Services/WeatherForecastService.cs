using ApplicationCore.Dto;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using AutoMapper;

namespace ApplicationCore.Services;

public class WeatherForecastService : IWeatherForecastService
{
    private readonly IMapper _mapper;
    private readonly IWeatherForecastRepository _repository;

    /// <summary>
    /// Initializes a new instance of WeatherForecastService class.
    /// </summary>
    /// <param name="mapper">OR mapper object</param>
    /// <param name="repository">Data access repository</param>
    public WeatherForecastService(IMapper mapper, IWeatherForecastRepository repository)
    {
        _repository = repository;
        _mapper = mapper;
    }

    /// <inheritdoc/>
    public WeatherForecastDto[] GetWeatherForecasts()
    {
        var entities = _repository.GetWeatherForecasts();
        var weatherForecasts = _mapper.Map<IEnumerable<WeatherForecast>, WeatherForecastDto[]>(entities);
        return weatherForecasts;
    }
}
