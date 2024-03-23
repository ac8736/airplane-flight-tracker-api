using AirplaneFlightTrackerApi.Models;

namespace AirplaneFlightTrackerApi.Services.Airports;

public interface IAirportService
{
    bool CreateAirport(Airport airport);

    Airport? GetAirport(string code);

    void RemoveAirport(string code);
}