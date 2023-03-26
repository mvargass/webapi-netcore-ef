using Microsoft.AspNetCore.Mvc;
namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
    private IHelloWorldService _service;
    private readonly ILogger<WeatherForecastController> _logger;
    public HelloWorldController(IHelloWorldService service, ILogger<WeatherForecastController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [Route("get/helloworld")]
    public IActionResult GetHelloWorld(){
        return Ok(_service.GetHelloWorld());
    }
}