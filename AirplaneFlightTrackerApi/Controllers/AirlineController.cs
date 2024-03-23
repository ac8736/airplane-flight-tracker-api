using Microsoft.AspNetCore.Mvc;
using AirplaneFlightTrackerApi.Services.Airlines;
using AirplaneFlightTrackerApi.Contracts.Airlines;
using AirplaneFlightTrackerApi.Models;

namespace AirplaneFlightTrackerApi.Controllers;

public class AirlineController(IAirlineService airlineService, IConfiguration configuration) : ApiController(configuration)
{
    private readonly IAirlineService _airlineService = airlineService;

    [HttpPost]
    public IActionResult CreateAirline(CreateAirlineRequest request)
    {
        Airline airline = new(request.Name.Replace(' ', '-'));

        bool success = _airlineService.CreateAirline(airline);
        if (success)
        {
            AirlineResponse response = new(airline.Name.Replace('-', ' '));
            return Ok(response);
        }

        return BadRequest("Airport of identical name exists.");
    }

    [HttpDelete("{name}")]
    public IActionResult DeleteAirline(string name)
    {
        _airlineService.RemoveAirline(name);
        return NoContent();
    }
}