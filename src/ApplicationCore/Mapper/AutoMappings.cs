using ApplicationCore.Dto;
using ApplicationCore.Entities;
using AutoMapper;

namespace ApplicationCore.Mapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        CreateMap<WeatherForecast, WeatherForecastDto>();
    }
}
