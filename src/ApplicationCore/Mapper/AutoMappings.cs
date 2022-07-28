using AutoMapper;
using ApplicationCore.Dto;
using ApplicationCore.Entities;

namespace ApplicationCore.Mapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        CreateMap<WeatherForecast, WeatherForecastDto>();
    }
}
