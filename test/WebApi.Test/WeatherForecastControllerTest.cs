using System.Net;
using ApplicationCore.Dto;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Controllers;

namespace WebApi.Test;

public class WeatherForecastControllerTest
{
    private readonly Mock<ILogger<WeatherForecastController>> _logger;
    private readonly Mock<IWeatherForecastService> _service;
    private readonly WeatherForecastController _target;

    public WeatherForecastControllerTest()
    {
        _logger = new Mock<ILogger<WeatherForecastController>>();
        _service = new Mock<IWeatherForecastService>();
        _target = new WeatherForecastController(_service.Object, _logger.Object);
        _target.ControllerContext.HttpContext = new DefaultHttpContext();
    }

    [Fact]
    public void GetWeatherForecasts_ValidProcess_ReturnsOk()
    {
        _service
            .Setup(o => o.GetWeatherForecasts())
            .Returns(new[]
            {
                new WeatherForecastDto(),
                new WeatherForecastDto(),
            });

        var actionResult = _target.GetWeatherForecasts();
        var objectResult = Assert.IsType<OkObjectResult>(actionResult);
        Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);

        var response = Assert.IsType<WeatherForecastDto[]>(objectResult.Value);
        Assert.Equal(2, response.Length);
    }

    [Fact]
    public void GetWeatherForecasts_ExceptionThrown_ReturnsInternalServerError()
    {
        _service
            .Setup(o => o.GetWeatherForecasts())
            .Throws<Exception>();

        var actionResult = _target.GetWeatherForecasts();

        var objectResult = Assert.IsType<ObjectResult>(actionResult);
        Assert.Equal((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);

        var response = Assert.IsType<ProblemDetails>(objectResult.Value);
        Assert.Equal((int)HttpStatusCode.InternalServerError, response.Status);
    }
}
