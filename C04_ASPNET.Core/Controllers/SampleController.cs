using C04_ASPNET.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace C04_ASPNET.Core.Controllers;

[ApiController]
[Route("[controller]")]
public class SampleController : ControllerBase
{
    private readonly ILogger<SampleController> _logger;
    private readonly ISampleService _sampleService;

    public SampleController(ILogger<SampleController> logger, ISampleService sampleService)
    {
        _logger = logger;
        _sampleService = sampleService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<SampleResponse> Get()
    {
        _logger.LogInformation("hi");
        return _sampleService.GetSamples().Select(sample => new SampleResponse(sample.Id, sample.Message));
    }
}

public record SampleResponse(int Id, string Message);