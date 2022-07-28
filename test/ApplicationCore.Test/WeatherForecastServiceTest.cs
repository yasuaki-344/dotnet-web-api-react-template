using ApplicationCore.Dto;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using AutoMapper;

namespace ApplicationCore.Test;

public class WeatherForecastServiceTest
{
    private readonly Mock<IMapper> _mapper;
    private readonly Mock<IWeatherForecastRepository> _repository;
    private readonly WeatherForecastService _target;

    public WeatherForecastServiceTest()
    {
        _mapper = new Mock<IMapper>();
        _repository = new Mock<IWeatherForecastRepository>();
        _target = new WeatherForecastService(_mapper.Object, _repository.Object);
    }

    [Fact]
    public void Map_GivenWeatherForecastEntity_ReturnsDto()
    {
        var actual = _target.GetWeatherForecasts();

        _repository.Verify(mock => mock.GetWeatherForecasts(), Times.Once());
        _mapper.Verify(mock => mock.Map<IEnumerable<WeatherForecast>, WeatherForecastDto[]>(It.IsAny<IEnumerable<WeatherForecast>>()), Times.Once());
    }
}
