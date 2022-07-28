using System.Net.Mime;
using ApplicationCore.Dto;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherForecastService _service;
    private readonly ILogger<WeatherForecastController> _logger;

    /// <summary>
    /// Initializes a new instance of WeatherForecastController class.
    /// </summary>
    /// <param name="service">Use case layer object</param>
    /// <param name="logger">Logging object</param>
    public WeatherForecastController(
        IWeatherForecastService service,
        ILogger<WeatherForecastController> logger
    )
    {
        _service = service;
        _logger = logger;
    }

    /// <summary>
    /// Gets whether forecast list.
    /// </summary>
    /// <returns>Weather forecast list</returns>
    /// <response code="200">Success</response>
    /// <response code="500">Internal server error</response>
    [HttpGet(Name = "GetWeatherForecast")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WeatherForecastDto[]))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public IActionResult GetWeatherForecasts()
    {
        var url = $"{HttpContext.Request.Path}{HttpContext.Request.QueryString.ToString()}";
        _logger.LogInformation(url);

        try
        {
            var weatherForecasts = _service.GetWeatherForecasts();
            return Ok(weatherForecasts);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            var response = new ProblemDetails
            {
                Type = "about:blank",
                Title = "Unhanded error occurred",
                Status = StatusCodes.Status500InternalServerError,
                Detail = ex.Message,
                Instance = url,
            };
            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }
    }
}
