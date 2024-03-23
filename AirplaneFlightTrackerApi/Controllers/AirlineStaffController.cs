using Microsoft.AspNetCore.Mvc;
using AirplaneFlightTrackerApi.Contracts.AirlineStaffs;
using AirplaneFlightTrackerApi.Services.AirlineStaffs;
using AirplaneFlightTrackerApi.Models;

namespace AirplaneFlightTrackerApi.Controllers;

public class AirlineStaffController(IAirlineStaffService airlineStaffService, IConfiguration configuration) : ApiController(configuration)
{
    private readonly IAirlineStaffService _airlineStaffService = airlineStaffService;

    [HttpPost]
    public IActionResult CreateAirlineStaff(CreateAirlineStaffRequest request)
    {
        AirlineStaff airlineStaff = new(request.Username, request.Email, request.Password, request.FirstName, request.LastName, request.Airline, DateTime.UtcNow, DateTime.UtcNow);

        bool success = _airlineStaffService.CreateAirlineStaff(airlineStaff);
        if (success)
        {
            AirlineStaffResponse response = new(airlineStaff.Email, airlineStaff.Username);
            return CreatedAtAction(actionName: nameof(GetAirlineStaff), routeValues: new { email = airlineStaff.Email }, value: response);
        }

        return BadRequest("Airline Staff account already exists.");
    }

    [HttpGet("{email}")]
    public IActionResult GetAirlineStaff(string email)
    {
        AirlineStaff? airlineStaff = _airlineStaffService.GetAirlineStaff(email);
        if (airlineStaff == null)
        {
            return NotFound();
        }

        AirlineStaffResponse response = new(airlineStaff.Email, airlineStaff.Username);
        return Ok(response);
    }

    [HttpDelete("{email}")]
    public IActionResult RemoveAirlineStaff(string email)
    {
        _airlineStaffService.RemoveAirlineStaff(email);
        return NoContent();
    }
}
