using System.ComponentModel;
using System.Reflection;
using ApplicationCore.Interfaces;
using ApplicationCore.Mapper;
using ApplicationCore.Services;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebApi.Converters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new DateTimeISO8601Converter());
    });

// Database setting
var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("Postgres");
builder.Services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(connectionString));

// Auto mapping setting
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<AutoMapping>());

// Dependency injection setting
builder.Services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiVersioning(setup =>
{
    setup.DefaultApiVersion = new ApiVersion(2, 0);
    setup.AssumeDefaultVersionWhenUnspecified = true;
    setup.ReportApiVersions = true;
});

builder.Services.AddVersionedApiExplorer(setup =>
{
    setup.GroupNameFormat = "'v'V";
    setup.SubstituteApiVersionInUrl = true;
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Weather forecast API",
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
    // DisplayName属性から名前を生成
    c.CustomSchemaIds(x =>
    {
        var attr = x.GetCustomAttribute<DisplayNameAttribute>();
        return (attr is not null) ? attr.DisplayName : x.Name;
    });

});
builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.yaml", "Weather forecast API v1");
    });
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Database initialization process
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await DbInitializer.SeedAsync(services);
}

app.Run();
