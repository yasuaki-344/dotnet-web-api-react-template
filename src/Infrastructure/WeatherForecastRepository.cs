using ApplicationCore.Entities;
using ApplicationCore.Interfaces;

namespace Infrastructure;

public class WeatherForecastRepository : IWeatherForecastRepository
{
    private readonly DatabaseContext _context;

    /// <summary>
    /// Initializes a new instance of ApplicationUserManager class.
    /// </summary>
    /// <param name="context">Database context object</param>
    public WeatherForecastRepository(DatabaseContext context)
    {
        _context = context;
    }

    /// <inheritdoc/>
    public IEnumerable<WeatherForecast> GetWeatherForecasts()
    {
        var entities = _context.WeatherForecasts.AsEnumerable();
        return entities;
    }
}
