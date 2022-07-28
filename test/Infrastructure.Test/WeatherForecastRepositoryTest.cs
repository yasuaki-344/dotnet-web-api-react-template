using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Test;

public class WeatherForecastRepositoryTest : IDisposable
{
    private readonly DatabaseContext _context;
    private readonly WeatherForecastRepository _target;

    public WeatherForecastRepositoryTest()
    {
        var options = new DbContextOptionsBuilder<DatabaseContext>()
            .UseInMemoryDatabase(databaseName: "WeatherForecastRepositoryTestDB")
            .Options;
        _context = new DatabaseContext(options);
        _target = new WeatherForecastRepository(_context);
    }

    public void Dispose()
    {
        _context.Database.EnsureDeleted();
    }

    [Fact]
    public async Task ContactExists_NonExistentId_ReturnsEntities()
    {
        await _context.WeatherForecasts.AddRangeAsync(new[]
        {
            new WeatherForecast
            {
                Date = DateTime.Now,
                TemperatureC = 10,
                Summary = string.Empty
            },
            new WeatherForecast
            {
                Date = DateTime.Now.AddDays(1),
                TemperatureC = 20,
                Summary = "Chilly"
            }
        });
        await _context.SaveChangesAsync();

        var actual = _target.GetWeatherForecasts();

        Assert.NotEmpty(actual);
    }
}
