using Microsoft.AspNetCore.Mvc;

namespace AirplaneFlightTrackerApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ApiController(IConfiguration configuration) : ControllerBase
{
    protected readonly IConfiguration _configuration = configuration;
}