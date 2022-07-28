using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    /// <summary>
    /// Initializes a new instance of WeatherForecastController class.
    /// </summary>
    /// <param name="logger">Logging object</param>
    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Gets whether forecast list.
    /// </summary>
    /// <returns>Weather forecast list</returns>
    /// <response code="200">Success</response>
    /// <response code="500">Internal server error</response>
    [HttpGet(Name = "GetWeatherForecast")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WeatherForecast[]))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public IActionResult GetWeatherForecasts()
    {
        var url = $"{HttpContext.Request.Path}{HttpContext.Request.QueryString.ToString()}";
        _logger.LogInformation(url);

        try
        {
            var weatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
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
