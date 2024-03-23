using Microsoft.AspNetCore.Mvc;

namespace AirplaneFlightTrackerApi.Controllers;

public class ErrorController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        return Problem();
    }
}