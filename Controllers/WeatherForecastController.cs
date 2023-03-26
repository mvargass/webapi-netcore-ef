using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static List<WeatherForecast> ListWeatherForecast = new List<WeatherForecast>();
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
        if (ListWeatherForecast == null || !ListWeatherForecast.Any()){
            ListWeatherForecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToList();
        }
    }

    [HttpGet(Name = "GetWeatherForecast")]
    [Route("Get/weatherforecast")]
    //[Route("[action]")]
    public IEnumerable<WeatherForecast> Get()
    {
        _logger.LogDebug("Retornando listado de weatherforecast");
        return ListWeatherForecast;
    }

    [HttpPost(Name = "PostWeatherForecast")]
    public IActionResult Post([FromBody] WeatherForecast weatherForecast){
        ListWeatherForecast.Add(weatherForecast);
        return Ok("Registro insertado");
    }

    [HttpDelete("{index}")]
    public IActionResult Delete([FromRoute] int index){
        ListWeatherForecast.RemoveAt(index);
        return Ok();
    }
}
