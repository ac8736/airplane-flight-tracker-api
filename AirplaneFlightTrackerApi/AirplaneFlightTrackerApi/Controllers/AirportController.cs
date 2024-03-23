using Microsoft.AspNetCore.Mvc;
using AirplaneFlightTrackerApi.Contracts.Airports;
using AirplaneFlightTrackerApi.Models;
using AirplaneFlightTrackerApi.Services.Airports;

namespace AirplaneFlightTrackerApi.Controllers;

public class AirportController(IAirportService airportService, IConfiguration configuration) : ApiController(configuration)
{
    private readonly IAirportService _airportService = airportService;

    [HttpPost("create")]
    public IActionResult CreateAirport(CreateAirportRequest request)
    {
        Airport airport = new(request.Name, request.Code, request.City, request.Country, DateTime.UtcNow);

        bool success = _airportService.CreateAirport(airport);
        if (success)
        {
            AirportResponse response = new(airport.Name, airport.Code, airport.City, airport.Country, airport.DateCreated);
            return CreatedAtAction(
                actionName: nameof(GetAirport),
                routeValues: new { code = airport.Code },
                value: response);
        }

        return BadRequest("Airport of identical code exists.");
    }

    [HttpGet("{code}")]
    public IActionResult GetAirport(string code)
    {
        Airport? airport = _airportService.GetAirport(code);
        if (airport == null)
        {
            return NotFound($"Airport with code {code} does not exist.");
        }

        AirportResponse response = new(airport.Name, airport.Code, airport.City, airport.Country, airport.DateCreated);
        return Ok(response);
    }

    [HttpDelete("{code}")]
    public IActionResult DeleteAirport(string code)
    {
        _airportService.RemoveAirport(code);
        return NoContent();
    }
}
