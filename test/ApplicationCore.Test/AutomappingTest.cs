using ApplicationCore.Dto;
using ApplicationCore.Entities;
using ApplicationCore.Mapper;
using AutoMapper;

namespace ApplicationCore.Test;

public class AutoMappingTest
{
    private readonly IMapper _mapper;

    public AutoMappingTest()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapping>());
        _mapper = config.CreateMapper();
    }

    [Fact]
    public void Map_GivenWeatherForecastEntity_ReturnsDto()
    {
        var entity = new WeatherForecast
        {
            Date = DateTime.Today,
            TemperatureC = 100,
            Summary = "test"
        };
        var dto = _mapper.Map<WeatherForecastDto>(entity);
        Assert.Equal(entity.Date, dto.Date);
        Assert.Equal(entity.TemperatureC, dto.TemperatureC);
        Assert.Equal(entity.Summary, dto.Summary);
    }
}
